using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.GameObjects
{
    class Paddle
    {
        Vector2 position;
        Vector2 motion;
        float paddleSpeed = 12f;

        KeyboardState keyboardState;

        Texture2D texture;
        Color tint;
        Rectangle screenBounds;

        public Color Tint { get => tint; set => tint = value; }

        public Paddle(Texture2D texture, Rectangle screenBounds, Color tint)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.tint = tint;
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
        public void aiUpdate(int lvl, Ball ball)
        {
            switch (lvl)
            {
                // EASY
                case 0:
                    if (ball.Bounds.Y >= screenBounds.Height * 0.40)
                    {
                        if (ball.Bounds.X <= (this.position.X + this.texture.Width / 2))
                            this.motion.X = -1;
                        else
                            this.motion.X = 1;
                        motion.X *= paddleSpeed;
                        position += motion;
                    }
                    break;
                // MEDIUM
                case 1:
                    if (ball.Bounds.Y >= screenBounds.Height * 0.30)
                    {
                        if (ball.Bounds.X <= (this.position.X + this.texture.Width / 2))
                            this.motion.X = -1;
                        else
                            this.motion.X = 1;
                        motion.X *= paddleSpeed;
                        position += motion;
                    }
                    break;
                // HARD
                case 2:
                    if (ball.Bounds.Y >= screenBounds.Height * 0.20)
                    {
                        if (ball.Bounds.X <= (this.position.X + this.texture.Width / 2))
                            this.motion.X = -1;
                        else
                            this.motion.X = 1;
                        motion.X *= paddleSpeed;
                        position += motion;
                    }
                    break;
            }
        }

        public void SetInStartPosition()
        {
            position.X = (screenBounds.Width - texture.Width) / 2;
            position.Y = screenBounds.Height - texture.Height - 5;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, tint);
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
