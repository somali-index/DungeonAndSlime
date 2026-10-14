using System;
using System.ComponentModel;
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
   public static new GraphicsDevice GraphicsDevice{get;private set;}

   public static SpriteBatch SpriteBatch{get;private set;}

   public static new ContentManager Content{get;private set;}

   public Core(string title, int Witdh,int Heigth,bool IsFullScreen)
    {
        if(s_instance != null)
            throw new InvalidOperationException("Da ton tai 1 Core");

        s_instance = this;

        Graphics = new GraphicsDeviceManager(this);

        Graphics.PreferredBackBufferHeight=Heigth;
        Graphics.PreferredBackBufferWidth=Witdh;
        Graphics.IsFullScreen = IsFullScreen;

        Graphics.ApplyChanges();

        Window.Title = title;

        Content = base.Content;

        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        GraphicsDevice = base.GraphicsDevice;

        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }
}