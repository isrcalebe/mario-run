using mario.Game.Graphics.Playables;
using osu.Framework.Graphics.Containers;

namespace mario.Game.Gameplay;

public partial class MarioPlayableDrawable : CompositeDrawable
{
    private MarioAnimationDrawable? animation;

    [BackgroundDependencyLoader]
    private void load()
    {
        Size = new Vector2(16.0f);

        AddRangeInternal(new Drawable[]
        {
            animation = new MarioAnimationDrawable
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            }
        });
    }
}
