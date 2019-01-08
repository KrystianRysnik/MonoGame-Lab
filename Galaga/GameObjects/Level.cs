using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.GameObjects
{
    public class Level
    {
        public static Vector2 firstEncounterOne = new Vector2(343 + 30, -60);
        public static Vector2 firstEncounterTwo = new Vector2(343 - 30, -60);
        public static Vector2 secondEncounter = new Vector2(-60, 550);
        public static Vector2 thirdEncounter = new Vector2(686 - 45 + 60, 550);
        public static Vector2 fourthEncounter = new Vector2(383 - 45, - 60);
        public static Vector2 fifthEncounter = new Vector2(383 - 45, - 60);
        public static Vector2[] endPosition = new Vector2[40]
        {

            // 122, 171, 220, 269, 318, 367, 416, 465, 514, 563
            // 122, 171, 220, 269, 318, 367, 416, 465, 514, 563
            // First
            new Vector2(318, 206), new Vector2(318, 102),
            new Vector2(367, 206), new Vector2(367, 102),
            new Vector2(318, 258), new Vector2(318, 154),
            new Vector2(367, 258), new Vector2(367, 154),
            // Second
            new Vector2(269, 102), new Vector2(269, 50),
            new Vector2(416, 102),new Vector2(318, 50), 
            new Vector2(269, 154), new Vector2(367, 50),
            new Vector2(416, 154), new Vector2(416, 50), 
            // Third
            new Vector2(171, 102), new Vector2(465, 102),
            new Vector2(220, 102), new Vector2(514, 102),
            new Vector2(171, 154), new Vector2(465, 154),
            new Vector2(220, 154), new Vector2(514, 154),
            // Fourth
            new Vector2(220, 206), new Vector2(416, 206),
            new Vector2(269, 206), new Vector2(465, 206),
            new Vector2(220, 258), new Vector2(416, 258),
            new Vector2(269, 258), new Vector2(465, 258),
            // Fifth
            new Vector2(122, 206), new Vector2(514, 206),
            new Vector2(171, 206), new Vector2(563, 206),
            new Vector2(122, 258), new Vector2(514, 258),
            new Vector2(171, 258), new Vector2(563, 258)
        };

        /**
         * FIRST ENCOUNTER
         */
        public static List<Vector2> FirstEncounterOnePath(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {  
                newPoint = GetPoint(t, new Vector2(firstEncounterOne.X, 0), new Vector2(firstEncounterOne.X, 250), new Vector2(firstEncounterOne.X - 184, 250), new Vector2(firstEncounterOne.X - 184 - 60, 250));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(firstEncounterOne.X - 184 - 60, 250), new Vector2(firstEncounterOne.X - 184 - 60 - 100, 250), new Vector2(firstEncounterOne.X - 184 - 60 - 100, 500), new Vector2(firstEncounterOne.X - 184 - 60, 500));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(firstEncounterOne.X - 184 - 60, 500), new Vector2(firstEncounterOne.X - 184 - 60 + 40, 500), new Vector2(343, 500), new Vector2(343, 300));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }

        public static List<Vector2> FirstEncounterTwoPath(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {   
                newPoint = GetPoint(t, new Vector2(firstEncounterTwo.X, 0), new Vector2(firstEncounterTwo.X, 250), new Vector2(firstEncounterTwo.X + 184, 250), new Vector2(firstEncounterTwo.X + 184 + 60, 250));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {              
                newPoint = GetPoint(t, new Vector2(firstEncounterTwo.X + 184 + 60, 250), new Vector2(firstEncounterTwo.X + 184 + 60 + 100, 250), new Vector2(firstEncounterTwo.X + 184 + 60 + 100, 500), new Vector2(firstEncounterTwo.X + 184 + 60, 500));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(firstEncounterTwo.X + 184 + 60, 500), new Vector2(firstEncounterTwo.X + 184 + 60 - 40, 500), new Vector2(343, 500), new Vector2(343, 300));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }

        /**
         * SECOND ENCOUNTER
         */
        public static List<Vector2> SecondEncounterPath(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60, 550), new Vector2(secondEncounter.X + 60 + 100, 530), new Vector2(secondEncounter.X + 60 + 230, 460), new Vector2(secondEncounter.X + 60 + 240, 350));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60 + 240, 350), new Vector2(secondEncounter.X + 60 + 240, 230), new Vector2(secondEncounter.X + 60 + 40, 230), new Vector2(secondEncounter.X + 60 + 40, 350));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60 + 40, 350), new Vector2(secondEncounter.X + 60 + 40, 500), new Vector2(secondEncounter.X + 60 + 240, 510), new Vector2(secondEncounter.X + 60 + 260, 290));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }

        /**
        * THIRD ENCOUNTER
        */
        public static List<Vector2> ThirdEncounterPath(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60, 550), new Vector2(thirdEncounter.X - 60 - 100, 530), new Vector2(thirdEncounter.X - 60 - 230, 460), new Vector2(thirdEncounter.X - 60 - 240, 350));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60 - 240, 350), new Vector2(thirdEncounter.X - 60 - 240, 230), new Vector2(thirdEncounter.X - 60 - 40, 230), new Vector2(thirdEncounter.X - 60 - 40, 350));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60 - 40, 350), new Vector2(thirdEncounter.X - 60 - 40, 500), new Vector2(thirdEncounter.X - 60 - 240, 510), new Vector2(thirdEncounter.X - 60 - 260, 290));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }

        /**
        * FORTH ENCOUNTER
        */
        public static List<Vector2> FourthEncounter(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(fourthEncounter.X, 0), new Vector2(fourthEncounter.X, 282), new Vector2(fourthEncounter.X - 268, 150), new Vector2(fourthEncounter.X -268, 300));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(fourthEncounter.X - 268, 300), new Vector2(fourthEncounter.X - 268, 500), new Vector2(fourthEncounter.X, 500), new Vector2(fourthEncounter.X, 300));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }

        /**
        * FIFTH ENCOUNTER
        */
        public static List<Vector2> FifthEncounter(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(fourthEncounter.X, 0), new Vector2(fourthEncounter.X, 282), new Vector2(fourthEncounter.X + 268, 150), new Vector2(fourthEncounter.X + 268, 300));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(fourthEncounter.X + 268, 300), new Vector2(fourthEncounter.X + 268, 500), new Vector2(fourthEncounter.X, 500), new Vector2(fourthEncounter.X, 300));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            return list;
        }
        public static List<Vector2> Diving(List<Vector2> list, int whichEnemy)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(endPosition[whichEnemy].X, endPosition[whichEnemy].Y), new Vector2(endPosition[whichEnemy].X - 190, endPosition[whichEnemy].Y + 170), new Vector2(endPosition[whichEnemy].X + 330, endPosition[whichEnemy].Y + 650), new Vector2(endPosition[whichEnemy].X, endPosition[whichEnemy].Y + 680));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(endPosition[whichEnemy].X, endPosition[whichEnemy].Y + 680), new Vector2(endPosition[whichEnemy].X - 240, endPosition[whichEnemy].Y - 680), new Vector2(endPosition[whichEnemy].X + 30, endPosition[whichEnemy].Y + 300), new Vector2(endPosition[whichEnemy].X, endPosition[whichEnemy].Y));
                list.Add(newPoint);
            }
            return list;
        }
        static Vector2 GetPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            float cx = 3 * (p1.X - p0.X);
            float cy = 3 * (p1.Y - p0.Y);

            float bx = 3 * (p2.X - p1.X) - cx;
            float by = 3 * (p2.Y - p1.Y) - cy;

            float ax = p3.X - p0.X - cx - bx;
            float ay = p3.Y - p0.Y - cy - by;

            float Cube = t * t * t;
            float Square = t * t;

            float resX = (ax * Cube) + (bx * Square) + (cx * t) + p0.X;
            float resY = (ay * Cube) + (by * Square) + (cy * t) + p0.Y;

            return new Vector2(resX, resY);
        }
    }
}
