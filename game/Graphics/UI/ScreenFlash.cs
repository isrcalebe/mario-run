using osu.Framework.Graphics.Shapes;

namespace mario.Game.Graphics.UI;

public partial class ScreenFlash : Box
{
    public override Axes RelativeSizeAxes => Axes.Both;

    public ScreenFlash()
    {
        Alpha = 0.0f;
    }

    public virtual void Flash(double fadeInDuration, double fadeOutDuration)
        => this.FadeIn(fadeInDuration).Then()
               .FadeOut(fadeOutDuration);
}
