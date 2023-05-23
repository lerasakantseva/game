using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    static class Finaly
    {
        public static Texture2D redScreen;
        public static SpriteBatch spriteBatch;
        public static Rectangle rectangleContinue = new Rectangle(370, 150, 450, 100);
        public static MouseState mouseState;


        public static void Draw(SpriteBatch spriteBatch)
        {
            mouseState = Mouse.GetState();
            spriteBatch.Draw(redScreen, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(SplashScreen.font, "Провал", new Vector2(450,0), Color.Black);
            spriteBatch.DrawString(SplashScreen.font, "Начать сначала", new Vector2(370, 150), Color.Black);
            if (rectangleContinue.Contains(new Point(mouseState.X,mouseState.Y))
                && (mouseState.LeftButton == ButtonState.Released))
                spriteBatch.DrawString(SplashScreen.font, "Начать сначала", new Vector2(370, 150), Color.White);
        }

        public static void Update()
        {

        }
    }
}
