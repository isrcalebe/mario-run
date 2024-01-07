using System;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace mario.Game.Graphics.Backdrop;

public sealed partial class BackdropPoolDrawable : CompositeDrawable
{
    public Func<Sprite>? CreateSpriteCallback { get; init; }

    public double Duration { get; set; } = 2000.0d;

    public bool Running { get; private set; }

    public override Axes RelativeSizeAxes => Axes.Both;

    public override Vector2 Size => Vector2.One;

    private Vector2 lastSize;

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(CreateSpriteCallback?.Invoke());
    }

    public void Start()
    {
        if (Running) return;

        Running = true;
        updateLayout();
    }

    public void Freeze()
    {
        if (!Running) return;

        Running = false;
        stopAnimatingChildren();
    }

    protected override void UpdateAfterChildren()
    {
        base.UpdateAfterChildren();

        if (DrawSize.Equals(lastSize)) return;

        updateLayout();
        lastSize = DrawSize;
    }

    private void updateLayout()
    {
        var sprite = (Sprite)InternalChildren[0];
        var spriteCount = (int)Math.Ceiling(DrawWidth / sprite.DrawWidth) + 1;

        var offset = 0.0f;

        if (spriteCount != InternalChildren.Count)
        {
            while (InternalChildren.Count > spriteCount)
                RemoveInternal(InternalChildren[^1], true);

            while (InternalChildren.Count < spriteCount)
                AddInternal(CreateSpriteCallback?.Invoke());
        }

        foreach (var childSprite in InternalChildren)
        {
            var width = childSprite.DrawWidth * sprite.Scale.X;
            childSprite.Position = new Vector2(offset, childSprite.Position.Y);

            var fromVector = new Vector2(offset, childSprite.Y);
            var toVector = new Vector2(offset - width, childSprite.Y);

            if (Running)
            {
                childSprite.Loop(backdrop => backdrop
                                             .MoveTo(fromVector)
                                             .MoveTo(toVector, Duration));
            }

            offset += width - 1;
        }
    }

    private void stopAnimatingChildren()
        => ClearTransforms(true);
}
