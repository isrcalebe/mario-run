using mario.Game.Graphics.Backdrops;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Gameplay;

public partial class PhysicalGroundDrawable : CompositeDrawable
{
    private BackdropPoolDrawable? groundBackdrop;

    private Box? collisionBox;

    public Quad CollisionQuad
    {
        get
        {
            var rectangle = collisionBox?.ScreenSpaceDrawQuad.AABBFloat;

            return Quad.FromRectangle(rectangle ?? RectangleF.Empty);
        }
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        AddRangeInternal(new Drawable[]
        {
            groundBackdrop = new BackdropPoolDrawable(() => new Sprite
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Scale = new Vector2(4.0f),
                Texture = textures.Get(@"Tilesets/Overworld/ground-center")
            }),
            collisionBox = new Box
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                Colour = Colour4.FromHex("e02041"),
                Alpha = 0.0f,
                RelativeSizeAxes = Axes.X,
                Scale = new Vector2(2.0f),
                Size = new Vector2(1f, 48.0f)
            }
        });
    }

    public virtual void Start()
        => groundBackdrop?.Start();

    public virtual void Freeze()
        => groundBackdrop?.Freeze();

    public void ShowCollisionQuad()
        => collisionBox?.FadeIn().Then()
                       .FadeTo(0.3f, 500.0d);

    public void HideCollisionQuad()
        => collisionBox?.FadeOut(200.0d);
}
