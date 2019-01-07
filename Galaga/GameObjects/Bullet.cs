using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.GameObjects
{
    class Bullet
    {
        Vector2 position;
        Vector2 motion;
        public float bulletSpeedY = -7f;

        Texture2D texture;
        Rectangle location;

        private float timer;
        public float LifeSpan = 2f;
        public bool isRemoved = false;

        public Rectangle Location { get => location; }

        public Bullet(Texture2D texture, Rectangle location)
        {
            this.texture = texture;
            this.location = location;
            this.position = new Vector2(location.X, location.Y + texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= LifeSpan)
                isRemoved = true;

            position.Y += (int)bulletSpeedY;

            location = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
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
