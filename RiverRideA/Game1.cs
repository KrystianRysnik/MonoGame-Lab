using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RiverRideA.Display;
using System;

namespace RiverRideA
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        TitleScreen mTitleScreen;
        MainMenuScreen mMainMenuScreen;
        Screen mCurrentScreen;
        GameScreen mGameScreen;
        PauseScreen mPauseScreen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public KeyboardState previousState;
        public Rectangle screenRectangle;

        public string contentRootDirectory;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentRootDirectory = Content.RootDirectory;

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

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
            mTitleScreen = new TitleScreen(this.graphics, this.Content, new EventHandler(TitleScreenEvent));
            mMainMenuScreen = new MainMenuScreen(this.graphics, this.Content, new EventHandler(MainMenuScreenEvent));
            mGameScreen = new GameScreen(this.graphics, this.Content, new EventHandler(GameScreenEvent));
            mPauseScreen = new PauseScreen(this.graphics, this.Content, new EventHandler(PauseScreenEvent));

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
        public void TitleScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                mCurrentScreen = mMainMenuScreen;
        }

        public void MainMenuScreenEvent(Object obj, EventArgs e)
        {
            // 
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

        public void GameScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) & !previousState.IsKeyDown(Keys.P))
                mCurrentScreen = mPauseScreen;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) & !previousState.IsKeyDown(Keys.Escape))
                mCurrentScreen = mMainMenuScreen; ;
        }

        public void PauseScreenEvent(object obj, EventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) & !previousState.IsKeyDown(Keys.P))
                mCurrentScreen = mGameScreen;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) & !previousState.IsKeyDown(Keys.Escape))
                mCurrentScreen = mMainMenuScreen;
        }
    }
}
