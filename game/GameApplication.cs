using mario.Game.Screens.Menu;
using mario.Game.Screens.Play;
using osu.Framework.Screens;

namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private DependencyContainer? dependencies;

    private ScreenStack? screens;

    public GameManager GameManager { get; } = new();

    [BackgroundDependencyLoader]
    private void load()
    {
        dependencies?.Cache(GameManager);

        GameManager.Reset();

        Add(screens = new ScreenStack());

        screens.Push(new DisclaimerScreen(new GameplayScreen()));
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
