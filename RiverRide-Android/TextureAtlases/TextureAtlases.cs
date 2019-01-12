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
        public Texture2D[] HeliTexture { get; set; }
        public Texture2D ShipTexture { get; set; }
        public Texture2D FuelTexture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Map[,] Maps { get; set; }
        public Rectangle ScreenRectangle { get; set; }

        public TextureAtlases(Rectangle screenRectangle, Texture2D[] texture, int rows, int cols)
        {
            Texture = texture;
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
                    addMapTile(x, y, n);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Map map in Maps)
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
