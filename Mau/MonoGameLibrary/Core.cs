using System; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Content; 
using Microsoft.Xna.Framework.Graphics; 
 
namespace MonoGameLibrary; 
 
public class Core : Game 
{ 
    internal static Core s_instance; 
 
    /// <summary> 
    /// Lấy một tham chiếu đến Core instance. 
    /// </summary> 
    public static Core Instance => s_instance; 
 
    /// <summary> 
    /// Lấy Graphics Device Manager để điều khiển việc hiển thị đồ họa. 
    /// </summary> 
    public static GraphicsDeviceManager Graphics { get; private set; } 
 
    /// <summary> 
    /// Lấy Graphics Device được sử dụng để tạo các tài nguyên đồ họa và thực hiện việc render các đối tượng cơ bản. 
    /// </summary> 
    public static new GraphicsDevice GraphicsDevice { get; private set; } 
 
    /// <summary> 
    /// Lấy Sprite Batch được sử dụng cho toàn bộ việc render 2D. 
    /// </summary> 
    public static SpriteBatch SpriteBatch { get; private set; } 
 
    /// <summary> 
    /// Lấy Content Manager được sử dụng để tải các tài nguyên dùng chung. 
    /// </summary> 
    public static new ContentManager Content { get; private set; } 
 
    /// <summary> 
    /// Tạo một Core instance mới. 
    /// </summary> 
    /// <param name="title">Tiêu đề hiển thị trên thanh tiêu đề của cửa sổ game.</param> 
    /// <param name="width">Chiều rộng ban đầu của cửa sổ game, tính bằng pixel.</param> 
    /// <param name="height">Chiều cao ban đầu của cửa sổ game, tính bằng pixel.</param> 
    /// <param name="fullScreen">Xác định game có khởi động ở chế độ toàn màn hình hay không.</param> 
    public Core(string title, int width, int height, bool fullScreen) 
    { 
        // Đảm bảo không có nhiều Core được tạo. 
        if (s_instance != null) 
        { 
            throw new InvalidOperationException($"Only a single Core instance can be created"); 
        } 
 
        // Lưu tham chiếu đến engine để có thể truy cập các thành phần thành viên từ mọi nơi. 
        s_instance = this; 
 
        // Tạo một Graphics Device Manager mới. 
        Graphics = new GraphicsDeviceManager(this); 
 
        // Thiết lập các giá trị mặc định cho đồ họa. 
        Graphics.PreferredBackBufferWidth = width; 
        Graphics.PreferredBackBufferHeight = height; 
        Graphics.IsFullScreen = fullScreen; 
 
        // Áp dụng các thay đổi về cách hiển thị đồ họa. 
        Graphics.ApplyChanges(); 
 
        // Thiết lập tiêu đề của cửa sổ. 
        Window.Title = title; 
 
        // Thiết lập Content Manager của Core thành một tham chiếu đến Content Manager 
        // của lớp Game cơ sở. 
        Content = base.Content; 
 
        // Thiết lập thư mục gốc cho các tài nguyên. 
        Content.RootDirectory = "Content"; 
 
        // Chuột được hiển thị theo mặc định. 
        IsMouseVisible = true; 
    } 
 
    protected override void Initialize() 
    { 
        base.Initialize(); 
 
        // Thiết lập Graphics Device của Core thành một tham chiếu đến Graphics Device 
        // của lớp Game cơ sở. 
        GraphicsDevice = base.GraphicsDevice; 
 
        // Tạo một Sprite Batch instance. 
        SpriteBatch = new SpriteBatch(GraphicsDevice); 
    } 
}