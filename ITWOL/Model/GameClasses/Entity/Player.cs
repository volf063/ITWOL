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

        /*/
        /// <summary>
        /// Прямоугольная область, орагничивающая героя.
        /// </summary>
        public Rectangle playerRectangle { get 
            { return new Rectangle(Convert.ToInt32(playerPosition.X), Convert.ToInt32(playerPosition.Y), 
                playerStaticTexture.Width, playerStaticTexture.Height); } }
        /*/

        /// <summary>
        /// Начальная позиция героя.
        /// </summary>
        public Vector2 playerPosition { get; set; }
        
        public Texture2D staticTexture
        {
            get{ return PlayerStaticTexture; }
            set{ PlayerStaticTexture = staticTexture; }
        }

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
            PlayerStaticTexture = Content.Load<Texture2D>(texture);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 startPosition)
        {
            spriteBatch.Draw(PlayerStaticTexture, playerPosition, Color.White);
        }

    }
}
