using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller.Managers
{

    /// <summary>
    /// Перечисление для установки статуса перехода экрана
    /// </summary>
    public enum ScreenState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }


    /// <summary>
    /// Игровой экран (GameScreen) это отдельная прослойка, у которой есть своя логика
    /// update и draw logic, и которая может быть объединена с другими
    /// прослойками для построения полноценной системы меню.
    /// Для экземпляров главного меню, меню настроек, для окна-подтверждения выхода
    /// и для самой игры с ее локациями.
    /// Все это представлено в виде экранов(окон).
    /// </summary>
    public abstract class GameScreen
    {

        /// <summary>
        /// Получает ScreenManager, который вызвал окно.
        /// </summary>
        public ScreenManager ScreenManager
        {
            get { return screenManager; }
            internal set { screenManager = value; }
        }

        ScreenManager screenManager;



    }
}
