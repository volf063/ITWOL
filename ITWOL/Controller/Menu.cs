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
    /// Данные о пунктах меню
    /// </summary>
    internal class Menu
    {
        public Texture2D imageTexture;
        public Rectangle imageRectangle;
        public Color color;
        public Menu(Game game, Texture2D _texture, Rectangle _rectangle, Color _color)
        {
            imageTexture = _texture;
            imageRectangle = _rectangle;
            color = _color;
        }
    }
}
