using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRideA.Display
{
    class Screen
    {
        protected EventHandler ScreenEvent;
        public static bool isGameStarted = false;
        public static bool isGameOver = false;
        public TouchCollection touchCollection;

        public Screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {
        }
        public virtual void Draw(SpriteBatch theBatch)
        {
        }

        public bool touchSelect(Rectangle target)
        {
            foreach (TouchLocation tl in touchCollection)
            {
                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > target.Left &&
                tl.Position.X < target.Right &&
                tl.Position.Y > target.Top &&
                tl.Position.Y < target.Bottom)
                {
                    return true;
                }
            }
            return false;
        }
    }
}