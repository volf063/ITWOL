using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller
{
    /// <summary>
    /// Базовый класс, на основе которого создаются игровые экраны.
    /// </summary>

    internal class Screen : DrawableGameComponent
    {
        //Для объекта SpriteBatch, который используется
        //для вывода изображений в классах-наследниках
        public SpriteBatch sprBatch;

        /// <summary>
        /// Конструктор, создающий новый экран.
        /// </summary>
        /// <param name="game">Параметр, связывающий с основным игровым классом.</param>
        public Screen(Game game)
            : base(game)
        {
            //При создании объекта он по умолчанию 
            //невидим и неактивен
            Visible = false;
            Enabled = false;
            //получим объект SpriteBatch
            sprBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
        }
        /// <summary>
        /// Процедура для отображения и активации объекта
        /// </summary>
        public void Show()
        {
            Visible = true;
            Enabled = true;
        }

        /// <summary>
        /// Процедура для скрытия и отключения объекта
        /// </summary>
        public void Hide()
        {
            Visible = false;
            Enabled = false;
        }
    }
}
