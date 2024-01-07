using mario.Game.Graphics.Backdrops;
using NUnit.Framework;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Tests.Visual.Backdrops;

[TestFixture]
public partial class TestSceneBackdropPoolDrawable : GameApplicationTestScene
{
    private BackdropPoolDrawable? backdropPool;

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        Add(backdropPool = new BackdropPoolDrawable(() => new BackdropSprite
        {
            Texture = textures.Get(@"Backgrounds/Overworld/rocks")
        }));

        AddToggleStep("toggle backdrop", state =>
        {
            if (state)
                backdropPool.Start();
            else
                backdropPool.Freeze();
        });

        AddSliderStep("set backdrop speed", 2000.0d, 20000.0d, 2000.0d, e =>
        {
            backdropPool.Duration = e;
        });
    }
}
