using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRideA.GameObjects;

namespace RiverRideA
{
    class TextureAtlases
    {
        Game1 g = new Game1();
        public Texture2D[] Texture { get; set; }
        public Texture2D[] HeliTexture { get; set; }
        public Texture2D ShipTexture { get; set; }
        public Texture2D FuelTexture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Map[,] Maps { get; set; }
        public List<Heli> helis = new List<Heli>();
        public List<Ship> ships = new List<Ship>();
        public List<Fuel> fuels = new List<Fuel>();
        public Rectangle ScreenRectangle { get; set; }

        public TextureAtlases(Rectangle screenRectangle, Texture2D[] texture, Texture2D[] heliTexture, Texture2D shipTexture, Texture2D fuelTexture, int rows, int cols)
        {
            Texture = texture;
            HeliTexture = heliTexture;
            ShipTexture = shipTexture;
            FuelTexture = fuelTexture;
            ScreenRectangle = screenRectangle;
            Rows = rows;
            Columns = cols;
        }

        public void SetInStartPosition()
        {
            Maps = new Map[Columns, Rows];
            var path = g.contentRootDirectory + @"/map.txt";
            string[] lines = ReadAllTextLinesFromFile(path);
            //Console.WriteLine(lines);

            for (int y = 0; y < Rows; y++)
            {
                string line = lines[y];
                //Console.WriteLine(line);
                for (int x = 0; x < Columns; x++)
                {
                    //Console.WriteLine(n);
                    if (line[x] == 'H' || line[x] == 'F' || line[x] == 'S')
                    {
                        
                        addMapTile(x, y, 0);
                        if (line[x] == 'H')
                            addHeli(helis, x, y, 7);
                        if (line[x] == 'S')
                            addShip(ships, x, y, 7);
                        if (line[x] == 'F')
                            addFuel(fuels, x, y, 7);
                    }
                    else
                    {
                        int n = line[x] - '0';
                        addMapTile(x, y, n);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Map map in Maps)
                if (map.Location.Y <= ScreenRectangle.Height && map.Location.Y >= -map.Location.Height)
                    map.Draw(spriteBatch);
            //foreach (Heli heli in helis)
            //    if (heli.Location.Y <= ScreenRectangle.Height && heli.Location.Y >= -heli.Location.Height)
            //        heli.Draw(spriteBatch);
            //foreach (Ship ship in ships)
            //    if (ship.Location.Y <= ScreenRectangle.Height && ship.Location.Y >= -ship.Location.Height)
            //        ship.Draw(spriteBatch);
            //foreach (Fuel fuel in fuels)
            //    if (fuel.Location.Y <= ScreenRectangle.Height && fuel.Location.Y >= -fuel.Location.Height)
            //        fuel.Draw(spriteBatch);
        }

        public void addMapTile(int x, int y, int n)
        {
            Maps[x, y] = new Map(Texture[n],
                           new Rectangle(
                               x * Texture[n].Width,
                               -y * Texture[n].Height + ScreenRectangle.Height - 38,
                               Texture[n].Width,
                               Texture[n].Height),
                           Color.White);
        }

        public void addHeli(List<Heli> helis, int x, int y, int n)
        {
            var heli = new Heli(HeliTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + ScreenRectangle.Height - 96,
                          HeliTexture[0].Width,
                          HeliTexture[0].Height)
                          );

            helis.Add(heli);
        }

        public void addShip(List<Ship> ships, int x, int y, int n)
        {
            var ship = new Ship(ShipTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + ScreenRectangle.Height - 96,
                          ShipTexture.Width,
                          ShipTexture.Height)
                          );

            ships.Add(ship);
        }

        public void addFuel(List<Fuel> fuels, int x, int y, int n)
        {
            var fuel = new Fuel(FuelTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + ScreenRectangle.Height - 96,
                          FuelTexture.Width,
                          FuelTexture.Height)
                          );

            fuels.Add(fuel);
        }

        public static string[] ReadAllTextLinesFromFile(string filePath)
        {
            string[] mResult = null;
            using (var mFs = TitleContainer.OpenStream(filePath))
            {
                using (var mSr = new StreamReader(mFs))
                {
                    var mTextList = new List<string>();
                    while (!mSr.EndOfStream) mTextList.Add(mSr.ReadLine());
                    mResult = mTextList.ToArray();
                    mTextList = null;
                }
            }
            return mResult;
        }
    }
}
