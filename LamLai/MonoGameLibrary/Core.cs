using System;
using System.Reflection.PortableExecutable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace   MonogmaeLibrary;
public class Core : Game
{
    internal static Core s_instance;
    public static Core Instance => s_instance;

    public static GraphicsDeviceManager Graphics{get;private set;}
    public static GraphicsDevice Graphics{get;private set;}

    public static SpriteBatch SpriteBatch{get;private set;}

    public static ContentManager ContentManager{get;private set;}

    public Core(string title,int witdh,int height, bool fullscreen)
    {
        if(s_instance != null)
        {
            throw new InvalidOperationException("djt me may duoc mot core thoi");
        }
    }

}