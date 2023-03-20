global using osu.Framework.Allocation;
global using osu.Framework.Graphics;
global using osu.Framework.Testing;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;

namespace mario.Game.Tests;

public partial class GameApplicationTestBrowser : GameApplicationBase
{
    protected override void LoadComplete()
    {
        base.LoadComplete();

        AddRange(new Drawable[]
        {
            new TestBrowser("mario.Game.Tests"),
            new CursorContainer()
        });
    }

    public override void SetHost(GameHost host)
    {
        base.SetHost(host);

        host.Window.CursorState |= CursorState.Hidden;
    }
}
