using mario.Game.Graphics.UI;
using NUnit.Framework;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osuTK;

namespace mario.Game.Tests.Visual.UI;

[TestFixture]
public partial class TestSceneScreenFlashDrawable : GameApplicationTestScene
{
    private ScreenFlashDrawable? screenFlash;

    private BasicHexColourPicker? colourPicker;
    private BasicButton? flashButton;

    private double fadeInDuration, fadeOutDuration;

    [BackgroundDependencyLoader]
    private void load()
    {
        AddRange(new Drawable[]
        {
            screenFlash = new ScreenFlashDrawable(),
            new FillFlowContainer
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Direction = FillDirection.Vertical,
                RelativeSizeAxes = Axes.Both,
                Position = new Vector2(0.1f),
                Children = new Drawable[]
                {
                    colourPicker = new BasicHexColourPicker(),
                    flashButton = new BasicButton
                    {
                        Size = new Vector2(300.0f, 60.0f),
                        Text = "Flash"
                    }
                }
            },
        });

        AddSliderStep("set fade in duration", 0.0d, 2000.0d, 0.0d, e =>
            fadeInDuration = e);

        AddSliderStep("set fade out duration", 0.0d, 2000.0d, 700.0d, e =>
            fadeOutDuration = e);

        colourPicker.Current.Default = Colour4.White;
        colourPicker.Current.BindValueChanged(onNextColour, true);

        flashButton.Action += () => screenFlash.Flash(fadeInDuration, fadeOutDuration);
    }

    private void onNextColour(ValueChangedEvent<Colour4> e)
    {
        if (screenFlash != null)
            screenFlash.Colour = e.NewValue;
    }
}
