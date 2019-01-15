using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRide_Android.GameObjects;

namespace RiverRide_Android
{
    class TextureAtlases
    {
        Game1 g = new Game1();
        public Texture2D[] Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Map[,] Maps { get; set; }
        public Rectangle ScreenRectangle { get; set; }

        public List<Heli> helis = new List<Heli>();
        public List<Ship> ships = new List<Ship>();
        public List<Fuel> fuels = new List<Fuel>();
        
        public TextureAtlases(Rectangle screenRectangle, int rows, int cols)
        {
            Texture = Game1.textureManager.mapTiles;
            ScreenRectangle = screenRectangle;
            Rows = rows;
            Columns = cols;
        }

        public void SetInStartPosition()
        {
            Maps = new Map[Columns, Rows];
            var path = g.contentRootDirectory + @"/map.txt";
            string[] lines = ReadAllTextLinesFromFile(path);

            for (int y = 0; y < Rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < Columns; x++)
                {
                    int n = line[x] - '0';
                    if (n == 24 || n == 35 || n == 22)
                    {
                        int temp = n;
                        n = 7;
                        addMapTile(x, y, n);
                        if (temp == 24)
                            addHeli(helis, x, y, n);
                        if (temp == 35)
                            addShip(ships, x, y, n);
                        if (temp == 22)
                            addFuel(fuels, x, y, n);
                    }
                    else
                    {
                        addMapTile(x, y, n);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Map map in Maps)
                map.Draw(spriteBatch);
            foreach (Heli heli in helis)
                if (heli.Location.Y <= ScreenRectangle.Height && heli.Location.Y >= -heli.Location.Height)
                    heli.Draw(spriteBatch);
            foreach (Ship ship in ships)
                if (ship.Location.Y <= ScreenRectangle.Height && ship.Location.Y >= -ship.Location.Height)
                    ship.Draw(spriteBatch);
            foreach (Fuel fuel in fuels)
                if (fuel.Location.Y <= ScreenRectangle.Height && fuel.Location.Y >= -fuel.Location.Height)
                    fuel.Draw(spriteBatch);
        }

        private void addMapTile(int x, int y, int n)
        {

            int posX = (x - 4) * Texture[n].Width + ScreenRectangle.Width / 2;
        
            Maps[x, y] = new Map(Texture[n],
                           new Rectangle(
                               posX,
                               -y * Texture[n].Height + ScreenRectangle.Height - 38,
                               Texture[n].Width,
                               Texture[n].Height),
                           Color.White);
        }

        private void addHeli(List<Heli> helis, int x, int y, int n)
        {
            int posX = (x - 4) * Texture[n].Width + ScreenRectangle.Width / 2;

            var heli = new Heli(Game1.textureManager.heli, new Rectangle(
                          posX,
                          -y * Texture[n].Height + 720 - 96,
                          Game1.textureManager.heli[0].Width,
                          Game1.textureManager.heli[0].Height)
                          );

            helis.Add(heli);
        }

        private void addShip(List<Ship> ships, int x, int y, int n)
        {
            int posX = (x - 4) * Texture[n].Width + ScreenRectangle.Width / 2;

            var ship = new Ship(Game1.textureManager.ship, new Rectangle(
                          posX,
                          -y * Texture[n].Height + 720 - 96,
                          Game1.textureManager.ship.Width,
                          Game1.textureManager.ship.Height)
                          );

            ships.Add(ship);
        }

        private void addFuel(List<Fuel> fuels, int x, int y, int n)
        {
            int posX = (x - 4) * Texture[n].Width + ScreenRectangle.Width / 2;

            var fuel = new Fuel(Game1.textureManager.fuel, new Rectangle(
                          posX,
                          -y * Texture[n].Height + 720 - 96,
                          Game1.textureManager.fuel.Width,
                          Game1.textureManager.fuel.Height)
                          );

            fuels.Add(fuel);
        }

        private static string[] ReadAllTextLinesFromFile(string filePath)
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
