using mario.Game.Gameplay;
using NUnit.Framework;
using osuTK;

namespace mario.Game.Tests.Visual.Elements;

[TestFixture]
public partial class TestScenePhysicalGroundDrawable : GameApplicationTestScene
{
    private PhysicalGroundDrawable? physicalGround;

    [BackgroundDependencyLoader]
    private void load()
    {
        physicalGround = new PhysicalGroundDrawable
        {
            RelativeSizeAxes = Axes.Both,
            Size = Vector2.One,
        };

        Add(physicalGround);

        AddStep("start backdrop", physicalGround.Start);
        AddStep("freeze backdrop", physicalGround.Freeze);

        AddToggleStep("toggle collision quad", state =>
        {
            if (state)
                physicalGround.ShowCollisionQuad();
            else
                physicalGround.HideCollisionQuad();
        });
    }
}
