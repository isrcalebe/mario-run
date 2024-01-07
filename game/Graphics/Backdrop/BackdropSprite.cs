using System;
using osu.Framework.Graphics.Sprites;

namespace mario.Game.Graphics.Backdrop;

public partial class BackdropSprite : Sprite
{
    public BackdropSprite()
    {
        Anchor = Anchor.TopLeft;
        Origin = Anchor.TopLeft;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        RelativeSizeAxes = Axes.Y;
        Height = 1.0f;
    }

    protected override void Update()
    {
        var size = Texture.Size;
        var aspectRatio = size.X / size.Y;

        Width = (float)Math.Ceiling(DrawHeight * aspectRatio);

        base.Update();
    }
}
