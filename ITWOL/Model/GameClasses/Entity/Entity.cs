using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Model.GameClasses.Entity
{
    /// <summary>
    /// Базовый класс для всех сущностей (персонажей).
    /// </summary>
    /// <remarks>
    /// Общий класс для всех объектов, попадающих под
    /// категорию персонажей.
    /// Герой, различные нпс.
    /// </remarks>
    internal class Entity
    {
        /// <summary>
        /// Неподвижная текстура персонажа.
        /// </summary>
        internal Texture2D staticTexture;

        /*/
        // Анимации
        // Анимация при простое
        internal Animation idleAnimation;
        // Анимация перемещения
        internal Animation runAnimation;
        // Анимация смерти
        internal Animation dieAnimation;
        // Воспроизведение анимации
        internal AnimationPlayer sprite;
        /*/

    }
}
