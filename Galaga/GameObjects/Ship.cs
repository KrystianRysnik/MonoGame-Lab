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

        Texture2D texture;
        Rectangle screenRectangle;
        Rectangle location;

        public bool isLive = true;
        public bool isDestroyed = false;

        int destroyIdx = 0;

        public List<Bullet> bullets = new List<Bullet>();
        public Rectangle Location { get => location; }
        double elapsedTime = 0, timeToUpdate = 500;

        public Ship(Texture2D texture, Rectangle screenRectangle)
        {
            this.texture = texture;
            this.screenRectangle = screenRectangle;
            this.location = new Rectangle(0, 0, texture.Width, texture.Height);

            SetInStartPosition();
        }
        public void Update(GameTime gameTime)
        {
            motion = Vector2.Zero;

            keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
            {
                if (keyboardState.IsKeyDown(Keys.Left) && Location.X > 0)
                {
                    motion.X = -1;
                }
                if (keyboardState.IsKeyDown(Keys.Right) && Location.X <= screenRectangle.Width - 54)
                {
                    motion.X = 1;
                }
            }

            if (!isDestroyed && isLive)
            {
                if (keyboardState.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space))
                {
                    AddBullet(bullets);
                    Game1.audioManager.shipFire.Play();
                }

                motion.X *= planeSpeedX;
                position += motion;

                location = new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height);

                previousState = Keyboard.GetState();
            }
            else if (isDestroyed && isLive)
            {
                elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsedTime > timeToUpdate / 2)
                {
                    elapsedTime -= timeToUpdate / 2;

                    if (destroyIdx < Game1.textureManager.shipDestroyed.Length - 1)
                        destroyIdx++;
                    else
                        isLive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isLive)
            {
                if (!isDestroyed && isLive)
                {
                    spriteBatch.Draw(texture, location, Color.White);
                }
                else if (isDestroyed && isLive)
                {
                    spriteBatch.Draw(Game1.textureManager.shipDestroyed[destroyIdx], new Vector2(position.X - (Game1.textureManager.shipDestroyed[destroyIdx].Width / 2) + (texture.Width/2), position.Y - (Game1.textureManager.shipDestroyed[destroyIdx].Height / 2) + (texture.Height/2)), Color.White);
                }
            }
        }

        private void SetInStartPosition()
        {
            position.X = (screenRectangle.Width - texture.Width) / 2;
            position.Y = (screenRectangle.Height - 150);
        }
        private void AddBullet(List<Bullet> bullets)
        {
            var bullet = new Bullet(Game1.textureManager.bullet, new Rectangle(
                location.X + (texture.Width / 2) - (Game1.textureManager.bullet.Width / 2),
                location.Y - texture.Height,
                texture.Width,
                texture.Height)
                );

            bullets.Add(bullet);
        }
    }
}
