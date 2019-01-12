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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRide_Android.GameObjects
{
    class HUD
    {
        Rectangle screenRectangle;

        //Texture2D bgHud;

        public static TouchButton leftUpBtn;
        public static TouchButton upBtn;
        public static TouchButton rightUpBtn;
        public static TouchButton leftMiddleBtn;
        public static TouchButton rightMiddleBtn;
        public static TouchButton leftDownBtn;
        public static TouchButton downBtn;
        public static TouchButton rightDownBtn;

        public HUD(Rectangle screenRectangle)
        {
            this.screenRectangle = screenRectangle;

            // Background for HUD
            //  bgHud = new Texture2D(graphics.GraphicsDevice, screenRectangle.Width, 200);
            //   Color[] data = new Color[screenRectangle.Width * 200];
            //   for (int i = 0; i < data.Length; ++i)
            //      data[i] = new Color(142, 142, 142);
            // bgHud.SetData(data);

            leftUpBtn = new TouchButton("leftUp", Game1.textureManager.leftUp, new Vector2(10, this.screenRectangle.Height - 3 * Game1.textureManager.leftUp.Height - 10));
            upBtn = new TouchButton("up", Game1.textureManager.up, new Vector2(10 + Game1.textureManager.up.Width, this.screenRectangle.Height - 3 * Game1.textureManager.up.Height - 10));
            rightUpBtn = new TouchButton("rightUp", Game1.textureManager.rightUp, new Vector2(10 + Game1.textureManager.rightUp.Width * 2, this.screenRectangle.Height - 3 * Game1.textureManager.rightUp.Height - 10));

            leftMiddleBtn = new TouchButton("leftMiddle", Game1.textureManager.leftMiddle, new Vector2(10, this.screenRectangle.Height - 2 * Game1.textureManager.leftMiddle.Height - 10));
            rightMiddleBtn = new TouchButton("rightMiddle", Game1.textureManager.rightMiddle, new Vector2(10 + Game1.textureManager.rightMiddle.Width * 2, this.screenRectangle.Height - 2 * Game1.textureManager.leftMiddle.Height - 10));

            leftDownBtn = new TouchButton("leftDown", Game1.textureManager.leftDown, new Vector2(10, this.screenRectangle.Height - Game1.textureManager.leftDown.Height - 10));
            downBtn = new TouchButton("down", Game1.textureManager.down, new Vector2(10 + Game1.textureManager.down.Width, this.screenRectangle.Height - Game1.textureManager.down.Height - 10));
            rightDownBtn = new TouchButton("rightDown", Game1.textureManager.rightDown, new Vector2(10 + Game1.textureManager.rightDown.Width * 2, this.screenRectangle.Height - Game1.textureManager.rightDown.Height - 10));

        }

        public void Update(GameTime gameTime)
        {
       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(bgHud, new Vector2(0, screenRectangle.Height - bgHud.Height), Color.White);
            leftUpBtn.Draw(spriteBatch);
            upBtn.Draw(spriteBatch);
            rightUpBtn.Draw(spriteBatch);

            leftMiddleBtn.Draw(spriteBatch);
            rightMiddleBtn.Draw(spriteBatch);

            leftDownBtn.Draw(spriteBatch);
            downBtn.Draw(spriteBatch);
            rightDownBtn.Draw(spriteBatch);
        }
    }
}