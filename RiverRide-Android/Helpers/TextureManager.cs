﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRide_Android.Helpers
{
    public class TextureManager
    {
        // Controls
        public Texture2D leftUp;
        public Texture2D up;
        public Texture2D rightUp;
        public Texture2D leftMiddle;
        public Texture2D rightMiddle;
        public Texture2D leftDown;
        public Texture2D down;
        public Texture2D rightDown;

        // Player
        public Texture2D[] plane;
        public Texture2D bullet;

        // Map Tiles
        public Texture2D[] mapTiles;

        public TextureManager(ContentManager theContent)
        {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent)
        {
            // Controls
            leftUp = theContent.Load<Texture2D>("Texture/left-up");
            up = theContent.Load<Texture2D>("Texture/up");
            rightUp = theContent.Load<Texture2D>("Texture/right-up");
            leftMiddle = theContent.Load<Texture2D>("Texture/left-middle");
            rightMiddle = theContent.Load<Texture2D>("Texture/right-middle");
            leftDown = theContent.Load<Texture2D>("Texture/left-down");
            down = theContent.Load<Texture2D>("Texture/down");
            rightDown = theContent.Load<Texture2D>("Texture/right-down");

            // Player
            plane = new Texture2D[3] 
            {
                theContent.Load<Texture2D>("Texture/plane-left"),
                theContent.Load<Texture2D>("Texture/plane"),
                theContent.Load<Texture2D>("Texture/plane-right")            
            };
            bullet = theContent.Load<Texture2D>("Texture/bullet");

            // Map Tiles
            mapTiles = new Texture2D[8]
            {
                theContent.Load<Texture2D>("Texture/map-0"),
                theContent.Load<Texture2D>("Texture/map-1"),
                theContent.Load<Texture2D>("Texture/map-2"),
                theContent.Load<Texture2D>("Texture/map-3"),
                theContent.Load<Texture2D>("Texture/map-4"),
                theContent.Load<Texture2D>("Texture/map-5"),
                theContent.Load<Texture2D>("Texture/map-6"),
                theContent.Load<Texture2D>("Texture/map-7")
            };
        }
    }
}