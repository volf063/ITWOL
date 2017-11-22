using ITWOL.Controller.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL
{
    /// <summary>
    /// ScreenManager - менеджер экранов это компонент, который управляет
    /// одним или более экземпляром класса GameScreen (игровой экран).
    /// Он управляет стеком экранов, вызывает их методы Update и Draw
    /// в нужное время, и автоматически отправляет входящие данные на
    /// главный активный экран.
    /// 
    /// Является элементом отрисовки игры - наследником DrawableGameComponent.
    /// </summary>
    public class ScreenManager : DrawableGameComponent
    {

        /// <summary>
        /// FrontGamePage типа ITWOLGame позволяет создать экземпляр
        /// класса ITWOLGame, таким образом можно взаимодействовать с 
        /// данными из основного класса
        /// </summary>
        public ITWOLGame FrontGamePage { get; set; }
        
        /// <summary>
        /// инициируем файл для управления дальнейшей загрузкой и 
        /// выгрузкой контента в виде текстур, шрифтов и т.д.
        /// </summary>
        public ContentManager Content { get; set; }

        //public ContentManager GraphicContent { get; set; }


        //
        
        //testGrid - текстура тестовой сетки с шагом линия в каждые сто пикселей
        Texture2D testGrid;

        //шрифты
        private SpriteFont fontSmall;
        private SpriteFont fontMedium;
        private SpriteFont fontNormal;
        
        //курсор
        Texture2D cursorDefault; //Спрайт с изображением-курсором
        Rectangle cursorPosition; //Текущая позиция курсора
        //


        /*
        ///<summary>
        /// Player типа Player (из игровой модели) позволяет создать 
        /// экземпляр класса Player, таким образом можно взаимодействовать с  
        /// данными из основного класса
        /// </summary>
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        /// <summary>
        /// текущий персонаж пуст - стартовое значение
        /// </summary>
        private Player player = null;*/



        /// <summary>
        /// конструктор
        /// при создании скрин менеджера текущим экраном выбирается тот,
        /// который инициировал создание менеджера
        /// </summary>
        /// <param name="game">нужен для связи элемента отрисовки(коим является ScreenManager)
        /// с основным компонентом игры Game</param>
        /// <param name="gamepage">нужен для связи ScreenManager с нашей игрой ITWOLGame</param>
        public ScreenManager(Game game, ITWOLGame gamepage) : base(game)
        {
            FrontGamePage = gamepage;
            Current = this;
        }

        /// <summary>
        /// текущий экран пуст - стартовое значение
        /// </summary>
        public static ScreenManager Current = null;


        /// <summary>
        /// Load your graphics content.
        /// </summary>
        protected override void LoadContent()
        {

            // Load content belonging to the screen manager.
            Content = Game.Content;

            //
            //загрузка текстуры сетки
            testGrid = Content.Load<Texture2D>("testGrid1");

            //загрузка шрифтов
            fontSmall = Content.Load<SpriteFont>(@"Fonts\pixSmall");
            fontMedium = Content.Load<SpriteFont>(@"Fonts\pix10");
            fontNormal = Content.Load<SpriteFont>(@"Fonts\pix12");

            //загрузка текстуры стандартного курсора
            cursorDefault = Content.Load<Texture2D>(@"Cursors\cursorDefault");
            //

        }

        public override void Update(GameTime gameTime)
        {

            //
             cursorPosition = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, cursorDefault.Width, cursorDefault.Height);
            //

        }


    }
}
