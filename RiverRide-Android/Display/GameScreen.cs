
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
            player = new GameObjects.Plane(Game1.textureManager.plane, screenRectangle);
 
            test = theContent.Load<SpriteFont>("Font/Test");
            hud = new HUD(screenRectangle);
            textureAtlases = new TextureAtlases(screenRectangle, 50, 8);
        }

        public override void Update(GameTime theTime)
        {

            if (!isGameOver)
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

                foreach (Fuel fuel in textureAtlases.fuels)
                {
                    if (fuel.isLive)
                    {
                        fuel.Update(theTime);
                        if (player.Location.Intersects(fuel.Location))
                        {
                            fuel.isLive = false;
                            if (player.Fuel + 20 >= 100)
                                player.Fuel = 100;
                            else
                                player.Fuel += 20;
                        }

                    }
                }

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


                player.Update(theTime);

                foreach (Map map in textureAtlases.Maps)
                {
                    map.Update();
                    //Console.WriteLine(textureAtlases.Maps[0,0].Location);
                    //Console.WriteLine(plane.Location);
                    if (map.Location.Y <= 720 - map.Location.Height && map.Location.Y >= 720 - 2 * map.Location.Height)
                        if (IntersectsPixel(player.Location, player.TextureData, map.Location, map.TextureData))
                            isGameOver = true;
                }
            }
        }
        public override void Draw(SpriteBatch theBatch)
        {
            textureAtlases.Draw(theBatch);
            hud.Draw(theBatch);
            player.Draw(theBatch);
            foreach (Bullet bullet in player.bullets)
            { 
               bullet.Draw(theBatch);
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
            textureAtlases.SetInStartPosition();
            player.SetInStartPosition();
     
            isGameStarted = true;
            isGameOver = false;
        }
    }
}

