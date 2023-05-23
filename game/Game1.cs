using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace game 
{
    enum Stat
    {
        SplashScreen,
        Play,
        Pause,
        Finaly
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public  MouseState mouseState;
        public Texture2D game;
        Stat Stat = Stat.SplashScreen;
        Color color = Color.CornflowerBlue;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 1000;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            SplashScreen.rectanglePlay = new Rectangle(200,150,200,100);
            SplashScreen.rectangleExit = new Rectangle(200, 250, 200, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.BackGround = Content.Load<Texture2D>("student");
            SplashScreen.font = Content.Load<SpriteFont>("font");
            Play.student = Content.Load<Texture2D>("runStudent");
            Play.road = Content.Load<Texture2D>("road");
            Play.car = Content.Load<Texture2D>("car");
            Play.car2 = Content.Load<Texture2D>("car2");
            Play.evilStudent = Content.Load<Texture2D>("otherStudent");
            Play.goodSpriteSize = new Point(Play.student.Width, Play.student.Height);
            Pause.pause = Content.Load<Texture2D>("pause");
            Finaly.redScreen = Content.Load<Texture2D>("redScreen");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    if ((mouseState.LeftButton == ButtonState.Pressed) && (SplashScreen.rectanglePlay.Contains(new Point(mouseState.X, mouseState.Y))))
                        Stat = Stat.Play;
                    if ((mouseState.LeftButton == ButtonState.Pressed) && (SplashScreen.rectangleExit.Contains(new Point(mouseState.X, mouseState.Y))))
                        Exit();
                    break;
                case Stat.Play:
                    Play.Update();
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Stat = Stat.Pause;
                    if(Collide(Play.student,Play.car, Play.evilPosition))
                    {
                        Stat = Stat.Finaly;
                    }
                    if (Collide(Play.student, Play.car2, Play.evilPositionTwo))
                    {
                        Stat = Stat.Finaly;
                    }
                    if (Collide(Play.student, Play.evilStudent, Play.evilStudentPosition))
                    {
                        Stat = Stat.Finaly;
                    }
                    break;
                case Stat.Pause:
                    if ((mouseState.LeftButton == ButtonState.Pressed) && (Pause.rectangleExitInPause.Contains(new Point(mouseState.X, mouseState.Y))))
                        Stat = Stat.SplashScreen;
                    if ((mouseState.LeftButton == ButtonState.Pressed) && (Pause.rectangleContinue.Contains(new Point(mouseState.X, mouseState.Y))))
                        Stat = Stat.Play;
                    break;
                case Stat.Finaly:
                    if ((mouseState.LeftButton == ButtonState.Pressed) && (Finaly.rectangleContinue.Contains(new Point(mouseState.X, mouseState.Y))))
                        Stat = Stat.SplashScreen;
                    break;
            }
            
            
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch(Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Play:
                    Play.Draw(spriteBatch);
                    break;
                case Stat.Pause:
                    Pause.Draw(spriteBatch);
                    break;
                case Stat.Finaly:
                    Finaly.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public static bool Collide(Texture2D goodTexture, Texture2D badTexture, Vector2 evilSpritePosition)
        {
            Rectangle goodSpriteRect = new Rectangle((int)Play.position.X,
                (int)Play.position.Y, goodTexture.Width, goodTexture.Height);
            Rectangle evilSpriteRect = new Rectangle((int)evilSpritePosition.X,
                (int)evilSpritePosition.Y, badTexture.Width, badTexture.Height);

            return goodSpriteRect.Intersects(evilSpriteRect);
        }
    }
}