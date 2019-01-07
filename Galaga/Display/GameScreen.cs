
using Galaga.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Galaga.Display
{
    class GameScreen : Screen
    {
        Ship player;
        Enemy enemyRight, enemyLeft;
        List<Enemy> enemies = new List<Enemy>();
        const int STAR_SIZE = 40;
        List<Star> stars = new List<Star>();

        SpriteFont dosFont;

        int[] spawnEnemy = new int[5] { 4, 8, 8, 8, 8 };
        int spaceBetween = 0;
        int score = 0;

        double elapsedTime = 0, timeToUpdate = 200, fourSec = 3000;

        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            dosFont = theContent.Load<SpriteFont>("Font/DOS_Font");

            player = new Ship(Game1.textureManager.player, screenRectangle);
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

            player.Update(theTime);

            foreach (Bullet bullet in player.bullets)
            {
                bullet.Update(theTime);
                foreach (Enemy enemy in enemies)
                {
                    if (!enemy.isDestroyed && !bullet.isRemoved && bullet.Location.Intersects(enemy.Location))
                    {
                        enemy.isDestroyed = true;
                        bullet.isRemoved = true;
                        switch (enemy.Name)
                        {
                            case "Bee":
                                score += 10;
                                break;
                            case "Butterfly":
                                score += 80;
                                break;
                            case "Galaga Boss":
                                score += 150;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }


            elapsedTime += theTime.ElapsedGameTime.TotalMilliseconds;
        
            if (elapsedTime > timeToUpdate * 5)
            {
                stars.Add(new Star());
            }
            if (spawnEnemy[0] != 0)
            {
                if (elapsedTime > timeToUpdate)
                {
                    elapsedTime -= timeToUpdate;
                    enemyRight = new Enemy("Bee", "firstEncounterOne", Game1.textureManager.enemyYellow);
                    enemyLeft = new Enemy("Butterfly", "firstEncounterTwo", Game1.textureManager.enemyRed);

                    enemies.Add(enemyLeft);
                    enemies.Add(enemyRight);
                    spaceBetween += 49;
                    spawnEnemy[0]--;
                }
            }

            if (spawnEnemy[1] != 0)
            {
                if (elapsedTime > fourSec)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        if (Level.whichEnemy % 2 == 0)
                            enemyLeft = new Enemy("Galaga Boss", "secondEncounter", Game1.textureManager.enemyTop);
                        else
                            enemyLeft = new Enemy("Butterfly", "secondEncounter", Game1.textureManager.enemyRed);

                        enemies.Add(enemyLeft);
                        spaceBetween += 49;
                        spawnEnemy[1]--;
                    }
                }
            }

            if (spawnEnemy[2] != 0)
            {
                if (elapsedTime > 2*fourSec)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyRight = new Enemy("Butterfly", "thirdEncounter", Game1.textureManager.enemyRed);

                        enemies.Add(enemyRight);
                        spaceBetween += 49;
                        spawnEnemy[2]--;
                    }
                }
            }
            if (spawnEnemy[3] != 0)
            {
                if (elapsedTime > 3 * fourSec)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyLeft = new Enemy("Bee", "fourthEncounter", Game1.textureManager.enemyYellow);

                        enemies.Add(enemyLeft);
                        spaceBetween += 49;
                        spawnEnemy[3]--;
                    }
                }
            }

            if (spawnEnemy[4] != 0)
            {
                if (elapsedTime > 4 * fourSec)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyRight = new Enemy("Bee", "fifthEncounter", Game1.textureManager.enemyYellow);

                        enemies.Add(enemyRight);
                        spaceBetween += 49;
                        spawnEnemy[4]--;
                    }
                }
            }


            foreach (Enemy enemy in enemies)
                enemy.Update(theTime);

            foreach (Star star in stars)
                star.Update(theTime);
           

        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.DrawString(dosFont, "SCORE", new Vector2(10, 10), Color.Red);
            theBatch.DrawString(dosFont, "" + stars.Count, new Vector2(10, 40), Color.White);
            player.Draw(theBatch);
            foreach (Bullet bullet in player.bullets)
                bullet.Draw(theBatch);
            foreach (Enemy enemy in enemies)
                enemy.Draw(theBatch);
            for (int i = stars.Count - 1; i >= 0; i--)
            {
                stars[i].Draw(theBatch);
            }
            base.Draw(theBatch);
        }
        public void StartGame()
        {
            stars.Clear();
            enemies.Clear();
            player.bullets.Clear();
            isGameStarted = true;
            isGameOver = false;

            elapsedTime = 0;
            spawnEnemy = new int[5] { 4, 8, 8, 8, 8};
            spaceBetween = 0;
            score = 0;
            Level.whichEnemy = 0;

            for (int i = 0; i < STAR_SIZE; i++)
            {
                stars.Add(new Star());
            }
        }
    }
}

