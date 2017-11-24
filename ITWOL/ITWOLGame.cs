using ITWOL.Controller;
using ITWOL.Model.GameClasses.Entity;
using ITWOL.View.Screens;
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
    internal class ITWOLGame : Game
    {
        #region Initialization

        //шрифты

        public SpriteFont fontSmall;
        public SpriteFont fontMedium;
        public SpriteFont fontNormal;

        public SpriteFont[] fonts = new SpriteFont[3];
        

        /// <summary>
        /// курсор
        /// </summary>
        Texture2D cursorDefault; //Спрайт с изображением-курсором
        Rectangle cursorPosition; //Текущая позиция курсора 
        //

        GraphicsDeviceManager graphics;
        //ScreenManager screenManager;
        SpriteBatch spriteBatch;
        ContentManager content;
        Texture2D splashScreen; // заставка
        //float splashtimer = 0;
        //bool menuInit = false;
        //int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        InputHandler inputState = new InputHandler();


        //Экран справки
        public CreditsScreen creditsScreen;
        Texture2D creditsBG;
        Texture2D creditsText;
        //Экран меню
        public MenuScreen menuScreen;
        Texture2D menuBG;
        //Texture2D menuGameName;
        Texture2D menuStartGameMain;
        Texture2D menuCredits;
        Texture2D menuExit;
        //Текущий элемент меню
        public int currentMenuItem;
        //Интервал задержки переключения между элементами меню
        public int menuChangeInterval;
        //Игровой экран
        public GameplayScreen newGameScreen;
        Texture2D gameplayInterfaceBG;


        //
        Player player = new Player();
        //

        Texture2D developerLogo;
        Texture2D gameLogo;
        
        //private int TargetFrameRate = 30; //частота смены кадров
        /// <summary>
        /// размеры окна
        /// </summary>
        private int BackBufferWidth = 800; //ширина экрана 
        private int BackBufferHeight = 600; //высота экрана 

        #endregion 


        /// <summary>
        /// конструктор класса ITWOLGame
        /// создает игровое окно.
        /// </summary>
        public ITWOLGame()
        {
            
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            

            Content.RootDirectory = "GameContent";

            //позиционирование окна по центру экрана вне зависимости от размеров
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (Convert.ToInt32(graphics.PreferredBackBufferHeight / 1.5)));
            //название игры на игровом окне
            Window.Title = "In The Web Of Li(f)e";
            //установка размеров окна, заданных выше
            graphics.PreferredBackBufferWidth = BackBufferWidth;
            graphics.PreferredBackBufferHeight = BackBufferHeight;

            graphics.ApplyChanges();
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

            //При запуске игры активным устанавливается первый элемент меню
            currentMenuItem = 1;
            menuChangeInterval = 0;

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
                content = new ContentManager(this.Services, "content");

            /*/
            //загрузка текстуры сетки
            testGrid = content.Load<Texture2D>("testGrid1");
            /*/
            //загрузка шрифтов
            fontSmall = content.Load<SpriteFont>(@"Fonts\pixSmall");
            fontMedium = content.Load<SpriteFont>(@"Fonts\pix10");
            fontNormal = content.Load<SpriteFont>(@"Fonts\pix12");

            fonts[0] = fontSmall;
            fonts[1] = fontMedium;
            fonts[2] = fontNormal;

            //загрузка текстуры стандартного курсора
            cursorDefault = content.Load<Texture2D>(@"Cursors\cursorDefault");
            //

            // TODO: use this.content to load your game content here


            //загрузка лого разработчика
            developerLogo = content.Load<Texture2D>(@"SplashScreens\developerLogo");
            gameLogo = content.Load<Texture2D>(@"SplashScreens\gameLogo");
            
            splashScreen = developerLogo;


            //Загружаем элементы игры и создаем игровые экраны
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            //загрузка контента экрана главного меню
            menuBG = content.Load<Texture2D>(@"Textures\Interface\MainMenu\MainMenuBg");
            //menuGameName = content.Load<Texture2D>("menuGameName");
            menuStartGameMain = content.Load<Texture2D>(@"Textures\Interface\MainMenu\startMain");
            menuCredits = content.Load<Texture2D>(@"Textures\Interface\MainMenu\creditsMenuItem");
            menuExit = content.Load<Texture2D>(@"Textures\Interface\exitMenuItem");
            menuScreen = new MenuScreen(this, menuBG, menuStartGameMain, menuCredits,
                menuExit, new Rectangle(152, 110, 500, 360), new Rectangle(610, 390, 100, 100),
                new Rectangle(725, 520, 70, 70));
            Components.Add(menuScreen);

            //загрузка контента информационного экрана
            creditsBG = content.Load<Texture2D>(@"Textures\Interface\MainMenu\MainMenuBg");
            creditsText = content.Load<Texture2D>(@"Textures\Interface\MainMenu\creditsMenuItem");
            creditsScreen = new CreditsScreen(this, creditsBG, fonts,
                new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height),
                new Rectangle((this.Window.ClientBounds.Width - 200) / 2,
                (this.Window.ClientBounds.Height - 100) / 2,
                100, 100));
            Components.Add(creditsScreen);

            //загрузка контента игрового экрана
            player.LoadContent(content, @"Textures\Skins\Player\playerStatic");
            gameplayInterfaceBG = content.Load<Texture2D>(@"Textures\Interface\GameplayInterface\interfaceBG");
            newGameScreen = new GameplayScreen(this, player, ref gameplayInterfaceBG, 
                new Rectangle(0, 0, 800, 600), Vector2.Zero);
            Components.Add(newGameScreen);

            //Отображаем меню, остальные элементы скрыты
            menuScreen.Show();

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
            
            // TODO: Add your update logic here

            /*/
             cursorPosition = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, cursorDefault.Width, cursorDefault.Height);
            /*/

            //elapsedTime += gameTime.ElapsedGameTime;

            //Обработка нажатий на клавиши
            inputState.KeyboardHandle(this);

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
            
            base.Draw(gameTime);
            
            spriteBatch.End(); 

            
        }
    }
}
