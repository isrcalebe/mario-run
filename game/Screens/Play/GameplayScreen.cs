using mario.Game.Gameplay;
using mario.Game.Graphics.Backgrounds;
using mario.Game.Graphics.UI;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osu.Framework.Threading;
using osuTK.Input;

namespace mario.Game.Screens.Play;

public partial class GameplayScreen : Screen
{
    public const float PLAYER_START_POS_Y = -96.0f;

    private readonly DrawSizePreservingFillContainer gameScreen = new();

    private ParallaxBackgroundDrawable? parallaxBackground;

    private PhysicalGroundDrawable? physicalGround;

    private MarioPlayableDrawable? player;

    private ScreenTitleDrawable? getReadySprite;
    private ScreenTitleDrawable? gameOverSprite;

    private ScreenFlashDrawable? screenFlash;

    private GameManager? gameManager;

    private ScheduledDelegate? counterScheduler;

    [BackgroundDependencyLoader]
    private void load(GameManager gameManager)
    {
        this.gameManager = gameManager;

        parallaxBackground = new ParallaxBackgroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
            Y = -96.0f,
        };

        physicalGround = new PhysicalGroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
        };

        player = new MarioPlayableDrawable
        {
            Anchor = Anchor.BottomLeft,
            Origin = Anchor.BottomCentre,
            Scale = new Vector2(4.0f),
            X = 120.0f,
            GroundY = PLAYER_START_POS_Y,
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
            gameOverSprite,
            player,
        };

        gameOverSprite.Hide();

        AddInternal(gameScreen);
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        switch (e)
        {
            case { Repeat: false, Key: Key.Space }:
                if (gameManager?.State != GameState.Playing)
                    startGame();
                break;

            case { Repeat: false, Key: Key.ShiftLeft }:
                if (gameManager?.State == GameState.Playing)
                    reset();
                break;
        }

        return base.OnKeyDown(e);
    }

    private void reset()
    {
        parallaxBackground?.Freeze();
        physicalGround?.Freeze();
        getReadySprite?.Show();
        gameOverSprite?.Hide();
        player!.Y = PLAYER_START_POS_Y;

        screenFlash?.Flash(0.0d, 700.0d);

        gameManager?.Reset();
        counterScheduler?.Cancel();
        Logger.Log($"High Score: {gameManager?.HighScore}");
        player.LockInput = true;
    }

    private void startGame()
    {
        parallaxBackground?.Start();
        physicalGround?.Start();
        getReadySprite?.Hide();

        screenFlash?.Flash(0.0d, 700.0d);

        gameManager?.Start();
        player!.LockInput = false;

        counterScheduler = Scheduler.AddDelayed(() =>
        {
            gameManager?.IncreaseScoreBy();
            Logger.Log($"Score: {gameManager?.Score}");
        }, 500.0d, true);
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        reset();

        base.OnEntering(e);
    }
}
