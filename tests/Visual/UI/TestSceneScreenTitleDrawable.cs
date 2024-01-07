using mario.Game.Graphics.UI;
using NUnit.Framework;

namespace mario.Game.Tests.Visual.UI;

[TestFixture]
public partial class TestSceneScreenTitleDrawable : GameApplicationTestScene
{
    private ScreenTitleDrawable? screenTitle;

    [BackgroundDependencyLoader]
    private void load()
    {
        AddStep("load \"get-ready\"", () =>
        {
            Clear();
            Add(screenTitle = new ScreenTitleDrawable(@"get-ready")
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        });

        AddStep("load \"game-over\"", () =>
        {
            Clear();
            Add(screenTitle = new ScreenTitleDrawable(@"game-over")
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        });
    }
}
