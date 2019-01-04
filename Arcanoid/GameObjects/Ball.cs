using Arcanoid.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.GameObjects
{
    class Ball
    {
        Vector2 position;
        Vector2 motion;
        Rectangle bounds;

        public float ballSpeed = 6;

        Texture2D texture;
        Rectangle screenBounds;

        bool collided;
        public Rectangle Bounds
        {
            get
            {
                bounds.X = (int)position.X;
                bounds.Y = (int)position.Y;
                return bounds;
            }
        }

        public Ball(Texture2D texture, Rectangle screenBounds)
        {
            bounds = new Rectangle(0, 0, texture.Width, texture.Height);
            this.texture = texture;
            this.screenBounds = screenBounds;
        }
        public void Deflaction(Brick brick)
        {
            if (!collided)
            {
                motion.Y *= -1;
                collided = true;
            }
        }
        public void Update()
        {
            collided = false;
            position += motion * ballSpeed;
            CheckWallCollision();
        }
        private void CheckWallCollision()
        {
            if (position.X < 0)
            {
                position.X = 0;
                motion.X *= -1;

            }
            if (position.X + texture.Width > screenBounds.Width)
            {
                position.X = screenBounds.Width - texture.Width;
                motion.X *= -1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
                motion.Y *= -1;
            }
        }
        public void SetInStartPosition(Rectangle paddleLocation)
        {
            motion = new Vector2(1, -1);
            position.X = paddleLocation.X + (paddleLocation.Width - texture.Width) / 2;
            position.Y = paddleLocation.Y - texture.Height;
        }
        public bool IsGameOver()
        {
            if (position.Y > screenBounds.Height)
                return true;
            return false;
        }
        public void PaddleCollision(Rectangle paddleLocation)
        {
            Rectangle ballLocation = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);

            if (paddleLocation.Intersects(ballLocation))
            {
                position.Y = paddleLocation.Y - texture.Height;
                motion.Y *= -1;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
