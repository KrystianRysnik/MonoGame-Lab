using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Galaga.Display
{
    class PauseScreen : Screen
    {
        Texture2D pause;
        Rectangle screenRectangle;

        Viewport viewport;
        Vector2 center;

        public PauseScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;

            pause = theContent.Load<Texture2D>("Image/pause");
        }
    
        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) || Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(pause, new Vector2(screenRectangle.Width - pause.Width / 2, screenRectangle.Height - pause.Height / 2), Color.White);
            base.Draw(theBatch);
        }
    }
}
