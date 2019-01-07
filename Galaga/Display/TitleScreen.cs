using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Display
{
    class TitleScreen : Screen
    {
        Rectangle screenRectangle;
        Texture2D logo;
        Vector2 center;
        SpriteFont dosFont;

        public TitleScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;

            logo = theContent.Load<Texture2D>("Image/logo");
            dosFont = theContent.Load <SpriteFont>("Font/DOS_Font");
        }
              
        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(theTime);
        }
        
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(logo, new Vector2((screenRectangle.Width - logo.Width)/2, (screenRectangle.Height - logo.Height)/2), Color.White);
            theBatch.DrawString(dosFont, "PRESS", new Vector2(screenRectangle.Width / 2 - 223, screenRectangle.Height - 50), Color.White);
            theBatch.DrawString(dosFont, "SPACE", new Vector2(screenRectangle.Width / 2 - 115, screenRectangle.Height - 50), new Color(68, 255, 255));
            theBatch.DrawString(dosFont, "TO START GAME", new Vector2(screenRectangle.Width / 2 - 8, screenRectangle.Height - 50), Color.White);
            base.Draw(theBatch);
        }
    }
}
