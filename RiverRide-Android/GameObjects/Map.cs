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
    class Map
    {
        Texture2D texture;
        Rectangle location;
        Color[] textureData;
        Color tint;

        TouchCollection touchCollection;

        public Rectangle Location {
            get { return location; }
        }
        public Color[] TextureData
        {
            get { return textureData; }

        }

        KeyboardState keyboardState;

        public Map(Texture2D texture, Rectangle location, Color tint)
        {
            this.texture = texture;
            this.location = location;
            this.textureData = new Color[texture.Height * texture.Width];
            texture.GetData(textureData);
            this.tint = tint;
        }
        public void Update()
        {
            /* keyboardState = Keyboard.GetState();


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
             */
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
                        location.Y += 4;
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
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
