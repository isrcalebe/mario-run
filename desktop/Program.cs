using mario.Game;
using osu.Framework;

using var host = Host.GetSuitableDesktopHost(@"mario-run");
using var game = new GameApplication();

host.Run(game);
