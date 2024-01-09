using mario.Game.Graphics.Playables;
using osu.Framework.Audio;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osuTK.Input;

namespace mario.Game.Gameplay;

public partial class MarioPlayableDrawable : CompositeDrawable
{
    public double VerticalStopSpeedMultiplier = 0.25d;
    public double JumpSpeed = 15.95d;
    public double GravityUp = 0.75d;
    public double GravityDown = 0.6d;
    public double MaxVerticalSpeed = 30.0d;

    private double verticalSpeed;
    private bool availableJump;
    private bool isSpinning;

    private MarioAnimationDrawable? animation;

    private DrawableSample? jumpSample;
    private DrawableSample? spinSample;

    public float GroundY { get; set; }

    public bool LockInput { get; set; }

    [BackgroundDependencyLoader]
    private void load(AudioManager audio)
    {
        Size = new Vector2(16.0f);

        AddRangeInternal(new Drawable[]
        {
            jumpSample = new DrawableSample(audio.Samples.Get(@"Playables/jump.wav")),
            spinSample = new DrawableSample(audio.Samples.Get(@"Playables/spin.wav")),
            animation = new MarioAnimationDrawable
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            }
        });
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (LockInput)
            return base.OnKeyDown(e);

        switch (e)
        {
            case { Repeat: false, Key: Key.Up }:
                onJumpPressed();
                return base.OnKeyDown(e);

            case { Repeat: false, Key: Key.ShiftRight }:
                onSpinPressed();
                return base.OnKeyDown(e);

            default:
                return base.OnKeyDown(e);
        }
    }

    protected override void OnKeyUp(KeyUpEvent e)
    {
        if (e is { Key: Key.Up or Key.ShiftRight })
            onJumpReleased();

        base.OnKeyUp(e);
    }

    protected override void Update()
    {
        var elapsedFrameTime = Clock.ElapsedFrameTime;
        var timeDifference = elapsedFrameTime / 21.0d;

        if (Precision.AlmostEquals(verticalSpeed, 0, 0.001))
            verticalSpeed = 0.0d;

        verticalSpeed -= (verticalSpeed > 0 ? GravityUp : GravityDown) * timeDifference;

        if (verticalSpeed < 0)
        {
            if (verticalSpeed < -MaxVerticalSpeed)
                verticalSpeed = -MaxVerticalSpeed;
        }

        switch (verticalSpeed)
        {
            case > 0:
                moveVertical(timeDifference);
                break;

            case <= 0:
            {
                moveVertical(timeDifference);
                break;
            }
        }

        updateAnimationState();

        base.Update();
    }

    private void moveVertical(double timeDifference)
    {
        Y -= (float)(verticalSpeed * timeDifference);

        if (Y >= GroundY)
        {
            Y = GroundY;
            verticalSpeed = 0.0d;
        }

        if (!Precision.AlmostEquals(Y, GroundY)) return;

        availableJump = true;
        isSpinning = false;
    }

    private void onJumpPressed()
    {
        if (!availableJump) return;

        availableJump = false;

        jumpSample?.Play();
        verticalSpeed = JumpSpeed;
    }

    private void onJumpReleased()
    {
        if (verticalSpeed < 0)
            return;

        verticalSpeed *= VerticalStopSpeedMultiplier;
    }

    private void onSpinPressed()
    {
        if (!availableJump && isSpinning) return;

        availableJump = false;
        isSpinning = true;

        spinSample?.Play();
        verticalSpeed = JumpSpeed;
    }

    private void updateAnimationState()
    {
        switch (verticalSpeed)
        {
            case > 0.0d:
                animation!.State.Value = isSpinning ? MarioAnimationDrawable.MarioAnimationState.Spin : MarioAnimationDrawable.MarioAnimationState.Jump;
                break;

            case < 0.0d:
            {
                if (!isSpinning)
                    animation!.State.Value = MarioAnimationDrawable.MarioAnimationState.Fall;
                break;
            }

            case 0.0d:
                animation!.State.Value = LockInput
                    ? MarioAnimationDrawable.MarioAnimationState.Idle
                    : MarioAnimationDrawable.MarioAnimationState.Walk;
                break;
        }
    }
}
