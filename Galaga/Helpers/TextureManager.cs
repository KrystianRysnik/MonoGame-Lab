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
        public Texture2D star_0,
            star_1,
            star_2,
            star_3;
        public Texture2D[] stars = new Texture2D[4];

        // Ship texture
        public Texture2D[] player = new Texture2D[3];

        public Texture2D bullet;
        public Texture2D ship;

        public Texture2D shipDestroy_0;
        public Texture2D shipDestroy_1;

        // Enemy
        public Texture2D enemyYellow_0;
        public Texture2D enemyYellow_1;
        public Texture2D[] enemyYellow = new Texture2D[2];

        public Texture2D enemyRed_0;
        public Texture2D enemyRed_1;
        public Texture2D[] enemyRed = new Texture2D[2];

        public Texture2D enemyTop_0;
        public Texture2D enemyTop_1;
        public Texture2D[] enemyTop = new Texture2D[2];

        // Enemy explosion
        public Texture2D enemyDestroyed_0;
        public Texture2D enemyDestroyed_1;
        public Texture2D enemyDestroyed_2;
        public Texture2D enemyDestroyed_3;
        public Texture2D enemyDestroyed_4;
        public Texture2D[] enemyDestroyed = new Texture2D[5];

        public TextureManager(ContentManager theContent)
        {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent)
        {
            // GUI
            splashScreen = theContent.Load<Texture2D>("Image/logo");

            // Stars
            star_0 = theContent.Load<Texture2D>("Texture/star_1");
            star_1 = theContent.Load<Texture2D>("Texture/star_2");
            star_2 = theContent.Load<Texture2D>("Texture/star_3");
            star_3 = theContent.Load<Texture2D>("Texture/star_4");
            stars[0] = star_0;
            stars[1] = star_1;
            stars[2] = star_2;
            stars[3] = star_3;

            // Bullet texture;
            bullet = theContent.Load<Texture2D>("Texture/bullet");

            // Ship texture
            ship = theContent.Load<Texture2D>("Texture/ship");
            shipDestroy_0 = theContent.Load<Texture2D>("Texture/ship_destroy_0");
            shipDestroy_1 = theContent.Load<Texture2D>("Texture/ship_destroy_1");

            // Player
            player[0] = ship;
            player[1] = shipDestroy_0;
            player[2] = shipDestroy_1;

            // Enemy yellow
            enemyYellow_0 = theContent.Load<Texture2D>("Texture/enemy_yellow_0");
            enemyYellow_1 = theContent.Load<Texture2D>("Texture/enemy_yellow_1");
            enemyYellow[0] = enemyYellow_0;
            enemyYellow[1] = enemyYellow_1;

            enemyRed_0 = theContent.Load<Texture2D>("Texture/enemy_red_0");
            enemyRed_1 = theContent.Load<Texture2D>("Texture/enemy_red_1");
            enemyRed[0] = enemyRed_0;
            enemyRed[1] = enemyRed_1;

            enemyTop_0 = theContent.Load<Texture2D>("Texture/enemy_top_0");
            enemyTop_1 = theContent.Load<Texture2D>("Texture/enemy_top_1");
            enemyTop[0] = enemyTop_0;
            enemyTop[1] = enemyTop_1;

            // Enemy explosion
            enemyDestroyed_0 = theContent.Load<Texture2D>("Texture/enemy_destroy_0");
            enemyDestroyed_1 = theContent.Load<Texture2D>("Texture/enemy_destroy_1");
            enemyDestroyed_2 = theContent.Load<Texture2D>("Texture/enemy_destroy_2");
            enemyDestroyed_3 = theContent.Load<Texture2D>("Texture/enemy_destroy_3");
            enemyDestroyed_4 = theContent.Load<Texture2D>("Texture/enemy_destroy_4");
            enemyDestroyed[0] = enemyDestroyed_0;
            enemyDestroyed[1] = enemyDestroyed_1;
            enemyDestroyed[2] = enemyDestroyed_2;
            enemyDestroyed[3] = enemyDestroyed_3;
            enemyDestroyed[4] = enemyDestroyed_4;

        }
    }
}
