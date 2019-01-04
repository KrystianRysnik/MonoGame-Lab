using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.GameObjects
{
    class Paddle
    {
        Vector2 position;
        Vector2 motion;
        public float paddleSpeed = 12f;

        KeyboardState keyboardState;

        Texture2D texture;
        Rectangle screenBounds;

        public Paddle(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            SetInStartPosition();
        }

        public void Update()
        {
            motion = Vector2.Zero;

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
                if (!(this.position.X <= 0))
                    motion.X = -1;
            if (keyboardState.IsKeyDown(Keys.Right))
                if (!(this.position.X >= screenBounds.Width - this.texture.Width))
                    motion.X = 1;

            motion.X *= paddleSpeed;
            position += motion;
        }

        public void SetInStartPosition()
        {
            position.X = (screenBounds.Width - texture.Width) / 2;
            position.Y = screenBounds.Height - texture.Height - 5;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);
        }
    }
}
