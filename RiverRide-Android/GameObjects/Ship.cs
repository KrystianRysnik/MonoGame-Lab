using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRide_Android.GameObjects
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
        TouchCollection touchCollection;
        
        public bool right = true;
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
            touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                foreach (var touch in touchCollection)
                {
                    Matrix tempMatrix = Matrix.Invert(Game1.scaleMatrix);
                    TouchLocation tempLocation = new TouchLocation(touch.Id, touch.State, Vector2.Transform(new Vector2(touch.Position.X + Game1.viewport.X, touch.Position.Y + Game1.viewport.Y), tempMatrix));

                    if (HUD.leftUpBtn.buttonRectangle.Contains(tempLocation.Position)
                     || HUD.upBtn.buttonRectangle.Contains(tempLocation.Position)
                     || HUD.rightUpBtn.buttonRectangle.Contains(tempLocation.Position))
                    {
                        location.Y += 3;
                    }
                    else if (HUD.leftDownBtn.buttonRectangle.Contains(tempLocation.Position)
                        || HUD.downBtn.buttonRectangle.Contains(tempLocation.Position)
                        || HUD.rightDownBtn.buttonRectangle.Contains(tempLocation.Position))
                    {
                        location.Y += 1;
                    }
                    else
                    {
                        location.Y += 2;
                    }
                }
            }
            else
            {
                location.Y += 2;
            }

            if (right == true && startPositionX + 128 >= Location.X)
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

