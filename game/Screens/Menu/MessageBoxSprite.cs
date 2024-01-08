using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace mario.Game.Screens.Menu;

public partial class MessageBoxSprite : Sprite
{
    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        Texture = textures.Get(@"UI/message-box");
    }

    public void Touch()
    {
        this.MoveToY(Y - 48.0f, 175.0d)
            .ScaleTo(Scale + new Vector2(1.1f), 175.0d).Then()
            .MoveToY(Y, 175.0d)
            .ScaleTo(Scale, 175.0d);
    }
}
