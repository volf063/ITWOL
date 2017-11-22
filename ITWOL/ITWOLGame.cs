using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ITWOL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ITWOLGame : Game
    {

        /*/
        /// <summary>
        /// testGrid - текстура тестовой сетки с шагом линия в каждые сто пикселей
        /// </summary>
        Texture2D testGrid;

        private SpriteFont fontSmall;
        private SpriteFont fontMedium;
        private SpriteFont fontNormal;

        KeyboardState keys;
        //MouseState mouse;

        /// <summary>
        /// курсор
        /// </summary>
        Texture2D cursorDefault; //Спрайт с изображением-курсором
        Rectangle cursorPosition; //Текущая позиция курсора 
        /*/


        KeyboardState keys;

        Texture2D developerLogo;
        Texture2D gameLogo;

        GraphicsDeviceManager graphics;
        ScreenManager screenManager;
        SpriteBatch spriteBatch;
        ContentManager content;
        Texture2D splashScreen;
        float splashtimer = 0;
        bool menuInit = false;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        // When the time remaining is less than the warning time, it blinks on the hud
        private static readonly TimeSpan WarningTime = TimeSpan.FromSeconds(30);
        
        
        private int TargetFrameRate = 30; //частота смены кадров
        /// <summary>
        /// размеры окна
        /// </summary>
        private int BackBufferWidth = 800; //ширина экрана 
        private int BackBufferHeight = 600; //высота экрана 

        /// <summary>
        /// конструктор класса ITWOLGame
        /// создает игровое окно.
        /// </summary>
        public ITWOLGame()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "GameContent";

            //позиционирование окна по центру экрана вне зависимости от размеров
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (Convert.ToInt32(graphics.PreferredBackBufferHeight / 1.5)));
            //название игры на игровом окне
            Window.Title = "In The Web Of Li(f)e";
            //установка размеров окна, заданных выше
            graphics.PreferredBackBufferWidth = BackBufferWidth;
            graphics.PreferredBackBufferHeight = BackBufferHeight;

            //IsMouseVisible = true; 

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
        }

        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            if (content == null)
                content = new ContentManager(this.Services, "Content");


            /*/
            //загрузка текстуры сетки
            testGrid = content.Load<Texture2D>("testGrid1");

            //загрузка шрифтов
            fontSmall = content.Load<SpriteFont>(@"Fonts\pixSmall");
            fontMedium = content.Load<SpriteFont>(@"Fonts\pix10");
            fontNormal = content.Load<SpriteFont>(@"Fonts\pix12");

            //загрузка текстуры стандартного курсора
            cursorDefault = content.Load<Texture2D>(@"Cursors\cursorDefault");
            /*/


            // TODO: use this.Content to load your game content here

            //загрузка лого разработчика
            developerLogo = content.Load<Texture2D>(@"SplashScreens\developerLogo");
            gameLogo = content.Load<Texture2D>(@"SplashScreens\gameLogo");

            splashScreen = developerLogo;


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

            //exit
             if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                 this.Exit();
             keys = Keyboard.GetState();//Инициализация объекта keys. 

             if (keys.IsKeyDown(Keys.Escape))//Проверяем, нажата ли клавиша   
                 this.Exit();//Если клавиша нажата, то происходит выход 
                             // TODO: Add your update logic here

            /*/
             cursorPosition = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, cursorDefault.Width, cursorDefault.Height);
            /*/


            elapsedTime += gameTime.ElapsedGameTime;



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //очистка главного экрана и заливка его базовым цветом
            GraphicsDevice.Clear(Color.DarkSlateGray);

            // TODO: Add your drawing code here

            
            spriteBatch.Begin();

            /*/ тестовая отрисовка сетки и шрифтов
            spriteBatch.Draw(testGrid, Vector2.Zero, Color.White);
            
            spriteBatch.DrawString(fontSmall, "pixSmall Some Text Рандомный текст", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(fontMedium, "pix10  Some Text Рандомный текст", new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(fontNormal, "pix12  Some Text Рандомный текст", new Vector2(100, 300), Color.White);
            //отрисовка курсора поверх всего
            spriteBatch.Draw(cursorDefault, cursorPosition, Color.White);
            /*/

            //отрисовка заставки

            if (elapsedTime > TimeSpan.FromSeconds(3))
                splashScreen = gameLogo;

            spriteBatch.Draw(splashScreen, Vector2.Zero, Color.White);


            spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
