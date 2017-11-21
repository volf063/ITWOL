using Microsoft.Xna.Framework;
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        /// <summary>
        /// testGrid - текстура тестовой сетки с шагом линия в каждые сто пикселей
        /// </summary>
        Texture2D testGrid;

        private SpriteFont font;
        private SpriteFont font2;
        private SpriteFont font3;

        KeyboardState keys;
        //MouseState mouse;

        Texture2D cursorDefault; //Спрайт с изображением-курсором
        Rectangle cursorPosition; //Текущая позиция курсора


        public ITWOLGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            graphics.PreferredBackBufferWidth = 800; //ширина экрана 
            graphics.PreferredBackBufferHeight = 600; //высота экрана   
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

            testGrid = Content.Load<Texture2D>("testGrid1");//загрузка текстуры сетки

            cursorDefault = Content.Load<Texture2D>(@"Cursors/cursorDefault");

            // TODO: use this.Content to load your game content here
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

            cursorPosition = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, cursorDefault.Width, cursorDefault.Height);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            // TODO: Add your drawing code here


            font = Content.Load<SpriteFont>(@"Fonts\pixSmall");
            font2 = Content.Load<SpriteFont>(@"Fonts\pix10");
            font3 = Content.Load<SpriteFont>(@"Fonts\pix12");
            // отрисовка сетки и шрифтов
            spriteBatch.Begin();
            spriteBatch.Draw(testGrid, Vector2.Zero, Color.White);
            
            spriteBatch.DrawString(font, "pixSmall Some Text Рандомный текст", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(font2, "pix10  Some Text Рандомный текст", new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(font3, "pix12  Some Text Рандомный текст", new Vector2(100, 300), Color.White);

            spriteBatch.Draw(cursorDefault, cursorPosition, Color.White);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
