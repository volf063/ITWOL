using ITWOL.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.View.Screens
{
    /// <summary>
    /// Экран справки
    /// </summary>
    internal class CreditsScreen : Screen
    {
        //Текстуры для фона и справочной надписи
        Texture2D backTexture;
        Rectangle backRectangle;
        Texture2D helpTexture;
        Rectangle helpRectangle;
        SpriteFont[] fonts;
        string info;
        Vector2 position;

        public CreditsScreen(Game game, Texture2D _back, SpriteFont[] _fonts, /*Texture2D _help,*/ Rectangle _backRec, Rectangle _helpRec)
            : base(game)
        {
            backTexture = _back;
            //helpTexture = _help;
            fonts = _fonts;
            backRectangle = _backRec;
            helpRectangle = _helpRec;
            position = new Vector2(helpRectangle.X, helpRectangle.Y);
            info = ("Это техно демо игры" +"\n" +
                    " \"In the web of li(f)e.\""+ "\n\n" +
                    "Используйте стрелки" + "\n" +
                    "влево и вправо " + "\n" + 
                    "для перемещения.");
        }
        public override void Draw(GameTime gameTime)
        {
            //Выводим изображения
            sprBatch.Draw(backTexture, backRectangle, Color.White);
            sprBatch.DrawString(fonts[2], info, position, Color.MintCream);
            base.Draw(gameTime);
        }
    }
}
