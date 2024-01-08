using mario.Game.Screens.Play;
using NUnit.Framework;
using osu.Framework.Screens;

namespace mario.Game.Tests.Visual.Screens;

[TestFixture]
public partial class TestSceneGameplayScreen : GameApplicationTestScene
{
    private ScreenStack? screens;
    private GameplayScreen? screen;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(screens = new ScreenStack());

        screens.Push(screen = new GameplayScreen());
    }
}
