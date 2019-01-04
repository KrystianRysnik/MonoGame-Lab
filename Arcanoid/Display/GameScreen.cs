using Arcanoid.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Arcanoid.Display
{
    class GameScreen : Screen
    {
        Paddle paddle;
        Ball ball;

        int brickWide = 10;
        int brickHigh = 6;
        Texture2D brickImage;

        Texture2D gameover;

        // 0 - easy, 1 - medium, 2 - hard
        int level = 0;

        Game1 g = new Game1();
        TextureAtlases textureAtlases;
               
        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            gameover = theContent.Load<Texture2D>("Image/gameover");

            Texture2D tempTexture = theContent.Load<Texture2D>("Texture/paddle");
            paddle = new Paddle(tempTexture, screenRectangle);

            tempTexture = theContent.Load<Texture2D>("Texture/ball");
            ball = new Ball(tempTexture, screenRectangle);

            brickImage = theContent.Load<Texture2D>("Texture/brick");

            textureAtlases = new TextureAtlases(brickImage, 6, 10);
        }

        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                if (isGameOver == true)
                    StartGame();

            paddle.Update();
            ball.Update();

            foreach (Brick brick in textureAtlases.Bricks)
                    brick.CheckCollision(ball);

            ball.PaddleCollision(paddle.GetBounds());

            if (ball.IsGameOver())
                isGameOver = true;

            if (textureAtlases.NoMoreBricks())
                isGameOver = true;

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            textureAtlases.Draw(theBatch);       
            paddle.Draw(theBatch);
            ball.Draw(theBatch);

            if (isGameOver == true)
            {
                theBatch.Draw(gameover, new Vector2((g.screenRectangle.Width - gameover.Width)/2, (g.screenRectangle.Height - gameover.Height)/2), Color.White);
            }
            base.Draw(theBatch);
        }
        public void StartGame()
        { 
            paddle.SetInStartPosition();
            ball.SetInStartPosition(paddle.GetBounds());

            textureAtlases.SetInStartPosition();
           
            isGameStarted = true;
            isGameOver = false;
        }
    }
}
