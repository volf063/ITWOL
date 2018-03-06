using ITWOL.Controller;
using ITWOL.Model.GameClasses;
using ITWOL.Model.GameClasses.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL.View.Screens
{
    //Игровой экран

    internal class GameplayScreen : Screen
    {
        private ITWOLGame Game;

        private Texture2D interfaceBG;
        private Rectangle sprRectangle;
        private Vector2 sprPosition;
        private Rectangle sprBounds;
        //player
        private Player player;
        private Vector2 playerPosition;
        private Rectangle playerBounds;
        //level
        private Texture2D currentLevelBG;
        private int currentLevelIndex;
        private Level currentLevel;


        public GameplayScreen(ITWOLGame game, Level newLevel, Player newPlayer, ref Texture2D newTexture,
            Rectangle newRectangle, Vector2 newPosition)
            : base(game)
        {
            Game = game;
            currentLevelIndex = 0;
            currentLevel = newLevel; //инициируем первый уровень
            interfaceBG = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition;
            sprBounds = new Rectangle(0, 0,
                game.Window.ClientBounds.Width,
                game.Window.ClientBounds.Height);
            player = newPlayer;
            //playerPosition = player.playerPosition;
            // playerPosition += new Vector2(0, 490 - player.staticTexture.Width);
            playerPosition = new Vector2(0, 490 - player.staticTexture.Width);
            player.playerPosition = playerPosition;
            playerBounds = new Rectangle(0, 0,
                player.staticTexture.Width,
                player.staticTexture.Height);
            //currentLevel = new Level("dist1_sprite1_hotelHomeFloor", 0, -1, 1);
        }

        /*/
        protected override void LoadContent()
        {
            
            currentLevelBG = Game.Content.Load<Texture2D>(@"Textures\Levels\District1\dist1_sprite1_hotelHomeFloor");
            currentLevel = new Level("dist1_sprite1_hotelHomeFloor", 0, -1, 1, ref currentLevelBG);

        }
        /*/
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {            

            KeyboardState kbState = Keyboard.GetState();
            /*/
            if (kbState.IsKeyDown(Keys.Up))
            {
                sprPosition.Y -= 5;
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                sprPosition.Y += 5;
            }
            /*/
            if (kbState.IsKeyDown(Keys.Left))
            {
                player.isRotated = true;
                playerPosition.X -= 2;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                player.isRotated = false;
                playerPosition.X += 2;
            }

            if (playerPosition.X < sprBounds.Left)
            {
                playerPosition.X = playerBounds.Left;
            }
            if (playerPosition.X > sprBounds.Width - playerBounds.Width)
            {
                playerPosition.X = sprBounds.Width - playerBounds.Width;
            }
            /*/
            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
            }
            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                sprPosition.Y = scrBounds.Height - sprRectangle.Height;
            }
            /*/
            player.playerPosition = playerPosition;

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            currentLevel.Draw(sprBatch, Vector2.Zero);
            sprBatch.Draw(interfaceBG, sprPosition, sprRectangle, Color.White);
            player.Draw(sprBatch, playerPosition);
            base.Draw(gameTime);
        }
    }
}
