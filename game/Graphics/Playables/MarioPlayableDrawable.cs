using System;
using osu.Framework.Graphics.Animations;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Graphics.Playables;

public sealed partial class MarioPlayableDrawable : CompositeDrawable
{
    public const double IDLE_INTERVAL_DURATION = 1.0d;
    public const double WALK_INTERVAL_DURATION = 200.0d;
    public const double RUN_INTERVAL_DURATION = 100.0d;
    public const double SPIN_INTERVAL_DURATION = 100.0d;
    public const double DEAD_INTERVAL_DURATION = 150.0d;

    private TextureAnimation? animation;

    private Box? collisionBox;

    private TextureStore? textures;

    public Bindable<MarioAnimationState> State = new();

    public override Vector2 Size => new(32.0f);

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        this.textures = textures;

        AddRangeInternal(new Drawable[]
        {
            animation = new TextureAnimation
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(2.0f),
            },
            collisionBox = new Box
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                Colour = Colour4.FromHex("e02041"),
                Alpha = 0.0f,
                Size = new Vector2(14.0f, 20.0f)
            }
        });

        State.BindValueChanged(onNextState, true);
    }

    private void onNextState(ValueChangedEvent<MarioAnimationState> e)
    {
        animation?.ClearFrames();

        switch (e.NewValue)
        {
            case MarioAnimationState.Idle:
                animation?.AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/idle"),
                    Duration = IDLE_INTERVAL_DURATION,
                });
                break;

            case MarioAnimationState.Walk:
                animation?.AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/walk-0"),
                        Duration = WALK_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/walk-1"),
                        Duration = WALK_INTERVAL_DURATION
                    },
                });
                break;

            case MarioAnimationState.Jump:
                animation?.AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/jump"),
                    Duration = IDLE_INTERVAL_DURATION,
                });
                break;

            case MarioAnimationState.Run:
                animation?.AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/run-0"),
                        Duration = RUN_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/run-1"),
                        Duration = RUN_INTERVAL_DURATION
                    },
                });
                break;

            case MarioAnimationState.RunJump:
                animation?.AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/run-jump"),
                    Duration = IDLE_INTERVAL_DURATION,
                });
                break;

            case MarioAnimationState.Fall:
                animation?.AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/fall"),
                    Duration = IDLE_INTERVAL_DURATION,
                });
                break;

            case MarioAnimationState.Spin:
                animation?.AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-0"),
                        Duration = SPIN_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-1"),
                        Duration = SPIN_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-2"),
                        Duration = SPIN_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-3"),
                        Duration = SPIN_INTERVAL_DURATION
                    },
                });
                break;

            case MarioAnimationState.Dead:
                animation?.AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/dead-0"),
                        Duration = DEAD_INTERVAL_DURATION
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/dead-1"),
                        Duration = DEAD_INTERVAL_DURATION
                    },
                });
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(e));
        }
    }

    public void ShowCollisionQuad()
        => collisionBox?.FadeIn().Then()
                       .FadeTo(0.3f, 500.0d);

    public void HideCollisionQuad()
        => collisionBox?.FadeOut(200.0d);

    public enum MarioAnimationState
    {
        Idle = 0,
        Walk,
        Jump,
        Run,
        RunJump,
        Fall,
        Spin,
        Dead
    }
}
