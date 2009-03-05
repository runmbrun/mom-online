using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using MOM;



namespace MOM
{
    class MOMGame
    {
        public enum _gametype
        {
            Single,
            Multiplayer,
            None
        }

        public enum _gamestate
        {
            Starting,   // before the game has started.  Like Choosing the options.  should never have this.
            Game,       // Game is being played
            None        // default catch all.  Should never be here
        }
        

        public _gamestate GameState;
        public _gametype GameType;
        public Int32 _turn = 0;
        public Int32 _playerturn = 0;


        /// <summary>
        /// 
        /// </summary>
        public MOMGame()
        {
            GameState = _gamestate.None;
            GameType = _gametype.None;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartSinglePlayerGame()
        {
            GameState = _gamestate.Game;
            GameType = _gametype.Single;
            
        }
    }
}
