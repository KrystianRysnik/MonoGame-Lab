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
        public static Vector2 firstEncounterOne = new Vector2(343 + 20, -60);
        public static Vector2 firstEncounterTwo = new Vector2(343 - 45 - 20, -60);
        public static Vector2 secondEncounter = new Vector2(-60, 550);
        public static Vector2 thirdEncounter = new Vector2(686+60, 550);
        public static Vector2 fourthEncounter = new Vector2(383 - 45, - 60);
        public static Vector2 fifthEncounter = new Vector2(383 - 45, - 60);
        public static int whichEnemy = 0;
        public static Vector2[] endPosition = new Vector2[40]
        {
            // First
            new Vector2(296, 206), new Vector2(296, 102),
            new Vector2(345, 206), new Vector2(345, 102),
            new Vector2(296, 258), new Vector2(296, 154),
            new Vector2(345, 258), new Vector2(345, 154),
            // Second
            new Vector2(247, 50), new Vector2(247, 102),
            new Vector2(296, 50), new Vector2(394, 102),
            new Vector2(345, 50), new Vector2(247, 154),
            new Vector2(394, 50), new Vector2(394, 154),
            // Third
            new Vector2(149, 102), new Vector2(443, 102),
            new Vector2(198, 102), new Vector2(482, 102),
            new Vector2(149, 154), new Vector2(443, 154),
            new Vector2(198, 154), new Vector2(482, 154),
            // Fourth
            new Vector2(198, 206), new Vector2(394, 206),
            new Vector2(247, 206), new Vector2(443, 206),
            new Vector2(198, 258), new Vector2(394, 258),
            new Vector2(247, 258), new Vector2(443, 258),
            // Fifth
            new Vector2(100, 206), new Vector2(482, 206),
            new Vector2(149, 206), new Vector2(531, 206),
            new Vector2(100, 258), new Vector2(482, 258),
            new Vector2(149, 258), new Vector2(531, 258)
        };

        /**
         * FIRST ENCOUNTER
         */
        public static List<Vector2> FirstEncounterOnePath(List<Vector2> list)
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
            whichEnemy++;
            return list;
        }

        public static List<Vector2> FirstEncounterTwoPath(List<Vector2> list)
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
            whichEnemy++;
            return list;
        }

        /**
         * SECOND ENCOUNTER
         */
        public static List<Vector2> SecondEncounterPath(List<Vector2> list)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60, 550), new Vector2(secondEncounter.X + 60 + 150, 520), new Vector2(secondEncounter.X + 60 + 290, 320), new Vector2(secondEncounter.X + 60 + 140, 310));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60 + 125, 310), new Vector2(secondEncounter.X + 60, 310), new Vector2(secondEncounter.X + 60 - 100, 450), new Vector2(secondEncounter.X + 60 + 125, 450));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(secondEncounter.X + 60 + 125, 340), new Vector2(secondEncounter.X + 60 + 200, 340), new Vector2(secondEncounter.X + 60 + 235, 325), new Vector2(secondEncounter.X + 60 + 250, 250));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            whichEnemy++;
            return list;
        }

        /**
        * THIRD ENCOUNTER
        */
        public static List<Vector2> ThirdEncounterPath(List<Vector2> list)
        {
            Vector2 newPoint;
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60, 550), new Vector2(thirdEncounter.X - 60 - 150, 520), new Vector2(thirdEncounter.X - 60 - 290, 320), new Vector2(thirdEncounter.X - 60 - 140, 310));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60 - 125, 310), new Vector2(thirdEncounter.X - 60, 310), new Vector2(thirdEncounter.X - 60 + 180, 450), new Vector2(thirdEncounter.X - 60 - 125, 450));
                list.Add(newPoint);
            }
            for (float t = 0; t <= 1.0f; t += 0.1f)
            {
                newPoint = GetPoint(t, new Vector2(thirdEncounter.X - 60 - 125, 340), new Vector2(thirdEncounter.X - 60 - 200, 340), new Vector2(thirdEncounter.X - 60 - 235, 325), new Vector2(thirdEncounter.X - 60 - 250, 250));
                list.Add(newPoint);
            }
            list.Add(endPosition[whichEnemy]);
            whichEnemy++;
            return list;
        }

        /**
        * FORTH ENCOUNTER
        */
        public static List<Vector2> FourthEncounter(List<Vector2> list)
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
            whichEnemy++;
            return list;
        }

        /**
        * FIFTH ENCOUNTER
        */
        public static List<Vector2> FifthEncounter(List<Vector2> list)
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
            whichEnemy++;
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
