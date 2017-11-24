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
    //Экран справки
    public class CreditsScreen : Screen
    {
        //Текстуры для фона и справочной надписи
        Texture2D backTexture;
        Rectangle backRectangle;
        Texture2D helpTexture;
        Rectangle helpRectangle;

        public CreditsScreen(Game game, Texture2D _back, Texture2D _help, Rectangle _backRec, Rectangle _helpRec)
            : base(game)
        {
            backTexture = _back;
            helpTexture = _help;
            backRectangle = _backRec;
            helpRectangle = _helpRec;
        }
        public override void Draw(GameTime gameTime)
        {
            //Выводим изображения
            sprBatch.Draw(backTexture, backRectangle, Color.White);
            sprBatch.Draw(helpTexture, helpRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
