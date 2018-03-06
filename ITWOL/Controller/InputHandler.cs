using ITWOL.View.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.Controller
{
    //Обработка нажатий на клавиши
    internal class InputHandler {

        public void KeyboardHandle(ITWOLGame game)
        {
            //считаем состояние клавиатуры
            KeyboardState kbState = Keyboard.GetState();
            //Если прошло 4 игровых цикла
            game.menuChangeInterval++;
            if (game.menuChangeInterval >= 4)
            {
                //Обнуляем счетичик
                game.menuChangeInterval = 0;

                //Если выбран экран меню
                if (game.menuScreen.Enabled)
                {
                    //Если нажата клавиша вверх
                    if (kbState.IsKeyDown(Keys.Up))
                    {
                        //Уменьшить на 1 счетчик, отвечающий за
                        //смену пунктов меню
                        game.currentMenuItem--;
                        //Если в момент нажатия был активен самый верхний
                        //пункт
                        if (game.currentMenuItem < 1)
                        {
                            //Делаем текущим третий пункт
                            game.currentMenuItem = 3;
                            //Вызов процедуры для отображения смены пункта меню
                            game.menuScreen.GetKey(game.currentMenuItem);
                        }
                        //если при уменьшении номера пункта
                        //он не меньше 1, вызываем процедуру
                        //отображения смены пункта
                        else
                        {
                            game.menuScreen.GetKey(game.currentMenuItem);
                        }
                    }
                    //При нажатии клавиши вниз
                    if (kbState.IsKeyDown(Keys.Down))
                    {
                            //Увеличим счетчик
                            game.currentMenuItem++;
                        //Если он больше 3 - активируем первый пункт
                        if (game.currentMenuItem > 3)
                        {
                            game.currentMenuItem = 1;
                            game.menuScreen.GetKey(game.currentMenuItem);
                        }
                        //Если не меньше 3 - переходим на следующий пункт
                        else
                        {
                            game.menuScreen.GetKey(game.currentMenuItem);
                        }
                    }
                    //При нажатии клавиши Enter
                    //выполняем команду, соответствующую текущему пункту меню
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        //Первый пункт - скрываем экран меню
                        //и отображаем игровой экран
                        if (game.currentMenuItem == 1)
                        {
                            game.menuScreen.Hide();
                            game.newGameScreen.Show();
                        }
                        //Скрываем меню и
                        //отображаем экран справки
                        if (game.currentMenuItem == 2)
                        {
                            game.menuScreen.Hide();
                            game.creditsScreen.Show();
                        }
                        //Выходим из игры
                        if (game.currentMenuItem == 3)
                        {
                            game.Exit();
                        }

                    }
                    /*/
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        game.Exit();
                    }/*/
                }
            }
            //Если активен экран справки
            if (game.creditsScreen.Enabled)
            {
                //При нажатии Esc закрываем экран справки
                //И открываем меню
                if (kbState.IsKeyDown(Keys.Escape))
                {
                    game.creditsScreen.Hide();
                    game.menuScreen.Show();
                }
            }

            //Если активен игровой экран
            //При нажатии Esc закрываем его 
            //и открываем меню
            //Обработка нажатий клавиш, необходимых для работы игрового экрана
            //проводится в объекте, соответствующем этому экрану
            if (game.newGameScreen.Enabled)
            {
                if (kbState.IsKeyDown(Keys.Escape))
                {
                    game.newGameScreen.Hide();
                    game.menuScreen.Show();
                }
            }
        }

        public void MouseHandle (ITWOLGame game)
        {
            /*MouseState mouseState = Mouse.GetState();
            game.GameCursor.cursorRectangle.X = mouseState.X;
            game.GameCursor.cursorRectangle.Y = mouseState.Y;*/
        }
    }
}