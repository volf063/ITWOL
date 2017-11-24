using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ITWOL.Model.GameClasses
{


    /// <summary>
    /// Уровень содержит спрайт уровня, предметы на нем, 
    /// стартовую позицию персонажа и ограничения его передвижения.
    /// </summary>
    internal class Level
    {
        /// <summary>
        /// Неподвижная текстура героя.
        /// </summary>
        private Texture2D LevelTexture;

        /// <summary>
        /// Начальная позиция героя.
        /// </summary>
        public Vector2 playerPosition { get; set; }

        /// <summary>
        /// Доступ к текстуре
        /// </summary>
        public Texture2D levelBG
        {
            get { return LevelTexture; }
            set { LevelTexture = levelBG; }
        }
        
        /// <summary>
        /// Конструктор для создания нового героя.
        /// </summary>
        public Level()
        {
            
        }

        /// <summary>
        /// Загружает текстуры и спрайты героя.
        /// </summary>
        public void LoadContent(ContentManager Content, String texture)
        {
            LevelTexture = Content.Load<Texture2D>(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 startPosition)
        {
           
        spriteBatch.Draw(LevelTexture, playerPosition, Color.White);
            
        }
    }

        /*/
        /// <summary>
        /// Уровень содержит спрайт уровня, предметы на нем, 
        /// стартовую позицию персонажа и ограничения его передвижения.
        /// </summary>
        internal class Level
        {

            /// <summary>
            /// Фон уровня
            /// </summary>
            private Texture2D LevelBG;
            /// <summary>
            /// Название уровня (должно совпадать с названием текстуры)
            /// </summary>
            string levelTitle;
            /// <summary>
            /// Внутренний числовой индекс уровня.
            /// </summary>
            int levelIndex;
            /// <summary>
            /// Индекс предыдущего уровня
            /// </summary>
            int previousLevel;
            /// <summary>
            /// Индекс следующего уровня
            /// </summary>
            int nextLevel;

            public Vector2 levelBGStart { get; set; }

            /// <summary>
            /// Стартовое положение персонажа на уровне
            /// </summary>
            public Vector2 playerStartPosition { get; set; }
            /// <summary>
            /// Координата по оси Х левой границы для передвижения по уровню.
            /// </summary>
            public int leftBoundPoint { get; set; }
            /// <summary>
            /// Координата по оси Х правой границы для передвижения по уровню.
            /// </summary>
            public int ridhtBoundPoint { get; set; }


            //public ContentManager content;


            /// <summary>
            /// Доступ к текстуре
            /// </summary>
            public Texture2D levelBG
            {
                get { return LevelBG; }
                set { LevelBG = levelBG; }
            }

            /// <summary>
            /// Загружает текстуры и спрайты героя.
            /// </summary>
            public void LoadContent(ContentManager Content, String texture)
            {
                LevelBG = Content.Load<Texture2D>(texture);
            }

            /// <summary>
            /// Конструктор нового уровня.
            /// </summary>
            public Level(string newLevelTitle, int newLevelIndex, int previousLevel, int nextLevel, 
                            /*ref Texture2D newLevelBG,*//* int levelLeftBoundPoint, int levelRidhtBoundPoint, Vector2 levelBGStart)
            {

                levelTitle = newLevelTitle;
                levelIndex = newLevelIndex;
                this.previousLevel = previousLevel;
                this.nextLevel = nextLevel;
                //this.levelBG = newLevelBG;
                leftBoundPoint = levelLeftBoundPoint;
                ridhtBoundPoint = levelRidhtBoundPoint;
                this.levelBGStart = (levelBGStart == null ? new Vector2(0,0) : levelBGStart);
            }

            /// <summary>
            /// Конструктор нового уровня без специальных ограничений передвижения.
            /// Предполагается, что такой уровень имеет размеры окна и рисуется от его начала.
            /// </summary>
            public Level(string newLevelTitle, int newLevelIndex, int previousLevel, int nextLevel/*,
                            ref Texture2D newLevelBG*//*)
            {

                levelTitle = newLevelTitle;
                levelIndex = newLevelIndex;
                this.previousLevel = previousLevel;
                this.nextLevel = nextLevel;
                //this.levelBG = newLevelBG;
                //установка стандартных ограничений
                leftBoundPoint = 0;
                ridhtBoundPoint = 800;
                this.levelBGStart = new Vector2(0, 0);

            }

            public Level()
            {

            }

            public void Draw(SpriteBatch spriteBatch)
            {
                if (levelBGStart == new Vector2(0, 0))
                {
                    spriteBatch.Draw(levelBG, levelBGStart, Color.White);
                }
                else
                {
                    //добавить какой-то фон
                    spriteBatch.Draw(levelBG, levelBGStart, Color.White);
                }


            }


        }
    /*/
    }
