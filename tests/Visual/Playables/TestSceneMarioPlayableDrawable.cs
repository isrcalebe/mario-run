using mario.Game.Graphics.Playables;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.Playables;

[TestFixture]
public partial class TestSceneMarioPlayableDrawable : GameApplicationTestScene
{
    private MarioPlayableDrawable? playableDrawable;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(playableDrawable = new MarioPlayableDrawable
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Scale = new Vector2(8.0f)
        });

        AddStep("set idle state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Idle);
        AddStep("set walk state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Walk);
        AddStep("set jump state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Jump);
        AddStep("set fall state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Fall);
        AddStep("set run state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Run);
        AddStep("set run jump state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.RunJump);
        AddStep("set spin state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Spin);
        AddStep("set dead state", () => playableDrawable.State.Value = MarioPlayableDrawable.MarioAnimationState.Dead);

        AddToggleStep("toggle collision quad", state =>
        {
            if (state)
                playableDrawable.ShowCollisionQuad();
            else
                playableDrawable.HideCollisionQuad();
        });
    }
}
