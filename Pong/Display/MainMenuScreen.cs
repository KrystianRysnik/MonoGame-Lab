using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Display
{
    class MainMenuScreen : Screen
    {
        Viewport viewport;
        SpriteFont menuContinue, menuNewGame, menuExit;
        Texture2D mainmenu;
        Vector2 center;

        Game1 g = new Game1();

        public int choose = 0, itemsInMenu = 1; // 0, 1

        public MainMenuScreen(GraphicsDeviceManager theGraphic, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            viewport = theGraphic.GraphicsDevice.Viewport;
            center = new Vector2(viewport.Width / 2, viewport.Height / 2);

            mainmenu = theContent.Load<Texture2D>("Image/mainmenu");
            menuContinue = theContent.Load<SpriteFont>("Font/Menu");
            menuNewGame = theContent.Load<SpriteFont>("Font/Menu");
            menuExit = theContent.Load<SpriteFont>("Font/Menu");
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
            theBatch.Draw(mainmenu, new Vector2((viewport.Width - mainmenu.Width) / 2, (viewport.Height - mainmenu.Height) / 2 - 100), Color.White);
            if (isGameStarted == true)
            {
                itemsInMenu = 2;
                theBatch.DrawString(menuContinue, choose == 2 ? ">> CONTINUE" : "CONTINUE", new Vector2((viewport.Width - menuContinue.Texture.Width) / 2, center.Y - 50), Color.White);
                theBatch.DrawString(menuNewGame, choose == 0 ? ">> NEW GAME" : "NEW GAME", new Vector2((viewport.Width - menuNewGame.Texture.Width) / 2, center.Y), Color.White);
                theBatch.DrawString(menuExit, choose == 1 ? ">> EXIT" : "EXIT", new Vector2((viewport.Width - menuExit.Texture.Width) / 2, center.Y + 50), Color.White);
            }
            else
            {
                itemsInMenu = 1;
                theBatch.DrawString(menuNewGame, choose == 0 ? ">> NEW GAME" : "NEW GAME", new Vector2((viewport.Width - menuNewGame.Texture.Width) / 2, center.Y - 50), Color.White);
                theBatch.DrawString(menuExit, choose == 1 ? ">> EXIT" : "EXIT", new Vector2((viewport.Width - menuExit.Texture.Width) / 2, center.Y), Color.White);
            }
            base.Draw(theBatch);
        }
    }
}
