
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
        Rectangle screenRectangle;

        SpriteFont dosFont;

        int[] spawnEnemy = new int[5] { 4, 8, 8, 8, 8 };
        int score = 0;
        int whichEnemy = -1;
        int stage = 1;
        int dive = 0;
        bool isNewStage = false;
        Random random;

        double elapsedTime = 0, timeToUpdate = 200, fourSec = 3000;

        public GameScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;
            random = new Random();

            dosFont = theContent.Load<SpriteFont>("Font/DOS_Font");
            player = new Ship(Game1.textureManager.ship, screenRectangle);
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

            if (!player.isLive)
            {
                isGameOver = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    StartGame();
                }
            }

            foreach (Bullet bullet in player.bullets)
            {
                bullet.Update(theTime);
                foreach (Enemy enemy in enemies)
                {
                    if (!enemy.isDestroyed && !bullet.isRemoved
                        && bullet.Location.Intersects(new Rectangle(enemy.Location.X - enemy.Location.Width / 2, enemy.Location.Y - enemy.Location.Height / 2, enemy.Location.Width, enemy.Location.Height)))
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

            if (spawnEnemy[0] != 0)
            {
                if (elapsedTime > fourSec)
                {
                    isNewStage = false;
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyRight = new Enemy("Bee", "firstEncounterOne", Game1.textureManager.enemyYellow, ++whichEnemy);
                        enemyLeft = new Enemy("Butterfly", "firstEncounterTwo", Game1.textureManager.enemyRed, ++whichEnemy);

                        enemies.Add(enemyLeft);
                        enemies.Add(enemyRight);
                        spawnEnemy[0]--;
                    }
                }
            }

            if (spawnEnemy[1] != 0)
            {
                if (elapsedTime > fourSec * 2)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        if (whichEnemy % 2 == 0)
                            enemyLeft = new Enemy("Galaga Boss", "secondEncounter", Game1.textureManager.enemyTop, ++whichEnemy);
                        else
                            enemyLeft = new Enemy("Butterfly", "secondEncounter", Game1.textureManager.enemyRed, ++whichEnemy);

                        enemies.Add(enemyLeft);
                        spawnEnemy[1]--;
                    }
                }
            }

            if (spawnEnemy[2] != 0)
            {
                if (elapsedTime > fourSec * 3)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyRight = new Enemy("Butterfly", "thirdEncounter", Game1.textureManager.enemyRed, ++whichEnemy);

                        enemies.Add(enemyRight);
                        spawnEnemy[2]--;
                    }
                }
            }
            if (spawnEnemy[3] != 0)
            {
                if (elapsedTime > fourSec * 4)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyLeft = new Enemy("Bee", "fourthEncounter", Game1.textureManager.enemyYellow, ++whichEnemy);

                        enemies.Add(enemyLeft);
                        spawnEnemy[3]--;
                    }
                }
            }

            if (spawnEnemy[4] != 0)
            {
                if (elapsedTime > fourSec * 5)
                {
                    if (elapsedTime > timeToUpdate)
                    {
                        elapsedTime -= timeToUpdate;
                        enemyRight = new Enemy("Bee", "fifthEncounter", Game1.textureManager.enemyYellow, ++whichEnemy);

                        enemies.Add(enemyRight);
                        spawnEnemy[4]--;
                    }
                }
            }


            foreach (Enemy enemy in enemies)
            {
                enemy.Update(theTime);
                if (enemy.Location.Intersects(player.Location))
                {
                    player.isDestroyed = true;                 
                }
                foreach (EnemyBullet bullet in enemy.enemyBullets)
                {
                    bullet.Update(theTime);
                    if (bullet.Location.Intersects(player.Location))
                    {
                        player.isDestroyed = true;
                    }
                }
            }

            if (stars.Count <= STAR_SIZE)
                stars.Add(new Star());

            foreach (Star star in stars)
                star.Update(theTime);

            if (spawnEnemy[4] == 0)
            {

                if (enemies.Count == 0)
                {
                    NextStage();
                }
                else if (elapsedTime > fourSec * 6)
                {
                    if (elapsedTime > timeToUpdate * 5)
                    {
                        elapsedTime -= timeToUpdate * 10;
                        if (enemies.Count > 1)
                        {
                            try
                            {
                                enemies[dive].isDiving = true;
                                dive++;
                                if (dive > enemies.Count - 1)
                                {
                                    dive = 0;
                                    elapsedTime -= fourSec * 10;

                                }
                            }
                            catch (ArgumentOutOfRangeException e) { };
                        }
                    }
                }
            }
        }
        
        public override void Draw(SpriteBatch theBatch)
        {
            player.Draw(theBatch);
            foreach (Bullet bullet in player.bullets)
            {
                bullet.Draw(theBatch);
            }
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Draw(theBatch);
                foreach (EnemyBullet bullet in enemies[i].enemyBullets)
                {
                    bullet.Draw(theBatch);
                }
                if (enemies[i].isLive == false)
                    enemies.Remove(enemies[i]);
            }
            for (int i = stars.Count - 1; i >= 0; i--)
            {
                stars[i].Draw(theBatch);
                if (stars[i].isVisible == false)
                    stars.Remove(stars[i]);
            }

            if (isGameOver)
            {
                theBatch.DrawString(dosFont, "GAME OVER", new Vector2(screenRectangle.Width / 2 - 79, screenRectangle.Height / 2 - 100), new Color(68, 255, 255));
                theBatch.DrawString(dosFont, "SCORE", new Vector2(screenRectangle.Width / 2 - 43, screenRectangle.Height / 2 - 50), Color.Red);
                theBatch.DrawString(dosFont, "" + score, new Vector2(screenRectangle.Width / 2 - 43, screenRectangle.Height / 2), Color.White);
                theBatch.DrawString(dosFont, "PRESS SPACE TO PLAY AGAIN", new Vector2(screenRectangle.Width / 2 - 223, screenRectangle.Height / 2 + 200), new Color(68, 255, 255));
            }
            else
            {
                theBatch.DrawString(dosFont, "SCORE", new Vector2(10, 10), Color.Red);
                theBatch.DrawString(dosFont, "" + score, new Vector2(10, 40), Color.White);
                theBatch.DrawString(dosFont, "STAGE ", new Vector2(10, screenRectangle.Height - 60), Color.Red);
                theBatch.DrawString(dosFont, "" + stage, new Vector2(110, screenRectangle.Height - 60), Color.White);
                if (isNewStage == true)
                {
                    theBatch.DrawString(dosFont, "STAGE " + stage, new Vector2(screenRectangle.Width / 2 - dosFont.Texture.Width / 2, screenRectangle.Height / 2 - dosFont.Texture.Height / 2), Color.Red);
                }
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
            isNewStage = true;
            player = new Ship(Game1.textureManager.ship, screenRectangle);

            elapsedTime = 0;
            spawnEnemy = new int[5] { 4, 8, 8, 8, 8 };
            score = 0;
            stage = 1;
            whichEnemy = -1;
        }
        private void NextStage()
        {
            stage++;
            whichEnemy = -1;
            enemies.Clear();
            player.bullets.Clear();
            spawnEnemy = new int[5] { 4, 8, 8, 8, 8 };
            elapsedTime = 0;
            isNewStage = true;
        }
    }
}

