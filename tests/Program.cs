using mario.Game.Tests;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost(@"mario-run-visual-tests", new HostOptions
{
    PortableInstallation = true
});
using var game = new GameApplicationTestBrowser();

host.Run(game);
