using mario.Game.Screens.Menu;
using mario.Game.Screens.Play;
using osu.Framework.Screens;

namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private ScreenStack? screens;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(screens = new ScreenStack());

        screens.Push(new DisclaimerScreen(new GameplayScreen()));
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => new DependencyContainer(base.CreateChildDependencies(parent));
}
