
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Galaga.Display
{
    class GameScreen : Screen
    {
        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
           
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
        }
        public override void Draw(SpriteBatch theBatch)
        {
           
            base.Draw(theBatch);
        }
        public void StartGame()
        {
            isGameStarted = true;
            isGameOver = false;
        }
    }
}

