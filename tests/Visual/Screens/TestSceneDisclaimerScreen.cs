using mario.Game.Screens.Menu;
using NUnit.Framework;
using osu.Framework.Screens;

namespace mario.Game.Tests.Visual.Screens;

[TestFixture]
public partial class TestSceneDisclaimerScreen : GameApplicationTestScene
{
    private ScreenStack? screens;
    private DisclaimerScreen? screen;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(screens = new ScreenStack());

        screens.Push(screen = new DisclaimerScreen());
    }
}
