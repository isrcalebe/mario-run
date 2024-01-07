using mario.Game.Graphics.Backdrop;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Rendering;

namespace mario.Game;

public partial class GameApplication : GameApplicationBase
{
    private readonly DrawSizePreservingFillContainer gameScreen = new();

    private BackdropPoolDrawable? rocksBackdrop;

    [BackgroundDependencyLoader]
    private void load(IRenderer renderer)
    {
        rocksBackdrop = new BackdropPoolDrawable
        {
            Duration = 20000.0f,
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = Textures.Get(@"Backgrounds/Overworld/rocks")
            }
        };

        gameScreen.Children = new Drawable[]
        {
            rocksBackdrop
        };

        Add(gameScreen);

        rocksBackdrop.Start();
    }

    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        => new DependencyContainer(base.CreateChildDependencies(parent));
}
