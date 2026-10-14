using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace Dungeon_and_Slime;

public class Game1 : Core
{
    // Khai báo sprite slime có hoạt ảnh.
    private AnimatedSprite _slime;

    // Khai báo sprite dơi có hoạt ảnh.
    private AnimatedSprite _bat;



    public Game1(): base("Dungeon and Slime",1280,720,false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Tạo Texture Atlas từ file cấu hình XML.
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // Tạo sprite slime từ  Atlas.
        _slime = atlas.CreateAnimatedSprite("slime-animation");
        _slime.Scale = new Vector2(4.0f, 4.0f);

        // Tạo sprite bat (con dơi) từ  Atlas.
            _bat = atlas.CreateAnimatedSprite("bat-animation");
        _bat.Scale = new Vector2(4.0f, 4.0f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        // Cập nhật sprite slime có hoạt ảnh.
        _slime.Update(gameTime);

        // Cập nhật sprite dơi có hoạt ảnh.
        _bat.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here

        // Bắt đầu SpriteBatch để chuẩn bị vẽ các hình ảnh lên màn hình.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        // Vẽ sprite slime.
        _slime.Draw(SpriteBatch, Vector2.Zero);

        // Vẽ sprite bat (con dơi) ở bên phải slime 10 pixel.
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

        SpriteBatch.End();
    

        base.Draw(gameTime);
    }
}
