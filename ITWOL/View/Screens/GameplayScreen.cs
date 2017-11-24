using ITWOL.Controller;
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

    public class GameplayScreen : Screen
    {
        private Texture2D sprTexture;
        private Rectangle sprRectangle;
        private Vector2 sprPosition;
        private Rectangle scrBounds;


        public GameplayScreen(Game game, ref Texture2D newTexture,
            Rectangle newRectangle, Vector2 newPosition)
            : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition;
            scrBounds = new Rectangle(0, 0,
                game.Window.ClientBounds.Width,
                game.Window.ClientBounds.Height);
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {            

            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Up))
            {
                sprPosition.Y -= 5;
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                sprPosition.Y += 5;
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                sprPosition.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                sprPosition.X += 5;
            }

            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
            }
            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
            }
            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                sprPosition.Y = scrBounds.Height - sprRectangle.Height;
            }

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            sprBatch.Draw(sprTexture, sprPosition, sprRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
