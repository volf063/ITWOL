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
    internal class Player : Entity
    {

        /// <summary>
        /// Неподвижная текстура героя.
        /// </summary>
        private Texture2D PlayerStaticTexture;

        /// <summary>
        /// Начальная позиция героя.
        /// </summary>
        public Vector2 playerPosition { get; set; }

        /// <summary>
        /// Доступ к текстуре
        /// </summary>
        public new Texture2D staticTexture
        {
            get { return PlayerStaticTexture; }
            set { PlayerStaticTexture = staticTexture; }
        }

        /// <summary>
        /// Повернуто ли изображение. По умолчанию false.
        /// </summary>
        public bool isRotated;

        /// <summary>
        /// Конструктор для создания нового героя.
        /// </summary>
        public Player()
        {
            isRotated = false;
        }

        /// <summary>
        /// Загружает текстуры и спрайты героя.
        /// </summary>
        public void LoadContent(ContentManager Content, String texture)
        {
            PlayerStaticTexture = Content.Load<Texture2D>(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 startPosition)
        {
            if (isRotated == false)
            {
                spriteBatch.Draw(PlayerStaticTexture, playerPosition, Color.White);
            }
            else
            {
                if (isRotated == true)
                    spriteBatch.Draw(PlayerStaticTexture, playerPosition, null,
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
        }

    }
}
