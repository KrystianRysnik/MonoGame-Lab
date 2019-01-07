using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.GameObjects
{
    class Star
    {
        static bool scroll = false;

        public bool isVisible;
        float flickerSpeed;
        float scrollSpeed;
        Texture2D texture;
        Vector2 position;
        float elapsedTime;

        public static bool Scroll { set => scroll = value; }

        public Star()
        {
            isVisible = true;
            Random random = new Random();
            texture = Game1.textureManager.stars[random.Next() % 4];
            position = new Vector2(random.Next() % Game1.WIDTH, random.Next() % Game1.HEIGHT);
            flickerSpeed = 500 + (random.Next() % 500);
            scrollSpeed = 6f;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime >= flickerSpeed)
                isVisible = false;

            position.Y += scrollSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
