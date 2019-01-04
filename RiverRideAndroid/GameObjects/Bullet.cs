using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRideAndroid.GameObjects
{
    class Bullet
    {
        Vector2 position;
        Vector2 motion;
        public float bulletSpeedX = 0;
        public float bulletSpeedY = -5f;

        Texture2D texture;
        Rectangle location;

        private float timer;
        public float LifeSpan = 2f;
        public bool isRemoved = false;
        public Rectangle Location { get { return location; } }

        public Bullet(Texture2D texture, Rectangle location)
        {
            this.texture = texture;
            this.location = location;
            this.position = new Vector2(location.X, location.Y);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= LifeSpan)
                isRemoved = true;

            location.Y += (int)bulletSpeedY;

           // location = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isRemoved)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
    }
}
