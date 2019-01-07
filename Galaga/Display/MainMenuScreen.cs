using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Display
{
    class MainMenuScreen : Screen
    {
        Rectangle screenRectangle;
        SpriteFont dosFont;

        Game1 g = new Game1();

        public int choose = 0, itemsInMenu = 1; // 0, 1

        public MainMenuScreen(ContentManager theContent, Rectangle screenRectangle, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.screenRectangle = screenRectangle;

            dosFont = theContent.Load<SpriteFont>("Font/DOS_Font");
        }     
        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) & !g.previousState.IsKeyDown(Keys.Up))
            {
                if (choose == 0)
                    choose = itemsInMenu;
                else
                    choose--;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) & !g.previousState.IsKeyDown(Keys.Down))
            {
                if (choose == itemsInMenu)
                    choose = 0;
                else
                    choose++;
            }
               
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) & !g.previousState.IsKeyDown(Keys.Enter))
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(theTime);

            g.previousState = Keyboard.GetState();
        }

       
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.DrawString(dosFont, "GALAGA", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2 - 100), new Color(68, 255, 255));
            if (isGameStarted == true)
            {
                itemsInMenu = 2;
                theBatch.DrawString(dosFont, choose == 2 ? ">> CONTINUE" : "CONTINUE", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2 - 50), Color.White);
                theBatch.DrawString(dosFont, choose == 0 ? ">> NEW GAME" : "NEW GAME", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2), Color.White);
                theBatch.DrawString(dosFont, choose == 1 ? ">> EXIT" : "EXIT", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2 + 50), Color.White);
            }
            else
            {
                itemsInMenu = 1;
                theBatch.DrawString(dosFont, choose == 0 ? ">> NEW GAME" : "NEW GAME", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2- 50), Color.White);
                theBatch.DrawString(dosFont, choose == 1 ? ">> EXIT" : "EXIT", new Vector2((screenRectangle.Width - dosFont.Texture.Width) / 2, screenRectangle.Height / 2), Color.White);
            }
            base.Draw(theBatch);
        }
    }
}
