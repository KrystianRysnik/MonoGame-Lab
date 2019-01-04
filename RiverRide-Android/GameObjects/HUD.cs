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
using Microsoft.Xna.Framework.Graphics;

namespace RiverRide_Android.GameObjects
{
    class HUD
    {
        Texture2D[] texture;
        Rectangle screenRectangle;

        public Texture2D hudControlTexture { set; get; }
        public Rectangle HudControlLocation { set; get; }

        Texture2D bgHud;
    

        
        public HUD(Texture2D[] texture, GraphicsDeviceManager graphics, Rectangle screenRectangle)
        {
            this.texture = texture;
            this.screenRectangle = screenRectangle;

            hudControlTexture = texture[1];
            HudControlLocation = new Rectangle(screenRectangle.Width - hudControlTexture.Width - 14, screenRectangle.Height - hudControlTexture.Height - 14, hudControlTexture.Width, hudControlTexture.Height);

            // Background for HUD
            bgHud = new Texture2D(graphics.GraphicsDevice, screenRectangle.Width, 150);
            Color[] data = new Color[screenRectangle.Width * 150];
            for (int i = 0; i < data.Length; ++i)
                data[i] = new Color(142, 142, 142);
            bgHud.SetData(data);

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgHud, new Vector2(0, screenRectangle.Height - bgHud.Height), Color.White);
            spriteBatch.Draw(texture[0], new Vector2((screenRectangle.Width - texture[0].Width) / 2, screenRectangle.Height - 100), new Color(142, 142, 142));
            spriteBatch.Draw(hudControlTexture, HudControlLocation, Color.White);
        }
    }
}