using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRide_Android.GameObjects
{
    class Plane
    {
        Vector2 position;
        Vector2 motion;
        public float planeSpeedX = 6f;
        public float planeSpeedY = 0;

        //  KeyboardState keyboardState;
        //   KeyboardState previousState;
        TouchCollection touchCollection;

        // 0 - left, 1 - straight, 2 - right
        Texture2D[] texture;
        Color[] textureData;
        Rectangle screenRectangle;
        Rectangle location;

        //public List<Bullet> bullets = new List<Bullet>();
        public Rectangle Location { get { return location; } }

        public Rectangle ScreenBounds { get; }

        public Color[] TextureData { get { return textureData; } }
        public float Fuel { get; set; }

        // 0 - left, 1 - straight, 2 - right
        int status = 1;
        double elapsedTime, timeToUpdate = 100;


        public Plane(Texture2D[] texture, Rectangle screenRectangle)
        {
            this.texture = texture;
            this.screenRectangle = screenRectangle;
            this.location = new Rectangle(
                            texture[1].Width,
                            texture[1].Height,
                            texture[1].Width,
                            texture[1].Height);
            this.textureData = new Color[texture[1].Width * texture[1].Height];
            texture[1].GetData(textureData);
            SetInStartPosition();
        }

        public void Update(GameTime gameTime)
        {
            motion = Vector2.Zero;

            /* keyboardState = Keyboard.GetState();


             if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
             {
                 if (keyboardState.IsKeyDown(Keys.Left))
                 {
                     motion.X = -1;
                     status = 0;
                 }
                 if (keyboardState.IsKeyDown(Keys.Right))
                 {
                     motion.X = 1;
                     status = 2;
                 }
             }
             else status = 1;

             if (keyboardState.IsKeyDown(Keys.Space) & !previousState.IsKeyDown(Keys.Space))
             {
                 AddBullet(bullets);
             }*/

            touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                foreach (var touch in touchCollection)
                {

                    Matrix tempMatrix = Matrix.Invert(Game1.scaleMatrix);
                    TouchLocation tempLocation = new TouchLocation(touch.Id, touch.State, Vector2.Transform(new Vector2(touch.Position.X + Game1.viewport.X, touch.Position.Y + Game1.viewport.Y), tempMatrix));

                    if (HUD.leftMiddleBtn.buttonRectangle.Contains(tempLocation.Position))
                    {
                        motion.X = -1;
                        status = 0;
                    }
                    else if (HUD.rightMiddleBtn.buttonRectangle.Contains(tempLocation.Position))
                    {
                        motion.X = 1;
                        status = 2;
                    }
                    else
                    {
                        status = 1;
                    }
                }
            }
            else
            {
                status = 1;
            }

            motion.X *= planeSpeedX;
            motion.Y = planeSpeedY;
            position += motion;

            location = new Rectangle(
                         (int)position.X,
                         (int)position.Y,
                         texture[1].Width,
                         texture[1].Height);

            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > timeToUpdate)
            {
                elapsedTime -= timeToUpdate;

                Fuel -= (float)0.6;
            }

           // previousState = Keyboard.GetState();
        }
        public void SetInStartPosition()
        {
            position.X = (screenRectangle.Width - texture[1].Width) / 2;
            position.Y = screenRectangle.Height - texture[1].Height - 5;
            Fuel = 100;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture[status], position, Color.White);
        }

      /*  public void AddBullet(List<Bullet> bullets)
        {
            var bullet = new Bullet(texture[3], new Rectangle(
                Location.X + (texture[1].Width / 2) - (texture[3].Width / 2),
                Location.Y - texture[3].Height,
                texture[3].Width,
                texture[3].Height)
                );

            bullets.Add(bullet);
        }*/
    }
}