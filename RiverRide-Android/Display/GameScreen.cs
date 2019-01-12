
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

        GameObjects.Plane player;
        HUD hud;
        TextureAtlases textureAtlases;

        TouchCollection touchCollection;
        SpriteFont test;
               
        public GameScreen(Rectangle screenRectangle, GraphicsDeviceManager theGraphics, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;
            player = new GameObjects.Plane(Game1.textureManager.plane, new Rectangle(0, 0, Game1.textureManager.plane[0].Width, Game1.textureManager.plane[0].Height));
 
            test = theContent.Load<SpriteFont>("Font/Test");
            hud = new HUD(screenRectangle);
            textureAtlases = new TextureAtlases(screenRectangle, 50, 8);
            
           // hud = new HUD(tempTexture, theGraphics, screenRectangle);
        }

        public override void Update(GameTime theTime)
        {
            touchCollection = TouchPanel.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.P) || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }

            hud.Update(theTime);
            player.Update(theTime);

            foreach (Map map in textureAtlases.Maps)
            {
                map.Update();

            }
        }
        public override void Draw(SpriteBatch theBatch)
        {
            textureAtlases.Draw(theBatch);
            hud.Draw(theBatch);
            player.Draw(theBatch);
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

        public void StartGame()
        {
            textureAtlases.SetInStartPosition();
            player.SetInStartPosition();


            isGameStarted = true;
            isGameOver = false;
        }
    }
}

