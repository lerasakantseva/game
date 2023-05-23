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
    static class Play
    {
        public static Texture2D student;
        public static Texture2D road;
        public static Texture2D evilStudent;
        public static SpriteBatch spriteBatch;
        public static Vector2 position = new Vector2(0,420);
        public static float speed = 7f;
        public static Point goodSpriteSize;
        public static Texture2D car;
        public static Texture2D car2;
        public static Vector2 evilPosition = new Vector2(0,1150);
        public static Vector2 evilStudentPosition = new Vector2(0, 1000);
        public static Vector2 evilPositionTwo = new Vector2(0, 1550);
        public static float evilSpriteSpeed = -3f;
        public static float evilStudentSpeed = -4.5f;
        public static float evilSpriteSpeedTwo = -6f;
        public static Random rand = new Random();
        public static Vector2 direction;

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(road, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(student, position, Color.White);
            spriteBatch.Draw(car, evilPosition, Color.White);
            spriteBatch.Draw(car2, evilPositionTwo, Color.White);
            spriteBatch.Draw(evilStudent, evilStudentPosition, Color.White);
        }
        public static int GetIntRndSpeed(int maxValue, int minValue)
        {
            return rand.Next(maxValue, minValue);
        }

        public static int GetIntRnd(int maxValue)
        {
            return rand.Next(maxValue);
        }
        static public void Update()
        {
            evilPosition.X += evilSpriteSpeed;
            
            if (evilPosition.X < 0 - car.Width - 50)
            {
                evilPosition = new Vector2(1150, GetIntRnd(700));
                evilSpriteSpeed = -GetIntRndSpeed(4,10);
            }

            evilPositionTwo.X += evilSpriteSpeedTwo;

            if (evilPositionTwo.X < 0 - car2.Width - 50)
            {
                evilPositionTwo = new Vector2(1150, GetIntRnd(700));
                evilSpriteSpeedTwo = -GetIntRndSpeed(4, 10);
            }

            evilStudentPosition.X += evilStudentSpeed;
            if (evilStudentPosition.X < 0 - evilStudent.Width - 50)
            {
                evilStudentPosition = new Vector2(1150, GetIntRnd(700));
                evilStudentSpeed = -GetIntRndSpeed(4, 10);
            }

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                position.X -= speed;
            if (keyboardState.IsKeyDown(Keys.Right))
                position.X += speed;
            if (keyboardState.IsKeyDown(Keys.Up))
                position.Y -= speed;
            if (keyboardState.IsKeyDown(Keys.Down))
                position.Y += speed;

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > 1200 - goodSpriteSize.X)
                position.X = 1200 - goodSpriteSize.X;
            if (position.Y > 1000 - goodSpriteSize.Y)
                position.Y = 1000 - goodSpriteSize.Y;
        }
    }

}
