using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWOL
{
    /// <summary>
    /// The screen manager is a component which manages one or more GameScreen
    /// instances. It maintains a stack of screens, calls their Update and Draw
    /// methods at the appropriate times, and automatically routes input to the
    /// topmost active screen.
    /// </summary>
    public class ScreenManager : DrawableGameComponent
    {
        
        public ScreenManager(Game game, ITWOLGame gamepage) : base(game)
        {
        }
    }
}
