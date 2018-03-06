using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller
{
    internal class Cursor : DrawableGameComponent
    {
        public Texture2D cursorTexture;
        public Rectangle cursorRectangle;
        //public Color color;
        public Cursor(Game game, Texture2D _texture, Rectangle _rectangle/*, Color _color*/) : base(game)
        {
            cursorTexture = _texture;
            cursorRectangle = _rectangle;
           // color = _color;
        }
    }
}
