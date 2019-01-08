using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.GameObjects
{
    class Enemy
    {
        int id;
        string name;
        string formationName;
        Texture2D[] texture;
        Vector2 position;
        float speed = 450f;
        List<Vector2> path = new List<Vector2>();
        float elapsed;
        Rectangle location;
        public bool isLive = true;
        public bool isDestroyed = false;
        public bool isDiving = false;

        int textureIdx = 0;
        int destroyIdx = 0;
        double elapsedTime, timeToUpdate = 500;
        float angle;
        Random random;

        public Rectangle Location { get => location; }
        public List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        public string Name { get => name; }

        public Enemy(string enemyName, string formationName, Texture2D[] texture, int id)
        {
            this.id = id;
            this.name = enemyName;
            this.formationName = formationName;
            this.texture = texture;
            random = new Random();

            // First encounter
            if (formationName == "firstEncounterOne")
            {
                path = Level.FirstEncounterOnePath(path, id);
                this.position = Level.firstEncounterOne;
            }
            else if (formationName == "firstEncounterTwo")
            {
                path = Level.FirstEncounterTwoPath(path, id);
                this.position = Level.firstEncounterTwo;
            }
            else if (formationName == "secondEncounter")
            {
                path = Level.SecondEncounterPath(path, id);
                this.position = Level.secondEncounter;
            }
            else if (formationName == "thirdEncounter")
            {
                path = Level.ThirdEncounterPath(path, id);
                this.position = Level.thirdEncounter;
            }
            else if (formationName == "fourthEncounter")
            {
                path = Level.FourthEncounter(path, id);
                this.position = Level.fourthEncounter;
            }
            else if (formationName == "fifthEncounter")
            {
                path = Level.FifthEncounter(path, id);
                this.position = Level.fifthEncounter;
            }           
        }

        public void Update(GameTime gameTime)
        {
            elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!isDestroyed && isLive)
            {
                if (path.Count > 0 && MoveTowardsPoint(path[0], elapsed))
                    path.RemoveAt(0);
                else if (path.Count == 0)
                    angle = 0;
                

                elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsedTime > timeToUpdate)
                {
                    elapsedTime -= timeToUpdate;

                    if (textureIdx < texture.Length - 1)
                        textureIdx++;
                    else
                        textureIdx = 0;
                }
                if (random.Next() % 12000 <= 2)
                {
                    AddBullet(enemyBullets);
                }
            }
            else if (isDestroyed && isLive)
            {
                elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsedTime > timeToUpdate/2)
                {
                    elapsedTime -= timeToUpdate/2;

                    if (destroyIdx < Game1.textureManager.enemyDestroyed.Length - 1)
                        destroyIdx++;
                    else
                        isLive = false;
                }
            }
            if (isDiving == true)
            {
                Level.Diving(path, id);
                angle = 90;
                isDiving = false;
            }

          

            updateBoundingBox(position);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isLive)
            {
                if (!isDestroyed && isLive)
                {
                    spriteBatch.Draw(texture[textureIdx], Location, null, Color.White, angle, new Vector2(texture[textureIdx].Width/2, texture[textureIdx].Height/2), SpriteEffects.None, 1);
                }
                else if (isDestroyed && isLive)
                {
                    spriteBatch.Draw(Game1.textureManager.enemyDestroyed[destroyIdx], new Vector2(position.X - (Game1.textureManager.enemyDestroyed[destroyIdx].Width/2), position.Y - (Game1.textureManager.enemyDestroyed[destroyIdx].Height/2)), Color.White);
                }
            }
        }
        private bool MoveTowardsPoint(Vector2 goal, float elapsed)
        {
            if (position == goal) return true;
            Vector2 direction = Vector2.Normalize(goal - position);
            angle = (float)Math.Atan2(-direction.X, direction.Y);

            position += direction * speed * elapsed;
                     
            if (Math.Abs(Vector2.Dot(direction, Vector2.Normalize(goal - position)) + 1) < 0.1f)
                position = goal;

            return position == goal;
        }

        private void updateBoundingBox(Vector2 vector)
        {
            location = new Rectangle((int)vector.X, (int)vector.Y, texture[textureIdx].Width, texture[textureIdx].Height);
        }
        public void AddBullet(List<EnemyBullet> enemyBullets)
        {
            var eBullet = new EnemyBullet(Game1.textureManager.enemyBullet, new Rectangle(
                location.X + (texture[textureIdx].Width / 2) - (Game1.textureManager.bullet.Width / 2),
                location.Y - texture[textureIdx].Height,
                texture[textureIdx].Width,
                texture[textureIdx].Height)
                );

            enemyBullets.Add(eBullet);
        }
    }
}
