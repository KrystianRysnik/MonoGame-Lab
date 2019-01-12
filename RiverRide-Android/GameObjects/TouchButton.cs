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
    class TouchButton
    {
        public string name;
        public Vector2 pos;
        public Texture2D texture;
        public Rectangle buttonRectangle;

        public TouchButton(string name, Texture2D texture, Vector2 pos)
        {
            this.name = name;
            this.pos = pos;
            this.texture = texture;
            buttonRectangle = new Rectangle((int)this.pos.X, (int)this.pos.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(texture, buttonRectangle, Color.White);
          //  theBatch.Draw(texture, destinationRectangle: buttonRectangle, sourceRectangle: , color: Color.White);
        }
    }
}