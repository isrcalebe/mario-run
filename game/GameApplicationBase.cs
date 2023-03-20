global using osu.Framework.Allocation;
using mario.Game.Resources;
using osu.Framework.IO.Stores;

namespace mario.Game;

public abstract partial class GameApplicationBase : osu.Framework.Game
{
    private DependencyContainer? dependencies;

    [BackgroundDependencyLoader]
    private void load()
    {
        Resources.AddStore(new DllResourceStore(GameResources.Assembly));

        Host.Window.Title = "MARIO RUN";
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
