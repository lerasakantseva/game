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
    static class Pause
    {
        public static MouseState mouseState;
        public static Texture2D pause;
        public static SpriteBatch spriteBatch;
        public static Rectangle rectangleContinue = new Rectangle(10, 150, 560, 100);
        public static Rectangle rectangleExitInPause = new Rectangle(10, 350, 600, 100);
    

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SplashScreen.BackGround, new Vector2(0,0), Color.White);
            mouseState = Mouse.GetState();
            spriteBatch.Draw(SplashScreen.BackGround, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(SplashScreen.font, "Пауза", new Vector2(30, 10), Color.OrangeRed);
            spriteBatch.DrawString(SplashScreen.font, "Продолжить играть", new Vector2(10, 150), Color.Black);
            spriteBatch.DrawString(SplashScreen.font, "Выход в главное меню", new Vector2(10,350), Color.Black);
            if (rectangleContinue.Contains(new Point(mouseState.X, mouseState.Y))
                && (mouseState.LeftButton == ButtonState.Released))
                spriteBatch.DrawString(SplashScreen.font, "Продолжить играть", new Vector2(10, 150), Color.Green);
            if (rectangleExitInPause.Contains(new Point(mouseState.X, mouseState.Y))
                && (mouseState.LeftButton == ButtonState.Released))
                spriteBatch.DrawString(SplashScreen.font, "Выход в главное меню", new Vector2(10, 350), Color.Red);
        }

        public static void Update()
        {

        }
    }
}
