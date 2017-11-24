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
    public class ITWOLGame : Game
    {
        #region Initialization

        //шрифты

        private SpriteFont fontSmall;
        private SpriteFont fontMedium;
        private SpriteFont fontNormal;
        

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


        //Экран справки
        CreditsScreen creditsScreen;
        Texture2D creditsBG;
        Texture2D creditsText;
        //Экран меню
        MenuScreen menuScreen;
        Texture2D menuBG;
        //Texture2D menuGameName;
        Texture2D menuStartGame;
        Texture2D menuCredits;
        Texture2D menuExit;
        //Текущий элемент меню
        int currentMenuItem;
        //Интервал задержки переключения между элементами меню
        int menuChangeInterval;
        //Игровой экран
        GameplayScreen newGameScreen;
        Texture2D player;


        /*/
        Player player = new Player();
        /*/

        KeyboardState keys;

        Texture2D developerLogo;
        Texture2D gameLogo;
        
        private int TargetFrameRate = 30; //частота смены кадров
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

            //загрузка текстуры стандартного курсора
            cursorDefault = content.Load<Texture2D>(@"Cursors\cursorDefault");
            //

            // TODO: use this.content to load your game content here


            //загрузка лого разработчика
            developerLogo = content.Load<Texture2D>(@"SplashScreens\developerLogo");
            gameLogo = content.Load<Texture2D>(@"SplashScreens\gameLogo");
            
            splashScreen = developerLogo;

            //player.LoadContent(content, @"Textures\Skins\Player\playerStatic");


            //Загружаем элементы игры и создаем игровые экраны
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            creditsBG = content.Load<Texture2D>(@"Textures\Interface\MainMenu\MainMenuBg");
            creditsText = content.Load<Texture2D>(@"Textures\Interface\MainMenu\creditsMenuItem");
            creditsScreen = new CreditsScreen(this, creditsBG, creditsText,
                new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height),
                new Rectangle((this.Window.ClientBounds.Width - creditsText.Width) / 2,
                (this.Window.ClientBounds.Height - creditsText.Height) / 2,
                creditsText.Width, creditsText.Height));
            Components.Add(creditsScreen);
            player = content.Load<Texture2D>(@"Textures\Skins\Player\playerStatic");
            newGameScreen = new GameplayScreen(this, ref player, new Rectangle(0, 0, 128, 128),
                new Vector2(100, 100));
            Components.Add(newGameScreen);
            menuBG = content.Load<Texture2D>(@"Textures\Interface\MainMenu\MainMenuBg");
            //menuGameName = content.Load<Texture2D>("menuGameName");
            menuStartGame = content.Load<Texture2D>(@"Textures\Interface\MainMenu\startMenuItem");
            menuCredits = content.Load<Texture2D>(@"Textures\Interface\MainMenu\creditsMenuItem");
            menuExit = content.Load<Texture2D>(@"Textures\Interface\exitMenuItem");
            menuScreen = new MenuScreen(this, menuBG, menuStartGame, menuCredits,
                menuExit, new Rectangle(110, 110, 100, 100), new Rectangle(610, 390, 100, 100),
                new Rectangle(725, 520, 70, 70));
            Components.Add(menuScreen);
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


        // --------------------------------------------------------------------------------

        #region KeyboardHandle
        //Обработка нажатий на клавиши
        void KeyboardHandle()
        {
            //считаем состояние клавиатуры
            KeyboardState kbState = Keyboard.GetState();
            //Если прошло 4 игровых цикла
            menuChangeInterval++;
            if (menuChangeInterval >= 4)
            {
                //Обнуляем счетичик
                menuChangeInterval = 0;

                //Если выбран экран меню
                if (menuScreen.Enabled)
                {
                    //Если нажата клавиша вверх
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        //Уменьшить на 1 счетчик, отвечающий за
                        //смену пунктов меню
                        currentMenuItem--;
                        //Если в момент нажатия был активен самый верхний
                        //пункт
                        if (currentMenuItem < 1)
                        {
                            //Делаем текущим третий пункт
                            currentMenuItem = 3;
                            //Вызов процедуры для отображения смены пункта меню
                            menuScreen.GetKey(currentMenuItem);
                        }
                        //если при уменьшении номера пункта
                        //он не меньше 1, вызываем процедуру
                        //отображения смены пункта
                        else
                        {
                            menuScreen.GetKey(currentMenuItem);
                        }
                    }
                    //При нажатии клавиши вниз
                    if (kbState.IsKeyDown(Keys.Down))
                    {
                        //Увеличим счетчик
                        currentMenuItem++;
                        //Если он больше 3 - активируем первый пункт
                        if (currentMenuItem > 3)
                        {
                            currentMenuItem = 1;
                            menuScreen.GetKey(currentMenuItem);
                        }
                        //Если не меньше 3 - переходим на следующий пункт
                        else
                        {
                            menuScreen.GetKey(currentMenuItem);
                        }
                    }
                    //При нажатии клавиши Enter
                    //выполняем команду, соответствующую текущему пункту меню
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        //Первый пункт - скрываем экран меню
                        //и отображаем игровой экран
                        if (currentMenuItem == 1)
                        {
                            menuScreen.Hide();
                            newGameScreen.Show();
                        }
                        //Скрываем меню и
                        //отображаем экран справки
                        if (currentMenuItem == 2)
                        {
                            menuScreen.Hide();
                            creditsScreen.Show();
                        }
                        //Выходим из игры
                        if (currentMenuItem == 3)
                        {
                            this.Exit();
                        }
                    }


                }
            }
            //Если активен экран справки
            if (creditsScreen.Enabled)
            {
                //При нажатии Esc закрываем экран справки
                //И открываем меню
                if (kbState.IsKeyDown(Keys.Escape))
                {
                    creditsScreen.Hide();
                    menuScreen.Show();
                }
            }
            //Если активен игровой экран
            //При нажатии Esc закрываем его 
            //и открываем меню
            //Обработка нажатий клавиш, необходимых для работы игрового экрана
            //проводится в объекте, соответствующем этому экрану
            if (newGameScreen.Enabled)
            {
                if (kbState.IsKeyDown(Keys.Escape))
                {
                    newGameScreen.Hide();
                    menuScreen.Show();
                }
            }
        }
        #endregion

        // --------------------------------------------------------------------------------



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            /*/exit
             if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                 this.Exit();
             keys = Keyboard.GetState();//Инициализация объекта keys. 

             if (keys.IsKeyDown(Keys.Escape))//Проверяем, нажата ли клавиша   
                 this.Exit();//Если клавиша нажата, то происходит выход 
            /*/
            // TODO: Add your update logic here

            //
             cursorPosition = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, cursorDefault.Width, cursorDefault.Height);
            //

            //elapsedTime += gameTime.ElapsedGameTime;

            //Обработка нажатий на клавиши
            KeyboardHandle();

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
