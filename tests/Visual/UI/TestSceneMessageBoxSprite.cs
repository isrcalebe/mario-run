using mario.Game.Screens.Menu;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.UI;

[TestFixture]
public partial class TestSceneMessageBoxSprite : GameApplicationTestScene
{
    private MessageBoxSprite? messageBox;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(messageBox = new MessageBoxSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Scale = new Vector2(8.0f)
        });

        AddStep("touch message box", messageBox.Touch);
    }
}
