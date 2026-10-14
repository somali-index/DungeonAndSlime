using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;


public class TextureRegion
{
    /// <summary>
    /// Lấy hoặc thiết lập texture nguồn mà vùng texture này thuộc về.
    /// </summary>
    public Texture2D Texture { get; set; }

    /// <summary>
    /// Lấy hoặc thiết lập hình chữ nhật xác định ranh giới của vùng texture
    /// bên trong texture nguồn.
    /// </summary>
    public Rectangle SourceRectangle { get; set; }

    /// <summary>
    /// Lấy chiều rộng, tính bằng pixel, của vùng texture này.
    /// </summary>
    public int Width => SourceRectangle.Width;

    /// <summary>
    /// Lấy chiều cao, tính bằng pixel, của vùng texture này.
    /// </summary>
    public int Height => SourceRectangle.Height;

    /// <summary>
    /// Tạo một vùng texture mới.
    /// </summary>
    public TextureRegion() { }

    /// <summary>
    /// Tạo một vùng texture mới bằng cách sử dụng texture nguồn được chỉ định.
    /// </summary>
    /// <param name="texture">Texture được sử dụng làm texture nguồn cho vùng texture này.</param>
    /// <param name="x">Tọa độ X của góc trên bên trái của vùng texture, tính tương đối so với góc trên bên trái của texture nguồn.</param>
    /// <param name="y">Tọa độ Y của góc trên bên trái của vùng texture, tính tương đối so với góc trên bên trái của texture nguồn.</param>
    /// <param name="width">Chiều rộng của vùng texture, tính bằng pixel.</param>
    /// <param name="height">Chiều cao của vùng texture, tính bằng pixel.</param>
    public TextureRegion(Texture2D texture, int x, int y, int width, int height)
    {
        Texture = texture;
        SourceRectangle = new Rectangle(x, y, width, height);
    }

    /// <summary>
    /// Đưa vùng texture này vào batch hiện tại để vẽ.
    /// </summary>
    /// <param name="spriteBatch">Đối tượng SpriteBatch được sử dụng để gom các lệnh vẽ.</param>
    /// <param name="position">Vị trí tọa độ X và Y để vẽ vùng texture này lên màn hình.</param>
    /// <param name="color">Màu sắc được áp dụng lên vùng texture khi vẽ trên màn hình.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        Draw(spriteBatch, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
    }

    /// <summary>
    /// Đưa vùng texture này vào batch hiện tại để vẽ.
    /// </summary>
    /// <param name="spriteBatch">Đối tượng SpriteBatch được sử dụng để gom các lệnh vẽ.</param>
    /// <param name="position">Vị trí tọa độ X và Y để vẽ vùng texture này lên màn hình.</param>
    /// <param name="color">Màu sắc được áp dụng lên vùng texture khi vẽ trên màn hình.</param>
    /// <param name="rotation">Góc xoay được áp dụng khi vẽ vùng texture trên màn hình, tính bằng radian.</param>
    /// <param name="origin">Điểm gốc dùng làm tâm xoay, tâm co giãn và điểm tham chiếu vị trí khi vẽ vùng texture.</param>
    /// <param name="scale">Hệ số co giãn được áp dụng khi vẽ vùng texture trên màn hình.</param>
    /// <param name="effects">Xác định vùng texture có bị lật theo chiều ngang, chiều dọc hoặc cả hai khi vẽ hay không.</param>
    /// <param name="layerDepth">Độ sâu của lớp được sử dụng khi vẽ vùng texture trên màn hình.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
    {
        Draw(
            spriteBatch,
            position,
            color,
            rotation,
            origin,
            new Vector2(scale, scale),
            effects,
            layerDepth
        );
    }

    /// <summary>
    /// Đưa vùng texture này vào batch hiện tại để vẽ.
    /// </summary>
    /// <param name="spriteBatch">Đối tượng SpriteBatch được sử dụng để gom các lệnh vẽ.</param>
    /// <param name="position">Vị trí tọa độ X và Y để vẽ vùng texture này lên màn hình.</param>
    /// <param name="color">Màu sắc được áp dụng lên vùng texture khi vẽ trên màn hình.</param>
    /// <param name="rotation">Góc xoay được áp dụng khi vẽ vùng texture trên màn hình, tính bằng radian.</param>
    /// <param name="origin">Điểm gốc dùng làm tâm xoay, tâm co giãn và điểm tham chiếu vị trí khi vẽ vùng texture.</param>
    /// <param name="scale">Mức độ co giãn theo trục X và trục Y khi vẽ vùng texture trên màn hình.</param>
    /// <param name="effects">Xác định vùng texture có bị lật theo chiều ngang, chiều dọc hoặc cả hai khi vẽ hay không.</param>
    /// <param name="layerDepth">Độ sâu của lớp được sử dụng khi vẽ vùng texture trên màn hình.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        spriteBatch.Draw(
            Texture,
            position,
            SourceRectangle,
            color,
            rotation,
            origin,
            scale,
            effects,
            layerDepth
        );
    }
}