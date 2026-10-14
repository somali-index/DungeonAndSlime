using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

public class Sprite
{
    /// <summary>
    /// Lấy hoặc thiết lập vùng texture nguồn được đại diện bởi sprite này.
    /// </summary>
    public TextureRegion Region { get; set; }

    /// <summary>
    /// Lấy hoặc thiết lập màu phủ được áp dụng khi vẽ sprite này.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là Color.White.
    /// </remarks>
    public Color Color { get; set; } = Color.White;

    /// <summary>
    /// Lấy hoặc thiết lập góc xoay, tính bằng radian, được áp dụng khi vẽ sprite này.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là 0.0f.
    /// </remarks>
    public float Rotation { get; set; } = 0.0f;

    /// <summary>
    /// Lấy hoặc thiết lập hệ số co giãn theo trục X và trục Y khi vẽ sprite này.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là Vector2.One.
    /// </remarks>
    public Vector2 Scale { get; set; } = Vector2.One;

    /// <summary>
    /// Lấy hoặc thiết lập điểm gốc tọa độ X và Y của sprite này,
    /// tính tương đối so với góc trên bên trái.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là Vector2.Zero.
    /// </remarks>
    public Vector2 Origin { get; set; } = Vector2.Zero;

    /// <summary>
    /// Lấy hoặc thiết lập các hiệu ứng sprite được áp dụng khi vẽ sprite này.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là SpriteEffects.None.
    /// </remarks>
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;

    /// <summary>
    /// Lấy hoặc thiết lập độ sâu của lớp được áp dụng khi vẽ sprite này.
    /// </summary>
    /// <remarks>
    /// Giá trị mặc định là 0.0f.
    /// </remarks>
    public float LayerDepth { get; set; } = 0.0f;

    /// <summary>
    /// Lấy chiều rộng của sprite này, tính bằng pixel.
    /// </summary>
    /// <remarks>
    /// Chiều rộng được tính bằng cách nhân chiều rộng của vùng texture nguồn
    /// với hệ số co giãn theo trục X.
    /// </remarks>
    public float Width => Region.Width * Scale.X;

    /// <summary>
    /// Lấy chiều cao của sprite này, tính bằng pixel.
    /// </summary>
    /// <remarks>
    /// Chiều cao được tính bằng cách nhân chiều cao của vùng texture nguồn
    /// với hệ số co giãn theo trục Y.
    /// </remarks>
    public float Height => Region.Height * Scale.Y;

    /// <summary>
    /// Tạo một sprite mới.
    /// </summary>
    public Sprite() { }

    /// <summary>
    /// Tạo một sprite mới bằng cách sử dụng vùng texture nguồn được chỉ định.
    /// </summary>
    /// <param name="region">Vùng texture được sử dụng làm vùng texture nguồn cho sprite này.</param>
    public Sprite(TextureRegion region)
    {
        Region = region;
    }

    /// <summary>
    /// Đặt điểm gốc của sprite tại chính giữa.
    /// </summary>
    public void CenterOrigin()
    {
        Origin = new Vector2(Region.Width, Region.Height) * 0.5f;
    }

    /// <summary>
    /// Đưa sprite này vào batch hiện tại để vẽ.
    /// </summary>
    /// <param name="spriteBatch">Đối tượng SpriteBatch được sử dụng để gom các lệnh vẽ.</param>
    /// <param name="position">Vị trí tọa độ X và Y để vẽ sprite này.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Region.Draw(spriteBatch, position, Color, Rotation, Origin, Scale, Effects, LayerDepth);
    }
}