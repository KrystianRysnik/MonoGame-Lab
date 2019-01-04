using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RiverRideA.Display
{
    class PauseScreen : Screen
    {
        Texture2D pause;

        Viewport viewport;
        Vector2 center;

        public PauseScreen(GraphicsDeviceManager theGraphic, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            viewport = theGraphic.GraphicsDevice.Viewport;
            center = new Vector2(viewport.Width / 2, viewport.Height / 2);

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
            theBatch.Draw(pause, new Vector2(center.X - pause.Width / 2, center.Y - pause.Height / 2), Color.White);
            base.Draw(theBatch);
        }
    }
}