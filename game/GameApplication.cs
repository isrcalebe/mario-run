namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private DependencyContainer? dependencies;

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
