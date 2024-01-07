using System;
using osu.Framework.Graphics.Animations;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Graphics.Playables;

public sealed partial class MarioAnimationDrawable : TextureAnimation
{
    private const double idle_interval_duration = 1.0d;
    private const double walk_interval_duration = 200.0d;
    private const double run_interval_duration = 100.0d;
    private const double spin_interval_duration = 100.0d;
    private const double dead_interval_duration = 150.0d;

    private TextureStore? textures;

    public Bindable<MarioAnimationState> State = new();

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        this.textures = textures;

        State.BindValueChanged(onNextState, true);
    }

    private void onNextState(ValueChangedEvent<MarioAnimationState> e)
    {
        ClearFrames();

        switch (e.NewValue)
        {
            case MarioAnimationState.Idle:
                AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/idle"),
                    Duration = idle_interval_duration,
                });
                break;

            case MarioAnimationState.Walk:
                AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/walk-0"),
                        Duration = walk_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/walk-1"),
                        Duration = walk_interval_duration
                    },
                });
                break;

            case MarioAnimationState.Jump:
                AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/jump"),
                    Duration = idle_interval_duration,
                });
                break;

            case MarioAnimationState.Run:
                AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/run-0"),
                        Duration = run_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/run-1"),
                        Duration = run_interval_duration
                    },
                });
                break;

            case MarioAnimationState.RunJump:
                AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/run-jump"),
                    Duration = idle_interval_duration,
                });
                break;

            case MarioAnimationState.Fall:
                AddFrame(new FrameData<Texture?>
                {
                    Content = textures?.Get(@"Playables/Mario/fall"),
                    Duration = idle_interval_duration,
                });
                break;

            case MarioAnimationState.Spin:
                AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-0"),
                        Duration = spin_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-1"),
                        Duration = spin_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-2"),
                        Duration = spin_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/spin-3"),
                        Duration = spin_interval_duration
                    },
                });
                break;

            case MarioAnimationState.Dead:
                AddFrames(new[]
                {
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/dead-0"),
                        Duration = dead_interval_duration
                    },
                    new FrameData<Texture?>
                    {
                        Content = textures?.Get(@"Playables/Mario/dead-1"),
                        Duration = dead_interval_duration
                    },
                });
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(e));
        }
    }

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
