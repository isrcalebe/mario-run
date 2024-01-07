using mario.Game.Graphics.Backdrop;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Graphics.Backgrounds;

public sealed partial class ParallaxBackgroundDrawable : CompositeDrawable
{
    private Box? skyBackground;
    private BackdropPoolDrawable? cloudsBackdrop;
    private BackdropPoolDrawable? rocksBackdrop;
    private BackdropPoolDrawable? bushes0Backdrop;
    private BackdropPoolDrawable? bushes1Backdrop;

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        skyBackground = new Box
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
            Colour = Colour4.FromHex("98e0e0")
        };
        rocksBackdrop = new BackdropPoolDrawable
        {
            Duration = 20000.0f,
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = textures.Get(@"Backgrounds/Overworld/rocks")
            }
        };
        bushes0Backdrop = new BackdropPoolDrawable
        {
            Duration = 15000.0f,
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = textures.Get(@"Backgrounds/Overworld/bushes-0")
            }
        };
        bushes1Backdrop = new BackdropPoolDrawable
        {
            Duration = 12500.0f,
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = textures.Get(@"Backgrounds/Overworld/bushes-1")
            }
        };
        cloudsBackdrop = new BackdropPoolDrawable
        {
            Duration = 25000.0f,
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = textures.Get(@"Backgrounds/Overworld/cloud")
            }
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
}
