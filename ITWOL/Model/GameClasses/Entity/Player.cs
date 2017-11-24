using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Model.GameClasses.Entity
{
    /// <summary>
    /// Наш игровой персонаж.
    /// </summary>
    class Player : Entity
    {

        /// <summary>
        /// Неподвижная текстура героя.
        /// </summary>
        private Texture2D playerStaticTexture;

        /// <summary>
        /// Начальная позиция героя.
        /// </summary>
        public Vector2 StartPosition { get; set; }
        

        /// <summary>
        /// Конструктор для создания нового героя.
        /// </summary>
        public Player()
        {
        }

        /// <summary>
        /// Загружает текстуры и спрайты героя.
        /// </summary>
        public void LoadContent(ContentManager Content, String texture)
        {
            playerStaticTexture = Content.Load<Texture2D>(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 startPosition)
        {
            spriteBatch.Draw(playerStaticTexture, startPosition, Color.White);
        }

    }
}
