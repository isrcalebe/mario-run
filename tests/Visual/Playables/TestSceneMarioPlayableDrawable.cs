using mario.Game.Gameplay;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.Playables;

[TestFixture]
public partial class TestSceneMarioPlayableDrawable : GameApplicationTestScene
{
    private MarioPlayableDrawable? marioPlayable;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(marioPlayable = new MarioPlayableDrawable
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Scale = new Vector2(8.0f)
        });

        AddSliderStep("vertical stop speed multiplier", 0.0d, 5.0d, 0.25d, value => marioPlayable.VerticalStopSpeedMultiplier = value);
        AddSliderStep("jump speed", 0.0d, 50.0d, 15.95d, value => marioPlayable.JumpSpeed = value);
        AddSliderStep("gravity up", 0.0d, 5.0d, 0.75d, value => marioPlayable.GravityUp = value);
        AddSliderStep("gravity down", 0.0d, 5.0d, 0.6d, value => marioPlayable.GravityUp = value);
        AddSliderStep("max vertical speed", 0.0d, 30.0d, 20.0d, value => marioPlayable.MaxVerticalSpeed = value);
    }
}
