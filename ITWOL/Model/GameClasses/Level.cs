using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace ITWOL.Model.GameClasses
{
    /// <summary>
    /// Уровень содержит спрайт уровня, предметы на нем и персонажа.
    /// 
    /// </summary>
    internal class Level : IDisposable
    {
        /*/
        string levelTitle;
        int levelIndex;

        int previousLevel;
        int nextLevel;

        public ScreenManager screenManager;
        public ContentManager content;

        /// <summary>
        /// Конструктор нового уровня.
        /// </summary>
        /// <param name="myscreenmanager">
        /// Передает ScreenManager из которого вызван уровень
        /// </param>
        /// <param name="levelIndex">Индекс уровня</param>
        public Level(ScreenManager myscreenmanager, int levelIndex)
        {
            screenManager = myscreenmanager;
            this.levelIndex = levelIndex;

            //потом нужно выделить потоки под загрузку только того, что касается уровня
            screenManager.loadGameContent();

            //
            // There is only one player object, created when the first level is loaded
            //if (screenManager.Player == null)
             //   screenManager.Player = new Player(screenManager, this, entrances[i].Position, false);
            
        }
        /*/
        /// <summary>
        /// Unloads the level content.
        /// </summary>
        public void Dispose()
        {
            //content.Unload();
        }
       

    }
}
