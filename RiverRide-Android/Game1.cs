using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using RiverRide_Android.Display;
using RiverRide_Android.Helpers;
using System;

namespace RiverRide_Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static TextureManager textureManager;

        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameScreen mGameScreen;
        TitleScreen mTitleScreen;
        Screen mCurrentScreen;

        RenderTarget2D renderTarget;
        Rectangle dst;
        public Rectangle screenRectangle;

        public static float scaleX;
        public static float scaleY;
        public static Matrix scaleMatrix;
        public static Viewport viewport;

        public string contentRootDirectory;

        public int WIDTH = 1280, HEIGHT = 720;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentRootDirectory = Content.RootDirectory;

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
            graphics.ApplyChanges();

            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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
            PresentationParameters presentationParam = graphics.GraphicsDevice.PresentationParameters;

            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, WIDTH, HEIGHT, false, SurfaceFormat.Color, DepthFormat.None, presentationParam.MultiSampleCount, RenderTargetUsage.DiscardContents); // RenderTargetUsage.PreserveContents
            dst = calculateAspectRectangle();

            scaleX = (float)GraphicsDevice.Viewport.Width / WIDTH;
            scaleY = (float)GraphicsDevice.Viewport.Height / HEIGHT;
            scaleMatrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);

            viewport = GraphicsDevice.Viewport;

            TouchPanel.EnabledGestures = GestureType.HorizontalDrag | GestureType.DragComplete | GestureType.VerticalDrag;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textureManager = new TextureManager(this.Content);

            // TODO: use this.Content to load your game content here
            mGameScreen = new GameScreen(screenRectangle, graphics, this.Content, new EventHandler(GameScreenEvent));
            mTitleScreen = new TitleScreen(screenRectangle, this.Content, new EventHandler(TitleScreenEvent));
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
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(new Color(110, 156, 66));

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(new Color(110, 156, 66));

            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, dst, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                renderTarget.Dispose();
                renderTarget = null;
            }
            base.Dispose(disposing);
        }
        public void GameScreenEvent(object obj, EventArgs e)
        {
          

        }
        public void TitleScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = mGameScreen;
            mGameScreen.StartGame();
        }

        protected Rectangle calculateAspectRectangle()
        {
            Rectangle dst = new Rectangle();

            float outputAspect = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            float preferredAspect = WIDTH / (float)HEIGHT;


            if (outputAspect <= preferredAspect)
            {
                int presentHeight = (int)((Window.ClientBounds.Width / preferredAspect) + 0.5f);
                int barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

                dst = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
            }
            else
            {
                int presentWidth = (int)((Window.ClientBounds.Width * preferredAspect) + 0.5f);
                int barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

                dst = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
            }

            return dst;
        }
   
    }
}
