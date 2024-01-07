using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Graphics.UI;

public partial class TitleSprite : CompositeDrawable
{
    private readonly string textureName;

    private Sprite? sprite;

    public override Axes AutoSizeAxes => Axes.Both;

    public TitleSprite(string textureName)
    {
        this.textureName = textureName;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        AddInternal(sprite = new Sprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Scale = new Vector2(3.0f),
            Texture = textures.Get(@$"UI/{textureName}")
        });
    }
}
