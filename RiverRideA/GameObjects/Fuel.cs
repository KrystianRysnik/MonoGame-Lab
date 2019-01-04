using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRideA.GameObjects
{
    class Fuel
    {
        Vector2 position;
        Texture2D texture;

        Rectangle location;

        public List<Bullet> bullets = new List<Bullet>();
        public Rectangle Location { get { return location; } }

        KeyboardState keyboardState;
        public bool isLive = true;

        public Fuel(Texture2D texture, Rectangle location)
        {
            this.texture = texture;
            this.location = new Rectangle(
                            location.X,
                            location.Y,
                            texture.Width,
                            texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down))
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    location.Y += 4;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    location.Y += 1;
                }
            }
            else location.Y += 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isLive)
                    spriteBatch.Draw(texture, Location, Color.White);
        }
    }
}
