using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller
{
    /// <summary>
    /// Отображает обычные анимированные текстуры.
    /// Для текстур, на которых в длину выстроены все кадры анимации.
    /// </summary>
    /// <remarks>
    /// Этот класс предполагает, что каждый кадр анимации
    /// по ширине равен высоте каждой анимации. 
    /// Число кадров в анимации выводится из этого предположения.
    /// </remarks>
    internal class Animation
    {
        /// <summary>
        /// Все кадры анимации расположены горизонтально.
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
        }
        Texture2D texture;

        /// <summary>
        /// Продолжительность демонстрации каждого кадра.
        /// </summary>
        public float FrameTime
        {
            get { return frameTime; }
        }
        float frameTime;

        /// <summary>
        /// После окончания анимации запрашивает необходимость
        /// ее повторения с начала.
        /// </summary>
        public bool IsLooping
        {
            get { return isLooping; }
            set { IsLooping = value; }
        }
        bool isLooping;

        /// <summary>
        /// Получает количество кадров в анимации.
        /// </summary>
        public int FrameCount
        {
            get { return Texture.Width / FrameWidth; }
        }

        /// <summary>
        /// Получает ширину кадра анимации.
        /// </summary>
        public int FrameWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Получает высоту кадра анимации.
        /// </summary>
        public int FrameHeight
        {
            get { return Texture.Height; }
        }


        /// <summary>
        /// Конструктор анимации с предопределенной шириной кадра.
        /// </summary>        
        public Animation(Texture2D texture, float frameTime, bool isLooping, int frameWidth)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            this.isLooping = isLooping;
            if (frameWidth == 0)
                this.FrameWidth = texture.Height;
            else if (frameWidth > 0)
                this.FrameWidth = frameWidth;
        }
        /// <summary>
        /// Конструктор для анимации, у которой высота и ширина совпадают.
        /// </summary>        
        public Animation(Texture2D texture, float frameTime, bool isLooping)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            this.isLooping = isLooping;
            this.FrameWidth = texture.Height;
        }
    }
}
