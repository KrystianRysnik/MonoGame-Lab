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
    class ChooseLevelScreen : Screen
    {
        Viewport viewport;
        SpriteFont menuContinue, menuNewGame, menuExit;
        Texture2D mainmenu;
        Vector2 center;

        Game1 g = new Game1();

        public int choose = 0, itemsInMenu = 2; // 0, 1

        public ChooseLevelScreen(GraphicsDeviceManager theGraphic, ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            viewport = theGraphic.GraphicsDevice.Viewport;
            center = new Vector2(viewport.Width / 2, viewport.Height / 2);

            mainmenu = theContent.Load<Texture2D>("Image/level");
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

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(theTime);

            g.previousState = Keyboard.GetState();
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(mainmenu, new Vector2((viewport.Width - mainmenu.Width) / 2, (viewport.Height - mainmenu.Height) / 2 - 100), Color.White);
            theBatch.DrawString(menuContinue, choose == 0 ? ">> EASY" : "EASY", new Vector2((viewport.Width - menuContinue.Texture.Width) / 2, center.Y - 50), Color.White);
            theBatch.DrawString(menuNewGame, choose == 1 ? ">> MEDIUM" : "MEDIUM", new Vector2((viewport.Width - menuNewGame.Texture.Width) / 2, center.Y), Color.White);
            theBatch.DrawString(menuExit, choose == 2 ? ">> HARD" : "HARD", new Vector2((viewport.Width - menuExit.Texture.Width) / 2, center.Y + 50), Color.White);
            base.Draw(theBatch);
        }
    }
}
