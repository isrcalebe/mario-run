global using osu.Framework.Allocation;
global using osu.Framework.Bindables;
global using osu.Framework.Graphics;
global using osu.Framework.Logging;
global using osu.Framework.Utils;
global using osuTK;
using osu.Framework.IO.Stores;
using mario.Game.Resources;
using osu.Framework.Graphics.Textures;

namespace mario.Game;

public abstract partial class GameApplicationBase : osu.Framework.Game
{
    private DependencyContainer? dependencies;

    protected override TextureFilteringMode DefaultTextureFilteringMode
        => TextureFilteringMode.Nearest;

    [BackgroundDependencyLoader]
    private void load()
    {
        Resources.AddStore(new DllResourceStore(GameResources.Assembly));

        AddFont(Resources, @"Fonts/IbmVga");

        Host.Window.Title = "MARIO RUN";
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
}
