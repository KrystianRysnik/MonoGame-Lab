
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
        public TextureAtlases textureAtlases;

        TouchCollection touchCollection;
               
        public GameScreen(Rectangle screenRectangle, GraphicsDeviceManager theGraphics, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;
            player = new GameObjects.Plane(Game1.textureManager.plane, screenRectangle);
 
            hud = new HUD(screenRectangle);
            textureAtlases = new TextureAtlases(screenRectangle, 50, 8);
        }

        public override void Update(GameTime theTime)
        {
            touchCollection = TouchPanel.GetState();

            if (!isGameOver)
            {
                updateEnemies(theTime);

                updateFuel(theTime);

                updateBullets(theTime);

                player.Update(theTime);

                foreach (Map map in textureAtlases.Maps)
                {
                    map.Update();
                    if (IntersectsPixel(player.Location, player.TextureData, map.Location, map.TextureData))
                        isGameOver = true;
                }
            }
            else
            {
                if (touchCollection.Count > 0)
                {
                    foreach (var touch in touchCollection)
                    {
                        Matrix tempMatrix = Matrix.Invert(Game1.scaleMatrix);
                        TouchLocation tempLocation = new TouchLocation(touch.Id, touch.State, Vector2.Transform(new Vector2(touch.Position.X + Game1.viewport.X, touch.Position.Y + Game1.viewport.Y), tempMatrix));

                        //  if (touchCollection[0].State == TouchLocationState.Moved || touchCollection[0].State == TouchLocationState.Pressed)
                        if (HUD.fireBtn.buttonRectangle.Contains(tempLocation.Position) && (touch.State == TouchLocationState.Moved || touch.State == TouchLocationState.Pressed))
                        {
                            StartGame();
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(hud.WaterBackground, new Vector2((screenRectangle.Width - hud.WaterBackground.Width)/ 2, 0), Color.White);
            textureAtlases.Draw(theBatch);
            hud.Draw(theBatch);
            player.Draw(theBatch);
            foreach (Bullet bullet in player.bullets)
            { 
               bullet.Draw(theBatch);
            }
            theBatch.Draw(Game1.textureManager.fuelPointer, new Vector2((screenRectangle.Width - Game1.textureManager.fuelLevel.Width) / 2 + 10 + (player.Fuel * (354 - 19)), screenRectangle.Height - 111), Color.White);
            theBatch.Draw(Game1.textureManager.fuelLevel, new Vector2((screenRectangle.Width - Game1.textureManager.fuelLevel.Width) / 2, screenRectangle.Height - Game1.textureManager.fuelLevel.Height - 10), Color.White);
            if (isGameOver == true)
            {
                theBatch.Draw(Game1.textureManager.gameOver, new Vector2((screenRectangle.Width - Game1.textureManager.gameOver.Width) / 2, (screenRectangle.Height - Game1.textureManager.gameOver.Height) / 2), Color.White);
            }
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
            textureAtlases.helis.Clear();
            textureAtlases.ships.Clear();
            player.bullets.Clear();
            textureAtlases.SetInStartPosition();
            player.SetInStartPosition();
     
            isGameStarted = true;
            isGameOver = false;
        }

        // Update enemies
        public void updateEnemies(GameTime theTime)
        {
            foreach (Heli heli in textureAtlases.helis)
            {
                if (heli.isLive)
                {
                    heli.Update(theTime);
                    if (player.Location.Intersects(heli.Location))
                        isGameOver = true;
                }
            }

            foreach (Ship ship in textureAtlases.ships)
            {
                if (ship.isLive)
                {
                    ship.Update(theTime);
                    if (player.Location.Intersects(ship.Location))
                        isGameOver = true;
                }
            }
        }

        // Update fuel
        public void updateFuel(GameTime theTime)
        {
            foreach (Fuel fuel in textureAtlases.fuels)
            {
                fuel.Update(theTime);
                if (player.Location.Intersects(fuel.Location))
                {
                    if (player.Fuel + 0.20f >= 1f)
                        player.Fuel = 1f;
                    else
                        player.Fuel += 0.20f;
                
                }
            }
        }

        // Update bullets
        public void updateBullets(GameTime theTime)
        {
            foreach (Bullet bullet in player.bullets)
            {
                bullet.Update(theTime);
                foreach (Heli heli in textureAtlases.helis)
                {
                    if (heli.isLive && !bullet.isRemoved && bullet.Location.Intersects(heli.Location))
                    {
                        heli.isLive = false;
                        bullet.isRemoved = true;
                    }
                }
                foreach (Ship ship in textureAtlases.ships)
                {
                    if (ship.isLive && !bullet.isRemoved && bullet.Location.Intersects(ship.Location))
                    {
                        ship.isLive = false;
                        bullet.isRemoved = true;
                    }
                }
                foreach (Fuel fuel in textureAtlases.fuels)
                {
                    if (fuel.isLive && !bullet.isRemoved && bullet.Location.Intersects(fuel.Location))
                    {
                        fuel.isLive = false;
                        bullet.isRemoved = true;
                    }
                }
            }
        }
    }
}

