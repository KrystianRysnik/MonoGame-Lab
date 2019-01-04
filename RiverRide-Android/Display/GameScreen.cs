
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using RiverRide_Android.GameObjects;
using System;
using System.Collections.Generic;

namespace RiverRide_Android.Display
{
    class GameScreen : Screen
    {
        Rectangle screenRectangle;
        HUD hud;

        TouchCollection touchCollection;
        SpriteFont test;
        bool eventValue = false;
               
        public GameScreen(Rectangle screenRectangle, GraphicsDeviceManager theGraphics, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;
            Texture2D[] tempTexture = new Texture2D[2];
            tempTexture[0] = theContent.Load<Texture2D>("Texture/fuel-level");
            tempTexture[1] = theContent.Load<Texture2D>("Texture/hud-control");
            test = theContent.Load<SpriteFont>("Font/Test");
            
            hud = new HUD(tempTexture, theGraphics, screenRectangle);
        }

        public override void Update(GameTime theTime)
        {
            touchCollection = TouchPanel.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.P) || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }


            eventValue = touchControl(hud.HudControlLocation);

        }
        public override void Draw(SpriteBatch theBatch)
        {
            hud.Draw(theBatch);
            theBatch.DrawString(test, "Event: " + eventValue, new Vector2(10, 10), Color.Black);
            base.Draw(theBatch);
        }
       
        public bool IntersectsPixel(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB)
        {
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];


                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }
            // No intersection found
            return false;
        }

        public bool touchControl(Rectangle target)
        {
            
                foreach (TouchLocation tl in touchCollection)
                {
                    if ((tl.State == TouchLocationState.Released ||
                    tl.State == TouchLocationState.Moved) &&
                    tl.Position.X > target.Left && // 0
                    tl.Position.X < target.Right && // < 1/3
                    tl.Position.Y > target.Top && // 0
                    tl.Position.Y < target.Bottom) // < 1/3
                    {
                        return true; 
                    }
                }
                return false;
        }
    }
}

