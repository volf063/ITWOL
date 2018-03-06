using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Анимация из последовательности изображений для Monogame
/// </summary>
namespace SequencesAnimator
{
    /// <summary>
    /// Сущность анимации - информация про последовательность изображений
    /// Нужно для задания изначальных параметров
    /// </summary>
    class Animation
    {
        //----------------------------------------------------------------
        // ПОЛЯ

        /// <summary>
        /// Имя анимации. Поле.
        /// </summary>
        private string name;

        /// <summary>
        /// Количество кадров в анимации. Поле.
        /// </summary>
        private int totalFrames;

        /// <summary>
        /// Задержка кадра для показа на экране 
        /// (длительность демонстрации). Поле.
        /// </summary>
        private float frameDelayTime;

        /// <summary>
        /// Путь к последовательности. Поле.
        /// </summary>
        private string pathToSequence;

        /// <summary>
        /// Общее имя файлов последовательности, без окончаний в виде нумерации. Поле.
        /// </summary>
        private string nameOfSequenceFiles;

        /// <summary>
        /// Массив для хранения изображений последовательности. Поле.
        /// </summary>
        private Texture2D[] sequence;

        //----------------------------------------------------------------
        // ДОСТУП К ПОЛЯМ

        /// <summary>
        /// Имя анимации
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = Name; }
        }

        /// <summary>
        /// Количество кадров в анимации
        /// </summary>
        public int TotalFramesCount
        {
            get { return totalFrames; }
            set { totalFrames = TotalFramesCount; }
        }

        /// <summary>
        /// Задержка кадра для показа на экране 
        /// (длительность демонстрации)
        /// </summary>
        public float FrameDelayTime
        {
            get { return frameDelayTime; }
            set { frameDelayTime = FrameDelayTime; }
        }

        /// <summary>
        /// Путь к последовательности
        /// </summary>
        public string PathToSequence
        {
            get { return pathToSequence; }
            set { pathToSequence = PathToSequence; }
        }

        /// <summary>
        /// Общее имя файлов последовательности, без окончаний в виде нумерации
        /// </summary>
        public string NameOfSequenceFiles
        {
            get { return nameOfSequenceFiles; }
            set { nameOfSequenceFiles = NameOfSequenceFiles; }
        }

        /// <summary>
        /// Массив для хранения изображений последовательности
        /// </summary>
        public Texture2D[] Sequence
        {
            get { return sequence; }
            set { sequence = Sequence; }
        }

        //----------------------------------------------------------------
        // ПРОЧИЕ МЕТОДЫ

        /// <summary>
        /// Конструктор пустой анимации
        /// </summary>
        public Animation()
        {

        }

        /// <summary>
        /// Загружает текстуры последовательности
        /// </summary>
        public void LoadContent(ContentManager Content, string texture, int TotalFramesCount)
        {

            for (int i = 0; i < TotalFramesCount; i++)
            {
                Sequence[i] = Content.Load<Texture2D>(texture);
            }
            
        }

        /// <summary>
        /// Отрисовка одного фрейма
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Vector2 startPosition, int frame)
        {
            int i = frame--;
            spriteBatch.Draw(Sequence[i], startPosition, Color.White);

        }

    }
}
