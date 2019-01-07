using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.GameObjects
{
    class Ship
    {
        Vector2 position;
        Vector2 motion;
        public float planeSpeedX = 8f;

        KeyboardState keyboardState;
        KeyboardState previousState;

        Texture2D[] texture;
        Rectangle screenRectangle;
        Rectangle location;

        int textureIdx = 0;

        public List<Bullet> bullets = new List<Bullet>();

        public Ship(Texture2D[] texture, Rectangle screenRectangle)
        {
            this.texture = texture;
            this.screenRectangle = screenRectangle;
            this.location = new Rectangle(0, 0, texture[0].Width, texture[0].Height);

            SetInStartPosition();
        }
        public void Update(GameTime gameTime)
        {
            motion = Vector2.Zero;

            keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    motion.X = -1;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    motion.X = 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space))
            {
                AddBullet(bullets);
            }

            motion.X *= planeSpeedX;
            position += motion;

            location = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture[textureIdx].Width,
                texture[textureIdx].Height);

            previousState = Keyboard.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture[textureIdx], position, Color.White);
        }

        private void SetInStartPosition()
        {
            position.X = (screenRectangle.Width - texture[textureIdx].Width) / 2;
            position.Y = (screenRectangle.Height - 150);
        }
        public void AddBullet(List<Bullet> bullets)
        {
            var bullet = new Bullet(Game1.textureManager.bullet, new Rectangle(
                location.X + (texture[textureIdx].Width / 2) - (Game1.textureManager.bullet.Width / 2),
                location.Y - texture[textureIdx].Height,
                texture[textureIdx].Width,
                texture[textureIdx].Height)
                );

            bullets.Add(bullet);
        }
    }
}
