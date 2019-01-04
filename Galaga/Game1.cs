using Galaga.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Galaga
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GameScreen mGameScreen;
        TitleScreen mTitleScreen;
        PauseScreen mPauseScreen;
        MainMenuScreen mMainMenuScreen;
        Screen mCurrentScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public KeyboardState previousState;
        public Rectangle screenRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 720;

            screenRectangle = new Rectangle(
                0,
                0,
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mGameScreen = new GameScreen(this.Content, screenRectangle, new EventHandler(GameScreenEvent));
            mTitleScreen = new TitleScreen(this.graphics, this.Content, new EventHandler(TitleScreenEvent));
            mPauseScreen = new PauseScreen(this.graphics, this.Content, new EventHandler(PauseScreenEvent));
            mMainMenuScreen = new MainMenuScreen(this.graphics, this.Content, new EventHandler(MainMenuScreenEvent));

            mCurrentScreen = mTitleScreen;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            mCurrentScreen.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void GameScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) & !previousState.IsKeyDown(Keys.P))
                mCurrentScreen = mPauseScreen;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) & !previousState.IsKeyDown(Keys.Escape))
                mCurrentScreen = mMainMenuScreen; ;
        }
        public void TitleScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                mCurrentScreen = mMainMenuScreen;
        }
        public void PauseScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) & !previousState.IsKeyDown(Keys.P))
                mCurrentScreen = mGameScreen;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) & !previousState.IsKeyDown(Keys.Escape))
                mCurrentScreen = mMainMenuScreen;
        }
        public void MainMenuScreenEvent(Object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) & !previousState.IsKeyDown(Keys.Enter))
            {
                switch (mMainMenuScreen.choose)
                {
                    case 0:
                        mCurrentScreen = mGameScreen;
                        mGameScreen.StartGame();
                        break;
                    case 1:
                        Exit();
                        break;
                    case 2:
                        mCurrentScreen = mGameScreen;
                        break;
                }
            }
        }
    }
}
