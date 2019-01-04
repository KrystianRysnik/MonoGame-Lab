using Arcanoid.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class TextureAtlases
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Brick[,] Bricks { get; set; }

        public TextureAtlases(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
        }
        public void SetInStartPosition()
        {
            Bricks = new Brick[Columns, Rows];

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\TextureAtlases\map.txt");
            Console.WriteLine(Rows == lines.Length);
            for (int y = 0; y < lines.Length && y < Rows; y++)
            {
                String line = lines[y];
                for (int x = 0; x < line.Length && x < Columns; x++)
                {
                    int n = line[x] - '0';

                    Bricks[x, y] = new Brick(Texture,
                    new Rectangle(
                        x * Texture.Width,
                        y * Texture.Height,
                        Texture.Width,
                        Texture.Height),
                    Color.White, n);
                }
            }
        }
        public bool NoMoreBricks()
        {
            int size = Bricks.Length;
            int sum = 0;
            foreach (Brick brick in Bricks)
            {
                if (brick.health == 0)
                    sum++;
            }
            if (sum == size)
                return true;
            else
                return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Brick brick in Bricks)
                brick.Draw(spriteBatch);
        }
    }
}
