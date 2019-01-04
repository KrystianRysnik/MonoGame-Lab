using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.GameObjects
{
    class Brick
    {
        Texture2D texture;
        Rectangle location;
        Color tint;
        public int health;

        public Rectangle Location
        {
            get { return location; }
        }
        public Brick(Texture2D texture, Rectangle location, Color tint, int health)
        {
            this.texture = texture;
            this.location = location;
            this.tint = tint;
            this.health = health;
        }
        public void CheckCollision(Ball ball)
        {
            if (health != 0 && ball.Bounds.Intersects(location))
            {
                health--;
                ball.Deflaction(this);
            }
        }
      
        public void Draw(SpriteBatch spriteBatch)
        {

            switch (this.health)
            {
                case 0:
                    break;
                case 1:
                    spriteBatch.Draw(texture, location, Color.Green);
                    break;
                case 2:
                    spriteBatch.Draw(texture, location, Color.Yellow);
                    break;
                case 3:
                    spriteBatch.Draw(texture, location, Color.Red);
                    break;
            }            
        }
    }
}
