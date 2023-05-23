using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
     static class SplashScreen
    {
        public static Texture2D BackGround { get; set; }
        public static SpriteBatch spriteBatch;
        public static SpriteFont font;
        public static MouseState mouseState;
        public static Rectangle rectanglePlay;
        public static Rectangle rectangleExit;
        public static Texture2D game;


        static public void Draw(SpriteBatch spriteBatch)
        {
            mouseState = Mouse.GetState();
            spriteBatch.Draw(BackGround, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, "Дойти до института", new Vector2(30, 10), Color.OrangeRed);
            spriteBatch.DrawString(font, "Играть", new Vector2(200, 150), Color.Black);
            spriteBatch.DrawString(font, "Выход", new Vector2(200, 250), Color.Black);
            if (rectanglePlay.Contains(new Point(mouseState.X, mouseState.Y))
                && (mouseState.LeftButton == ButtonState.Released))
                spriteBatch.DrawString(font, "Играть", new Vector2(200, 150), Color.Green);
            if (rectangleExit.Contains(new Point(mouseState.X, mouseState.Y))
                && (mouseState.LeftButton == ButtonState.Released))
                spriteBatch.DrawString(font, "Выход", new Vector2(200, 250), Color.Red);
        }
    }
}
