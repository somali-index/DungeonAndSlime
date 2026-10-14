using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Graphics;

public class AnimatedSprite : Sprite 
{
    private int _currentFrame;
    private TimeSpan _elapsed;
    private Animation _animation;

    /// <summary>
    /// Lấy hoặc thiết lập hoạt ảnh cho sprite có hoạt ảnh này.
    /// </summary>
    public Animation Animation
    {
        get => _animation;
        set
        {
            _animation = value;
            Region = _animation.Frames[0];
        }
    }

    /// <summary>
    /// Tạo một sprite có hoạt ảnh mới.
    /// </summary>
    public AnimatedSprite() { }

    /// <summary>
    /// Tạo một sprite có hoạt ảnh mới với hoạt ảnh được chỉ định.
    /// </summary>
    /// <param name="animation">Hoạt ảnh dành cho sprite này.</param>
    public AnimatedSprite(Animation animation)
    {
        Animation = animation;
    }

    /// <summary>
    /// Cập nhật sprite có hoạt ảnh này.
    /// </summary>
    /// <param name="gameTime">Thông tin về thời gian của trò chơi do framework cung cấp tại thời điểm hiện tại.</param>
    public void Update(GameTime gameTime)
    {
        _elapsed += gameTime.ElapsedGameTime;

        if (_elapsed >= _animation.Delay)
        {
            _elapsed -= _animation.Delay;
            _currentFrame++;

            if (_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
            }

            Region = _animation.Frames[_currentFrame];
        }
    }


}

