using RiverRide.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRide
{
    class TextureAtlases
    {
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

        public TextureAtlases(Texture2D[] texture, Texture2D[] heliTexture, Texture2D shipTexture, Texture2D fuelTexture, int rows, int cols)
        {
            Texture = texture;
            HeliTexture = heliTexture;
            ShipTexture = shipTexture;
            FuelTexture = fuelTexture;
            Rows = rows;
            Columns = cols;
        }

        public void SetInStartPosition()
        {
            Maps = new Map[Columns, Rows];
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\TextureAtlases\map.txt");
            for (int y = 0; y < Rows; y++)
            {
                String line = lines[y];
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
                if (map.Location.Y <= 720 && map.Location.Y >= -map.Location.Height)
                    map.Draw(spriteBatch);
            foreach (Heli heli in helis)
                if (heli.Location.Y <= 720 && heli.Location.Y >= -heli.Location.Height)
                    heli.Draw(spriteBatch);
            foreach (Ship ship in ships)
                if (ship.Location.Y <= 720 && ship.Location.Y >= -ship.Location.Height)
                    ship.Draw(spriteBatch);
            foreach (Fuel fuel in fuels)
                if (fuel.Location.Y <= 720 && fuel.Location.Y >= -fuel.Location.Height)
                    fuel.Draw(spriteBatch);
        }

        public void addMapTile(int x, int y, int n)
        {
            Maps[x, y] = new Map(Texture[n],
                           new Rectangle(
                               x * Texture[n].Width,
                               -y * Texture[n].Height + 720 - 38,
                               Texture[n].Width,
                               Texture[n].Height),
                           Color.White);
        }

        public void addHeli(List<Heli> helis, int x, int y, int n)
        {
            var heli = new Heli(HeliTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + 720 - 96,
                          HeliTexture[0].Width,
                          HeliTexture[0].Height)
                          );

            helis.Add(heli);
        }

        public void addShip(List<Ship> ships, int x, int y, int n)
        {
            var ship = new Ship(ShipTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + 720 - 96,
                          ShipTexture.Width,
                          ShipTexture.Height)
                          );

            ships.Add(ship);
        }

        public void addFuel(List<Fuel> fuels, int x, int y, int n)
        {
            var fuel = new Fuel(FuelTexture, new Rectangle(
                          x * Texture[n].Width,
                          -y * Texture[n].Height + 720 - 96,
                          FuelTexture.Width,
                          FuelTexture.Height)
                          );

            fuels.Add(fuel);
        }
    }
}
