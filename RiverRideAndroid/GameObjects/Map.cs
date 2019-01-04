using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRideAndroid.GameObjects
{
    class Map
    {
        Texture2D texture;
        Rectangle location;
        Color[] textureData;
        Color tint;

        public Rectangle Location {
            get { return location; }
        }
        public Color[] TextureData
        {
            get { return textureData; }

        }

        KeyboardState keyboardState;

        public Map(Texture2D texture, Rectangle location, Color tint)
        {
            this.texture = texture;
            this.location = location;
            this.textureData = new Color[texture.Height * texture.Width];
            texture.GetData(textureData);
            this.tint = tint;
        }
        public void Update()
        {
            keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down))
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    location.Y += 4;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    location.Y += 1;
                }
            }
            else location.Y += 2;
        }
   
        public void Draw(SpriteBatch spriteBatch)
        {
            Matrix.CreateScale(2f);
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
