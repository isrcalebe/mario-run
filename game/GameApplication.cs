using mario.Game.Graphics.Backgrounds;
using mario.Game.Graphics.UI;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private readonly DrawSizePreservingFillContainer gameScreen = new();

    private ParallaxBackgroundDrawable? parallaxBackground;

    private TitleSprite? getReadySprite;
    private TitleSprite? gameOverSprite;

    private ScreenFlash? screenFlash;

    [BackgroundDependencyLoader]
    private void load()
    {
        parallaxBackground = new ParallaxBackgroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One
        };

        getReadySprite = new TitleSprite(@"get-ready")
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre
        };

        gameOverSprite = new TitleSprite(@"game-over")
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre
        };

        screenFlash = new ScreenFlash
        {
            Colour = Colour4.White
        };

        gameScreen.Strategy = DrawSizePreservationStrategy.Minimum;
        gameScreen.TargetDrawSize = new Vector2(0, 768);
        gameScreen.Children = new Drawable[]
        {
            parallaxBackground,
            getReadySprite,
            screenFlash
        };

        Add(gameScreen);
    }

    protected override void LoadComplete()
    {
        parallaxBackground?.Start();

        base.LoadComplete();
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        // Just for testing :)
        screenFlash?.Flash(0.0d, 700.0d);

        return base.OnKeyDown(e);
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => new DependencyContainer(base.CreateChildDependencies(parent));
}
