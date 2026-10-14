using System;
using System.Collections.Generic;

namespace MonoGameLibrary.Graphics;

public class Animation 
{
    /// <summary>
    /// Các vùng texture tạo thành những khung hình của hoạt ảnh.
    /// Thứ tự các vùng texture trong danh sách cũng chính là thứ tự
    /// các khung hình được hiển thị.
    /// </summary>
    public List<TextureRegion> Frames { get; set; }

    /// <summary>
    /// Khoảng thời gian chờ giữa mỗi khung hình trước khi chuyển
    /// sang khung hình tiếp theo của hoạt ảnh.
    /// </summary>
    public TimeSpan Delay { get; set; }

    /// <summary>
    /// Tạo một hoạt ảnh mới.
    /// </summary>
    public Animation()
    {
        Frames = new List<TextureRegion>();
        Delay = TimeSpan.FromMilliseconds(100);
    }

    /// <summary>
    /// Tạo một hoạt ảnh mới với các khung hình và khoảng thời gian chờ được chỉ định.
    /// </summary>
    /// <param name="frames">Danh sách các khung hình của hoạt ảnh theo đúng thứ tự.</param>
    /// <param name="delay">Khoảng thời gian chờ giữa mỗi khung hình của hoạt ảnh.</param>
    public Animation(List<TextureRegion> frames, TimeSpan delay)
    {
        Frames = frames;
        Delay = delay;
    }


}
