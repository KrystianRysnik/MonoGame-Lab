using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Galaga.Helpers
{
    public class TextureManager
    {
        // GUI
        public Texture2D splashScreen;

        // Starrs
        public Texture2D[] stars;

        // Ship texture  
        public Texture2D bullet;
        public Texture2D ship;
        public Texture2D[] shipDestroyed;

        // Enemy
        public Texture2D enemyBullet;
        public Texture2D[] enemyYellow;
        public Texture2D[] enemyRed;
        public Texture2D[] enemyTop;
        public Texture2D[] enemyDestroyed;

        public TextureManager(ContentManager theContent)
        {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent)
        {
            // GUI
            splashScreen = theContent.Load<Texture2D>("Image/logo");

            // Stars
            stars = new Texture2D[4] {
                theContent.Load<Texture2D>("Texture/star_1"),
                theContent.Load<Texture2D>("Texture/star_2"),
                theContent.Load<Texture2D>("Texture/star_3"),
                theContent.Load<Texture2D>("Texture/star_4")
            };

            // Bullet texture;
            bullet = theContent.Load<Texture2D>("Texture/bullet");

            // Ship texture
            ship = theContent.Load<Texture2D>("Texture/ship");
            shipDestroyed = new Texture2D[4]
            {
                theContent.Load<Texture2D>("Texture/ship_destroy_0"),
                theContent.Load<Texture2D>("Texture/ship_destroy_1"),
                theContent.Load<Texture2D>("Texture/ship_destroy_2"),
                theContent.Load<Texture2D>("Texture/ship_destroy_3")
            };

            // Enemy texture
            enemyBullet = theContent.Load<Texture2D>("Texture/enemy_bullet");
            enemyYellow = new Texture2D[2] 
            {
                theContent.Load<Texture2D>("Texture/enemy_yellow_0"),
                theContent.Load<Texture2D>("Texture/enemy_yellow_1")
            };
            enemyRed = new Texture2D[2] 
            {
                theContent.Load<Texture2D>("Texture/enemy_red_0"),
                theContent.Load<Texture2D>("Texture/enemy_red_1")
            };
            enemyTop = new Texture2D[2] 
            {
                theContent.Load<Texture2D>("Texture/enemy_top_0"),
                theContent.Load<Texture2D>("Texture/enemy_top_1")
            };
            enemyDestroyed = new Texture2D[5] 
            {
                theContent.Load<Texture2D>("Texture/enemy_destroy_0"),
                theContent.Load<Texture2D>("Texture/enemy_destroy_1"),
                theContent.Load<Texture2D>("Texture/enemy_destroy_2"),
                theContent.Load<Texture2D>("Texture/enemy_destroy_3"),
                theContent.Load<Texture2D>("Texture/enemy_destroy_4")
            };

        }
    }
}
