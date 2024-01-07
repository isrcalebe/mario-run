using osu.Framework.Graphics.Shapes;

namespace mario.Game.Graphics.UI;

public sealed partial class ScreenFlashDrawable : Box
{
    public override Axes RelativeSizeAxes => Axes.Both;

    public ScreenFlashDrawable()
    {
        Alpha = 0.0f;
    }

    public void Flash(double fadeInDuration, double fadeOutDuration)
        => this.FadeIn(fadeInDuration).Then()
               .FadeOut(fadeOutDuration);
}
