using mario.Game.Graphics.Playables;
using osu.Framework.Audio;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;

namespace mario.Game.Screens.Menu;

public partial class DisclaimerScreen : Screen
{
    private DrawSizePreservingFillContainer? screenContents;

    private DrawableSample? messageSample;

    private MessageBoxSprite? messageBoxSprite;
    private MarioAnimationDrawable? marioAnimation;

    private TextFlowContainer? messageText;

    private readonly Screen? nextScreen;

    public DisclaimerScreen(Screen? nextScreen = null)
    {
        this.nextScreen = nextScreen;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures, AudioManager audio)
    {
        screenContents = new DrawSizePreservingFillContainer();
        screenContents.Strategy = DrawSizePreservationStrategy.Minimum;
        screenContents.TargetDrawSize = new Vector2(0, 768);

        screenContents.Children = new Drawable[]
        {
            messageSample = new DrawableSample(audio.Samples.Get(@"UI/message.wav")),
            messageBoxSprite = new MessageBoxSprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Y = -96.0f,
                Scale = new Vector2(8.0f),
            },
            marioAnimation = new MarioAnimationDrawable
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.X,
                X = -0.4f,
                Y = 96.0f,
                Scale = new Vector2(8.0f)
            },
            messageText = new TextFlowContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                Y = -256.0f,
                Padding = new MarginPadding(24.0f),
                TextAnchor = Anchor.Centre
            }
        };

        messageText.AddText("THIS GAME IS INSPIRED BY CHROME DINO!", text =>
        {
            text.Font = new FontUsage("IbmVga", size: 24.0f);
        });
        messageText.NewLine();
        messageText.AddText("YOU CAN LOOK AT THE SOURCE CODE ON GITHUB", text =>
        {
            text.Font = new FontUsage("IbmVga", size: 24.0f);
        });

        messageText.Hide();

        AddInternal(screenContents);
    }

    protected override void LoadComplete()
    {
        marioAnimation!.State.Value = MarioAnimationDrawable.MarioAnimationState.Walk;

        var lastY = marioAnimation.Y;

        marioAnimation
            .MoveToX(0.0f, 2500.0d).Then()
            .OnComplete(drawable =>
            {
                drawable.State.Value = MarioAnimationDrawable.MarioAnimationState.LookUp;

                Scheduler.AddDelayed(() =>
                {
                    drawable.State.Value = MarioAnimationDrawable.MarioAnimationState.Jump;

                    drawable.MoveToY(-44.0f, 300.0d, Easing.Out).Then()
                            .OnComplete(drawable2 =>
                            {
                                drawable2.State.Value = MarioAnimationDrawable.MarioAnimationState.Fall;
                                drawable2.MoveToY(lastY, 400.0d, Easing.In).Then()
                                         .OnComplete(drawable3 =>
                                         {
                                             drawable2.State.Value = MarioAnimationDrawable.MarioAnimationState.Idle;
                                         });
                            });
                }, 500.0d);

                Scheduler.AddDelayed(() =>
                {
                    messageBoxSprite?.Touch();
                    messageSample?.Play();
                    messageText?.Show();
                }, 680.0d);

                Scheduler.AddDelayed(() =>
                {
                    if (nextScreen != null)
                        this.Push(nextScreen);
                }, 3000.0d);
            });

        base.LoadComplete();
    }

    public override bool OnExiting(ScreenExitEvent e)
    {
        this.FadeOut(500.0d, Easing.Out);

        return base.OnExiting(e);
    }
}
