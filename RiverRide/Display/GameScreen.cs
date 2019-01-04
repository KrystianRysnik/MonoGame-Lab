
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RiverRide.GameObjects;
using System;
using System.Collections.Generic;

namespace RiverRide.Display
{
    class GameScreen : Screen
    {
        PlanePlayer plane;
        Bullet bullet;

        Texture2D gameover;

        Game1 g = new Game1();
        TextureAtlases textureAtlases;

        SpriteFont scoreFont;
               
        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            gameover = theContent.Load<Texture2D>("Image/gameover");

            scoreFont = theContent.Load<SpriteFont>("Font/score");

            Texture2D[] tempTexture = new Texture2D[4];
            tempTexture[0] = theContent.Load<Texture2D>("Texture/plane-left");
            tempTexture[1] = theContent.Load<Texture2D>("Texture/plane");
            tempTexture[2] = theContent.Load<Texture2D>("Texture/plane-right");
            tempTexture[3] = theContent.Load<Texture2D>("Texture/bullet");
            plane = new PlanePlayer(tempTexture, screenRectangle);;

            tempTexture = new Texture2D[8];
            for (int i = 0; i < 8; i++)
                tempTexture[i] = theContent.Load<Texture2D>("Texture/map-" + i);
            // tempTexture, X, 8
            Texture2D[] heliTexture = new Texture2D[2];
            heliTexture[0] = theContent.Load<Texture2D>("Texture/heli-1");
            heliTexture[1] = theContent.Load<Texture2D>("Texture/heli-2");

            Texture2D shipTexture = theContent.Load<Texture2D>("Texture/ship");
            Texture2D fuelTexture = theContent.Load<Texture2D>("Texture/fuel");
            textureAtlases = new TextureAtlases(tempTexture, heliTexture, shipTexture, fuelTexture, 24, 8);
        }

        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                if (isGameOver == true)
                    StartGame();


            if (!isGameOver)
            {
                foreach (Heli heli in textureAtlases.helis)
                {
                    if (heli.isLive)
                    {
                        heli.Update(theTime);
                        if (plane.Location.Intersects(heli.Location))
                            isGameOver = true;
                    }
                }

                foreach (Ship ship in textureAtlases.ships)
                {
                    if (ship.isLive)
                    {
                        ship.Update(theTime);
                        if (plane.Location.Intersects(ship.Location))
                            isGameOver = true;
                    }
                }

                foreach (Fuel fuel in textureAtlases.fuels)
                {
                    if (fuel.isLive)
                    {
                        fuel.Update(theTime);
                        if (plane.Location.Intersects(fuel.Location))
                        {
                            fuel.isLive = false;
                            if (plane.Fuel + 20 >= 100)
                                plane.Fuel = 100;
                            else 
                                plane.Fuel += 20;
                        }
                   
                    }
                }

                foreach (Bullet bullet in plane.bullets)
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

           
                plane.Update(theTime);

                foreach (Map map in textureAtlases.Maps)
                {
                    map.Update();
                    //Console.WriteLine(textureAtlases.Maps[0,0].Location);
                    //Console.WriteLine(plane.Location);
                    if (map.Location.Y <= 720 - map.Location.Height && map.Location.Y >= 720 - 2 * map.Location.Height)
                        if (IntersectsPixel(plane.Location, plane.TextureData, map.Location, map.TextureData))
                            isGameOver = true;
                }
            }

        }
        public override void Draw(SpriteBatch theBatch)
        {
            textureAtlases.Draw(theBatch);
            plane.Draw(theBatch);
            foreach(Bullet bullet in plane.bullets)
                bullet.Draw(theBatch);
            
            if (isGameOver == true)
            {
                theBatch.Draw(gameover, new Vector2((g.screenRectangle.Width - gameover.Width)/2, (g.screenRectangle.Height - gameover.Height)/2), Color.White);
            }
            theBatch.DrawString(scoreFont, "Fuel level: " + plane.Fuel, new Vector2(5, 5), Color.White);

            base.Draw(theBatch);
        }
        public void StartGame()
        {
            textureAtlases.helis.Clear();
            textureAtlases.ships.Clear();
            textureAtlases.fuels.Clear();
            plane.bullets.Clear();
 
            plane.SetInStartPosition();
            textureAtlases.SetInStartPosition();

            isGameStarted = true;
            isGameOver = false;
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
    }
}

