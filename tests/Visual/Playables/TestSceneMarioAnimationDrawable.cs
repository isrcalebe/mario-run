using mario.Game.Graphics.Playables;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.Playables;

[TestFixture]
public partial class TestSceneMarioAnimationDrawable : GameApplicationTestScene
{
    private MarioAnimationDrawable? marionAnimation;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(marionAnimation = new MarioAnimationDrawable
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Scale = new Vector2(8.0f)
        });

        AddStep("set idle state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Idle);
        AddStep("set look up state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.LookUp);
        AddStep("set walk state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Walk);
        AddStep("set jump state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Jump);
        AddStep("set fall state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Fall);
        AddStep("set run state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Run);
        AddStep("set run jump state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.RunJump);
        AddStep("set spin state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Spin);
        AddStep("set dead state", () => marionAnimation.State.Value = MarioAnimationDrawable.MarioAnimationState.Dead);
    }
}
