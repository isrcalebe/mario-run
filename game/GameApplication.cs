using mario.Game.Gameplay;
using mario.Game.Graphics.Backgrounds;
using mario.Game.Graphics.Playables;
using mario.Game.Graphics.UI;
using osu.Framework.Graphics.Containers;

namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private readonly DrawSizePreservingFillContainer gameScreen = new();

    private ParallaxBackgroundDrawable? parallaxBackground;

    private PhysicalGroundDrawable? physicalGround;

    private MarioAnimationDrawable? player;

    private ScreenTitleDrawable? getReadySprite;
    private ScreenTitleDrawable? gameOverSprite;

    private ScreenFlashDrawable? screenFlash;

    private const float bounds_y = -96.0f;

    [BackgroundDependencyLoader]
    private void load()
    {
        parallaxBackground = new ParallaxBackgroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One
        };

        physicalGround = new PhysicalGroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
        };

        player = new MarioAnimationDrawable
        {
            Anchor = Anchor.BottomLeft,
            Origin = Anchor.BottomCentre,
            Scale = new Vector2(4.0f),
            X = 120.0f,
            Y = bounds_y,
        };

        getReadySprite = new ScreenTitleDrawable(@"get-ready")
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre
        };

        gameOverSprite = new ScreenTitleDrawable(@"game-over")
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre
        };

        screenFlash = new ScreenFlashDrawable
        {
            Colour = Colour4.White
        };

        gameScreen.Strategy = DrawSizePreservationStrategy.Minimum;
        gameScreen.TargetDrawSize = new Vector2(0, 768);
        gameScreen.Children = new Drawable[]
        {
            parallaxBackground,
            physicalGround,
            player,
            getReadySprite,
            screenFlash
        };

        Add(gameScreen);
    }

    protected override void LoadComplete()
    {
        parallaxBackground?.Start();
        physicalGround?.Start();

        base.LoadComplete();
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => new DependencyContainer(base.CreateChildDependencies(parent));
}
