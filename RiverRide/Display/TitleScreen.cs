using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRide.Display
{
    class TitleScreen : Screen
    {
        Viewport viewport;
        Texture2D logo;
        Vector2 center;

        public TitleScreen(GraphicsDeviceManager theGraphic, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            viewport = theGraphic.GraphicsDevice.Viewport;
            center = new Vector2(viewport.Width / 2, viewport.Height / 2);

            logo = theContent.Load<Texture2D>("Image/logo");
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
            theBatch.Draw(logo, new Vector2(center.X - logo.Width/2, center.Y - logo.Height/2), Color.White);
            base.Draw(theBatch);
        }
    }
}
