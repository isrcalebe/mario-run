using mario.Game.Graphics.Backdrop;
using NUnit.Framework;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Tests.Visual;

[TestFixture]
public partial class TestSceneBackdropPoolDrawable : GameApplicationTestScene
{
    private BackdropPoolDrawable? backdropPool;

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        Add(backdropPool = new BackdropPoolDrawable
        {
            CreateSpriteCallback = () => new BackdropSprite
            {
                Texture = textures.Get(@"Backgrounds/Overworld/rocks")
            }
        });

        AddStep("start backdrop", backdropPool.Start);
        AddStep("freeze backdrop", backdropPool.Freeze);
    }
}
