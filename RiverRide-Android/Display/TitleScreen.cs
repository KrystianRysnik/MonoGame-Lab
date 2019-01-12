using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRide_Android.Display
{
    class TitleScreen : Screen
    {
        Rectangle screenRectangle;
        Texture2D logo;
        TouchCollection touchCollection;

        public TitleScreen(Rectangle screenRectangle, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;

            logo = theContent.Load<Texture2D>("Image/start");
        }
              
        public override void Update(GameTime theTime)
        {
            touchCollection = TouchPanel.GetState();

            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    ScreenEvent.Invoke(this, new EventArgs());
                }
            }

            base.Update(theTime);
        }
        
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(logo, new Vector2((screenRectangle.Width - logo.Width)/2, (screenRectangle.Height - logo.Height)/2), Color.White);
            base.Draw(theBatch);
        }
    }
}
