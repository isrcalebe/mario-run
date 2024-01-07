using mario.Game.Graphics.Backgrounds;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.Backgrounds;

[TestFixture]
public partial class TestSceneParallaxBackgroundDrawable : GameApplicationTestScene
{
    private ParallaxBackgroundDrawable? parallaxBackground;

    [BackgroundDependencyLoader]
    private void load()
    {
        Add(parallaxBackground = new ParallaxBackgroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One
        });

        AddToggleStep("toggle backdrop", state =>
        {
            if (state)
                parallaxBackground.Start();
            else
                parallaxBackground.Freeze();
        });
    }
}
