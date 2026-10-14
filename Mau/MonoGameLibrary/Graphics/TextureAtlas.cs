using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonoGameLibrary.Graphics;
using System;



namespace MonoGameLibrary;

public class TextureAtlas
{
    // Lưu trữ các hoạt ảnh được thêm vào atlas này.
    private Dictionary<string, Animation> _animations;
    private Dictionary<string,TextureRegion> _regions;

    public Texture2D Texture{get;set;}

    /// <summary>
    /// Tạo một texture atlas mới.
    /// </summary>
    public TextureAtlas()
    {
        _regions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string, Animation>();
    }

    /// <summary>
    /// Tạo một đối tượng texture atlas mới bằng texture được cung cấp.
    /// </summary>
    /// <param name="texture">Texture nguồn được biểu diễn bởi texture atlas.</param>
    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        _regions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string, Animation>();
    }
    

    /// <summary>
    /// Tạo một vùng texture mới và thêm nó vào Texture Atlas này.
    /// </summary>
    /// <param name="name">Tên của vùng texture.</param>
    /// <param name="x">Tọa độ X của góc trên bên trái vùng texture, tính tương đối so với góc trên bên trái của texture nguồn.</param>
    /// <param name="y">Tọa độ Y của góc trên bên trái vùng texture, tính tương đối so với góc trên bên trái của texture nguồn.</param>
    /// <param name="width">Chiều rộng của vùng texture, tính bằng pixel.</param>
    /// <param name="height">Chiều cao của vùng texture, tính bằng pixel.</param>
    public void AddRegion(string name, int x, int y, int width, int height)
    {
        TextureRegion region = new TextureRegion(Texture, x, y, width, height);
        _regions.Add(name, region);
    }

    /// <summary>
    /// Lấy vùng texture trong Texture Atlas theo tên được chỉ định.
    /// </summary>
    /// <param name="name">Tên của vùng texture cần lấy.</param>
    /// <returns>Đối tượng TextureRegion có tên được chỉ định.</returns>
    public TextureRegion GetRegion(string name)
    {
        return _regions[name];
    }

    /// <summary>
    /// Xóa vùng texture khỏi Texture Atlas theo tên được chỉ định.
    /// </summary>
    /// <param name="name">Tên của vùng texture cần xóa.</param>
    /// <returns></returns>
    public bool RemoveRegion(string name)
    {
        return _regions.Remove(name);
    }

    /// <summary>
    /// Xóa tất cả các vùng texture khỏi Texture Atlas này.
    /// </summary>
    public void Clear()
    {
        _regions.Clear();
    }

    /// <summary>
    /// Tạo một texture atlas mới dựa trên tệp cấu hình XML của texture atlas.
    /// </summary>
    /// <param name="content">Content Manager được sử dụng để tải texture cho atlas.</param>
    /// <param name="fileName">Đường dẫn đến tệp XML, tính từ thư mục gốc của Content.</param>
    /// <returns>Texture atlas được tạo bởi phương thức này.</returns>
    public static TextureAtlas FromFile(ContentManager content, string fileName)
    {
        TextureAtlas atlas = new TextureAtlas();

        string filePath = Path.Combine(content.RootDirectory, fileName);

        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;

                // Phần tử <Texture> chứa đường dẫn nội dung của Texture2D cần tải.
                // Vì vậy, chúng ta sẽ lấy giá trị đó rồi sử dụng Content Manager để tải texture.
                string texturePath = root.Element("Texture").Value;
                atlas.Texture = content.Load<Texture2D>(texturePath);

                // Phần tử <Regions> chứa các phần tử <Region> riêng lẻ, mỗi phần tử mô tả
                // một vùng texture khác nhau bên trong atlas.
                //
                // Ví dụ:
                // <Regions>
                //      <Region name="spriteOne" x="0" y="0" width="32" height="32" />
                //      <Region name="spriteTwo" x="32" y="0" width="32" height="32" />
                // </Regions>
                //
                // Vì vậy, chúng ta lấy tất cả các phần tử <Region>, sau đó duyệt qua từng phần tử,
                // tạo một đối tượng TextureRegion mới từ phần tử đó và thêm nó vào atlas này.
                var regions = root.Element("Regions")?.Elements("Region");

                if (regions != null)
                {
                    foreach (var region in regions)
                    {
                        string name = region.Attribute("name")?.Value;
                        int x = int.Parse(region.Attribute("x")?.Value ?? "0");
                        int y = int.Parse(region.Attribute("y")?.Value ?? "0");
                        int width = int.Parse(region.Attribute("width")?.Value ?? "0");
                        int height = int.Parse(region.Attribute("height")?.Value ?? "0");

                        if (!string.IsNullOrEmpty(name))
                        {
                            atlas.AddRegion(name, x, y, width, height);
                        }
                    }
                }

                // Phần tử <Animations> chứa các phần tử <Animation> riêng lẻ, mỗi phần tử mô tả
                // một hoạt ảnh khác nhau bên trong atlas.
                //
                // Ví dụ:
                // <Animations>
                //      <Animation name="animation" delay="100">
                //          <Frame region="spriteOne" />
                //          <Frame region="spriteTwo" />
                //      </Animation>
                // </Animations>
                //
                // Vì vậy, chúng ta lấy tất cả các phần tử <Animation>, sau đó duyệt qua từng phần tử,
                // tạo một đối tượng Animation mới từ phần tử đó và thêm nó vào atlas này.
                var animationElements = root.Element("Animations").Elements("Animation");

                if (animationElements != null)
                {
                    foreach (var animationElement in animationElements)
                    {
                        string name = animationElement.Attribute("name")?.Value;
                        float delayInMilliseconds = float.Parse(animationElement.Attribute("delay")?.Value ?? "0");
                        TimeSpan delay = TimeSpan.FromMilliseconds(delayInMilliseconds);

                        List<TextureRegion> frames = new List<TextureRegion>();

                        var frameElements = animationElement.Elements("Frame");

                        if (frameElements != null)
                        {
                            foreach (var frameElement in frameElements)
                            {
                                string regionName = frameElement.Attribute("region").Value;
                                TextureRegion region = atlas.GetRegion(regionName);
                                frames.Add(region);
                            }
                        }

                        Animation animation = new Animation(frames, delay);
                        atlas.AddAnimation(name, animation);
                    }
                }

                return atlas;
            }
        }
    }

    /// <summary>
    /// Tạo một sprite mới bằng cách sử dụng vùng texture có tên được chỉ định trong Texture Atlas này.
    /// </summary>
    /// <param name="regionName">Tên của vùng texture được sử dụng để tạo sprite.</param>
    /// <returns>Một sprite mới sử dụng vùng texture có tên được chỉ định.</returns>
    public Sprite CreateSprite(string regionName)
    {
        TextureRegion region = GetRegion(regionName);
        return new Sprite(region);
    }

    /// <summary>
    /// Thêm hoạt ảnh được cung cấp vào texture atlas này với tên được chỉ định.
    /// </summary>
    /// <param name="animationName">Tên của hoạt ảnh cần thêm.</param>
    /// <param name="animation">Hoạt ảnh cần thêm.</param>
    public void AddAnimation(string animationName, Animation animation)
    {
        _animations.Add(animationName, animation);
    }

    /// <summary>
    /// Lấy hoạt ảnh từ texture atlas này theo tên được chỉ định.
    /// </summary>
    /// <param name="animationName">Tên của hoạt ảnh cần lấy.</param>
    /// <returns>Hoạt ảnh có tên được chỉ định.</returns>
    public Animation GetAnimation(string animationName)
    {
        return _animations[animationName];
    }

    /// <summary>
    /// Xóa hoạt ảnh có tên được chỉ định khỏi texture atlas này.
    /// </summary>
    /// <param name="animationName">Tên của hoạt ảnh cần xóa.</param>
    /// <returns>true nếu hoạt ảnh được xóa thành công; ngược lại, false.</returns>
    public bool RemoveAnimation(string animationName)
    {
        return _animations.Remove(animationName);
    }

        /// <summary>
    /// Tạo một sprite có hoạt ảnh mới bằng cách sử dụng hoạt ảnh có tên được chỉ định trong texture atlas này.
    /// </summary>
    /// <param name="animationName">Tên của hoạt ảnh cần sử dụng.</param>
    /// <returns>Một AnimatedSprite mới sử dụng hoạt ảnh có tên được chỉ định.</returns>
    public AnimatedSprite CreateAnimatedSprite(string animationName)
    {
        Animation animation = GetAnimation(animationName);
        return new AnimatedSprite(animation);
    }

}