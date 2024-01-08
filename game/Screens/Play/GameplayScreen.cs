using mario.Game.Gameplay;
using mario.Game.Graphics.Backgrounds;
using mario.Game.Graphics.Playables;
using mario.Game.Graphics.UI;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;

namespace mario.Game.Screens.Play;

public partial class GameplayScreen : Screen
{
    public const float PLAYER_START_POS_Y = -96.0f;

    private readonly DrawSizePreservingFillContainer gameScreen = new();

    private ParallaxBackgroundDrawable? parallaxBackground;

    private PhysicalGroundDrawable? physicalGround;

    private MarioAnimationDrawable? player;

    private ScreenTitleDrawable? getReadySprite;
    private ScreenTitleDrawable? gameOverSprite;

    private ScreenFlashDrawable? screenFlash;

    [BackgroundDependencyLoader]
    private void load()
    {
        parallaxBackground = new ParallaxBackgroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
            Y = -48.0f,
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
            Y = PLAYER_START_POS_Y,
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
            screenFlash,
            getReadySprite,
            player,
        };

        AddInternal(gameScreen);
    }

    protected override void LoadComplete()
    {
        parallaxBackground?.Start();

        base.LoadComplete();
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        screenFlash?.Flash(0.0d, 700.0d);

        base.OnEntering(e);
    }
}
