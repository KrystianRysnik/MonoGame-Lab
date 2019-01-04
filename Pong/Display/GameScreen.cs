using Pong.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pong.Display
{
    class GameScreen: Screen
    {
        Paddle paddle, aiPaddle;
        Ball ball;
        Wall wallLeft, wallTop, wallRight;

        Wall[] walls = new Wall[3];
        
        Texture2D gameover;

        SpriteFont scoreFont;
        SpriteFont who;
        int score;
        int height = 140;

        // 0 - easy, 1 - medium, 2 - hard
        int level = 0;

        Boolean isPlayerTurn = true;

        Game1 g = new Game1();
               
        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            scoreFont = theContent.Load<SpriteFont>("Font/Score");
            who = theContent.Load<SpriteFont>("font/Score");
            gameover = theContent.Load<Texture2D>("Image/gameover");

            Texture2D tempTexture = theContent.Load<Texture2D>("Texture/paddle");
            paddle = new Paddle(tempTexture, screenRectangle, Color.Blue);
            aiPaddle = new Paddle(tempTexture, screenRectangle, Color.Red);

            tempTexture = theContent.Load<Texture2D>("Texture/ball");
            ball = new Ball(tempTexture, screenRectangle);

            Texture2D topTexture = theContent.Load<Texture2D>("Texture/wallHorizontal");
            wallTop = new Wall(topTexture, 
                new Rectangle(
                    (g.screenRectangle.Width - topTexture.Width) / 2,
                    height,
                    topTexture.Width,
                    topTexture.Height), 
                Color.White, true);

            tempTexture = theContent.Load<Texture2D>("Texture/wallVertical");
            wallLeft = new Wall(tempTexture,
                new Rectangle(
                    (g.screenRectangle.Width - topTexture.Width) / 2 - 30,
                    height,
                    tempTexture.Width,
                    tempTexture.Height),
                Color.White, false);
            wallRight = new Wall(tempTexture,
                new Rectangle(
                    (g.screenRectangle.Width + topTexture.Width) / 2,
                    height,
                    tempTexture.Width,
                    tempTexture.Height),
                Color.White, false);
            walls[0] = wallTop;
            walls[1] = wallLeft;
            walls[2] = wallRight;
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
                    StartGame(level);

            paddle.Update();
            aiPaddle.aiUpdate(level, ball);

            ball.Update();

            foreach (Wall wall in walls)
            {
                if (wall.CheckCollision(ball) == 1)
                    score++;
            }

            if (isPlayerTurn == true)
            {
                aiPaddle.Tint = new Color(255, 0, 0, 50);
                paddle.Tint = new Color(0, 0, 255, 50);
                if (ball.PaddleCollision(paddle.GetBounds()) == 1)
                    isPlayerTurn = !isPlayerTurn;
            }
            else
            {
                aiPaddle.Tint = new Color(255, 0, 0, 50);
                paddle.Tint = new Color(0, 0, 255, 50);
                if (ball.PaddleCollision(aiPaddle.GetBounds()) == 1)
                    isPlayerTurn = !isPlayerTurn;
            }

            if (ball.IsGameOver())
                isGameOver = true;

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
           
            wallTop.Draw(theBatch);
            wallLeft.Draw(theBatch);
            wallRight.Draw(theBatch);

            if (isPlayerTurn == false)
            {
                paddle.Draw(theBatch);
                aiPaddle.Draw(theBatch);
            }
            if (isPlayerTurn == true)
            {
                aiPaddle.Draw(theBatch);
                paddle.Draw(theBatch);
            }
            ball.Draw(theBatch);

            theBatch.DrawString(scoreFont, "Score: " + score, new Vector2(20, 10), Color.White);
            theBatch.DrawString(who, isPlayerTurn == true ? "PLAYER" : "BOT", new Vector2(20, 35), isPlayerTurn == true ? Color.Blue : Color.Red);
            if (isGameOver == true)
            {
                theBatch.Draw(gameover, new Vector2((g.screenRectangle.Width - gameover.Width)/2, (g.screenRectangle.Height - gameover.Height)/2), Color.White);
            }
            base.Draw(theBatch);
        }
        public void StartGame(int choose)
        {
            level = choose;
            paddle.SetInStartPosition();
            aiPaddle.SetInStartPosition();
            ball.SetInStartPosition(paddle.GetBounds());

            score = 0;
            isGameStarted = true;
            isGameOver = false;
        }
    }
}
