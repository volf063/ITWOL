using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller
{

    ///!!!!!!!!!!!!!!!!!!!!!!!!!
    ///Временно закрыт!
    ///-----------------------------------------------


    /// <summary>
    /// Анимирует последовательности изображений.
    /// </summary>
    /// <remarks>
    /// Служит для анимации заставок большого формата,
    /// которые было бы неудобно хранить вытянутой серией.
    /// </remarks>
    internal class AnimationOfSequences
    {
        /*/

        //текущий кадр
        private int currentFrame;
        //количество кадров в последовательности
        private int frameCount;
        //Продолжительность демонстрации кадра 
        private float frameTime;
        //необходимость повторить анимацию
        private bool isLooping;

        /// <summary>
        /// Время в секундах, которое прошло с начала демонстрации анимации.
        /// </summary>
        private float shownTime;
        //
        //находится ли анимация на паузе
        private bool isPaused;
        //находится ли анимация в стадии остановки
        private bool isStopped;
        //

        /// <summary>
        /// Набор кадров анимации.
        /// </summary>
        public Texture2D[] Textures;
        

        public AnimationOfSequences()
        {
            
        }

        public AnimationOfSequences(Texture2D[] frames, int frc )
        {
            frameCount = frc;
            Textures = frames;
        }

        /// <summary>
        /// Анимация последовательности кадров.
        /// </summary>
        /// <remarks>
        /// Возвращает так же последовательность кадров.
        /// </remarks>
        /// <param name="frames">Входящий набор кадров анимации</param>
        /// <returns>Возвращает последовательность кадров</returns>
        public AnimationOfSequences AnimationOfSequence(Texture2D[] frames)
        {
            return new AnimationOfSequences { Textures = frames };
        }
        
        /// <summary>
        /// Текущий кадр из набора. (индекс)
        /// </summary>
        public int CurrentFrame
        {
            get { return currentFrame; }
        }
        

        /// <summary>
        /// Количество кадров в последовательности.
        /// </summary>
        public int FrameCount
        {
            get { return this.Textures.Length; }
        }

        /// <summary>
        /// Получение первого кадра последовательности кадров.
        /// </summary>
        /// <returns>Возвращает первый кадр последовательности</returns>
        public Texture2D GetTexture()
        {
            return this.Textures[this.CurrentFrame];
        }

        /// <summary>
        /// Получение определенного кадра по его номеру из последовательности
        /// кадров.
        /// </summary>
        /// <param name="frameIndex">Номер кадра</param>
        /// <returns>Возвращает кадр по указанному номеру</returns>
        public Texture2D GetTexture(int frameIndex)
        {
            return this.Textures[frameIndex];
        }

        /// <summary>
        /// Продолжительность демонстрации кадра.
        /// </summary>
        public float FrameTime
        {
            get { return frameTime; }
        }

        /// <summary>
        /// После окончания анимации запрашивает необходимость
        /// ее повторения с начала.
        /// </summary>
        public bool IsLooping
        {
            get { return isLooping; }
            set { IsLooping = value; }
        }

        
        /// <summary>
        /// Ширина кадра.
        /// </summary>
        public int FrameWidth
        {
            get { return Textures[0].Width; }
        }

        /// <summary>
        /// Высота кадра.
        /// </summary>
        public int FrameHeight
        {
            get { return Textures[0].Height; }
        }

        //
        public void Play()
        {
            this.currentFrame = 0;
            this.shownTime = 0.0f;
            //this.isLooping = false;
            this.isPaused = false;
            this.isStopped = false;
        }

        public void Pause()
        {
            this.isPaused = true;
        }

        public void Resume()
        {
            this.isPaused = false;
        }

        public void Stop()
        {
            this.currentFrame = 0;
            this.isPaused = false;
            this.isStopped = true;
            this.shownTime = 0.0f;
        }

        public void Update(long elapsedTime)
        {
            if (!this.isPaused && !this.isStopped)
            {
                this.shownTime += elapsedTime;
                if (this.shownTime >= 0xf4240L)
                {
                    this.shownTime = 0L;
                    this.currentFrame++;
                    if (this.currentFrame >= this.Textures.Length)
                    {
                        this.currentFrame = 0;
                    }
                }
            }
        }

        /*/

    }
}
