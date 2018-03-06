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
    //Экран меню
    internal class MenuScreen : Screen
    {
        //Элементы меню будем хранить в массиве типа Menu
        //тип данных Menu хранит информацию об элементах меню
        Menu[] menu;
        //Текстуры и прямоугольники для вывода элементов меню
        Texture2D menuTxtStartGame;
        Texture2D menuTxtHelp;
        Texture2D menuTxtExit;
        Rectangle menuTxtStartGameR, menuTxtHelpR, menuTxtExitR;
        Texture2D menuBack;//, menuGameName;
        Rectangle menuBackR, menuGameNameR;

        public MenuScreen(Game game, Texture2D _menuBack, 
            Texture2D _menuTxtStartGame, Texture2D _menuTxtHelp, Texture2D _menuTxtExit,
            Rectangle _menuTxtStartGameR, Rectangle _menuTxtHelpR, Rectangle _menuTxtExitR)
            : base(game)
        {
            menuBack = _menuBack;
            //menuGameName = _menuGameName;
            menuBackR = new Rectangle(0, 0, 800, 600);
            menuGameNameR = new Rectangle(0, 0, 800, 200);
            menuTxtStartGame = _menuTxtStartGame;
            menuTxtStartGameR = _menuTxtStartGameR;
            menuTxtHelp = _menuTxtHelp;
            menuTxtHelpR = _menuTxtHelpR;
            menuTxtExit = _menuTxtExit;
            menuTxtExitR = _menuTxtExitR;
            //Создаем массив из 3-х элементов
            menu = new Menu[3];
            //Инициализируем элементы массива
            //Элемент с номером 0 активен
            menu[0] = new Menu(game, menuTxtStartGame, menuTxtStartGameR, Color.Khaki);
            menu[1] = new Menu(game, menuTxtHelp, menuTxtHelpR, Color.White);
            menu[2] = new Menu(game, menuTxtExit, menuTxtExitR, Color.White);

        }
        //Метод вызывается для отображения смены пункта меню
        public void GetKey(int i)
        {
            //i=1 - первый пункт
            //i=2 - второй пункт
            //i=3 - третий пункт
            if (i == 1)
            {
                menu[0].color = Color.Khaki;
                menu[1].color = Color.White;
                menu[2].color = Color.White;

            }
            if (i == 2)
            {
                menu[0].color = Color.White;
                menu[1].color = Color.Khaki;
                menu[2].color = Color.White;
            }
            if (i == 3)
            {
                menu[0].color = Color.White;
                menu[1].color = Color.White;
                menu[2].color = Color.Khaki;

            }
        }
        //Рисование элементов
        public override void Draw(GameTime gameTime)
        {
            //Вывод фона и названия игры
            sprBatch.Draw(menuBack, menuBackR, Color.White);
            //sprBatch.Draw(menuGameName, menuGameNameR, Color.White);
            //Вывод элементов меню
            for (int i = 0; i < 3; i++)
                sprBatch.Draw(menu[i].imageTexture, menu[i].imageRectangle, menu[i].color);
            base.Draw(gameTime);
        }
    }
}
