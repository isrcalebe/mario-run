using System;
using mario.Game.Graphics.Backdrops;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Graphics.Backgrounds;

public sealed partial class ParallaxBackgroundDrawable : CompositeDrawable
{
    private Box? skyBackground;
    private BackdropPoolDrawable? cloudsBackdrop;
    private BackdropPoolDrawable? rocksBackdrop;
    private BackdropPoolDrawable? bushes0Backdrop;
    private BackdropPoolDrawable? bushes1Backdrop;

    private TextureStore? textures;

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        this.textures = textures;

        skyBackground = new Box
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
            Colour = Colour4.FromHex("98e0e0")
        };
        rocksBackdrop = new BackdropPoolDrawable(generateSpriteFunc("rocks"))
        {
            Duration = 20000.0f,
        };
        bushes0Backdrop = new BackdropPoolDrawable(generateSpriteFunc("bushes-0"))
        {
            Duration = 15000.0f
        };
        bushes1Backdrop = new BackdropPoolDrawable(generateSpriteFunc("bushes-1"))
        {
            Duration = 12500.0f,
        };
        cloudsBackdrop = new BackdropPoolDrawable(generateSpriteFunc("cloud"))
        {
            Duration = 25000.0f,
        };

        AddRangeInternal(new Drawable[]
        {
            skyBackground,
            cloudsBackdrop,
            rocksBackdrop,
            bushes0Backdrop,
            bushes1Backdrop,
        });
    }

    public void Start()
    {
        rocksBackdrop?.Start();
        bushes0Backdrop?.Start();
        bushes1Backdrop?.Start();
        cloudsBackdrop?.Start();
    }

    public void Freeze()
    {
        rocksBackdrop?.Freeze();
        bushes0Backdrop?.Freeze();
        bushes1Backdrop?.Freeze();
        cloudsBackdrop?.Freeze();
    }

    private Func<Sprite> generateSpriteFunc(string textureName)
        => () => new BackdropSprite
        {
            Texture = textures?.Get($@"Backgrounds/Overworld/{textureName}")
        };
}
