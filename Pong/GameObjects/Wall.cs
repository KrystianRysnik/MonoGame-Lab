using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.GameObjects
{
    class Wall
    {
        
        Texture2D texture;
        Rectangle location;
        Color tint;
        bool isHorizontal;
        
        public Wall(Texture2D texture, Rectangle location, Color tint, bool isHorizontal)
        {
            this.texture = texture;
            this.location = location;
            this.tint = tint;
            this.isHorizontal = isHorizontal;
        }
        public int CheckCollision(Ball ball)
        {
            if (isHorizontal == true && ball.Bounds.Intersects(location))
            {
                ball.DeflactionY(this);
                return 1;
            }
            if (isHorizontal == false && ball.Bounds.Intersects(location))
            {
                ball.DeflactionX(this);
                return 1;
            }
            return 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, tint);
        }
      
    }
}

