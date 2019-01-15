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
    class Fuel
    {
        Texture2D texture;
        Rectangle location;
        public bool isLive = true;
        public Rectangle Location { get { return location; } }

        TouchCollection touchCollection;

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, Color.White);
        }
    }
}
