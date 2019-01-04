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
    class Ship
    {
        Vector2 position;
        Vector2 motion;
        public int shipSpeedX = 2;
        int startPositionX;

        int frameIndex = 0;


        Texture2D texture;

        Rectangle location;

        public List<Bullet> bullets = new List<Bullet>();
        public Rectangle Location { get { return location; } }

        KeyboardState keyboardState;

        bool right = true;
        public bool isLive = true;

        public Ship(Texture2D texture, Rectangle location)
        {
            this.texture = texture;
            this.location = new Rectangle(
                            location.X,
                            location.Y,
                            texture.Width,
                            texture.Height);
            startPositionX = location.X;
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

            if (right == true && startPositionX + 256 >= Location.X)
                location.X += shipSpeedX;
            else
                right = false;
            if (right == false && startPositionX <= Location.X)
                location.X -= shipSpeedX;
            else
                right = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isLive)
            {
                if (right == true)
                    spriteBatch.Draw(texture, new Vector2(location.X, location.Y), Color.White);
                else
                    spriteBatch.Draw(texture, Location, null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
    }
}

