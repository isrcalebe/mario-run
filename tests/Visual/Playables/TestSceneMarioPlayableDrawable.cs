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
    }
}
