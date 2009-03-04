using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using MOM;



namespace MOM
{
    class Game
    {
        MOMClientForm _form;


        public enum _gametype
        {
            Solitare,
            Multiplayer,
            None
        }

        public enum _gamestate
        {
            Started,
            Shuffle,
            ChooseSides,
            Playing,
            None
        };

        public enum _turnstate
        {
            Untap,
            Upkeep,
            Draw,
            MainFirst,
            BeginningCombat,
            DeclareAttackers,
            DeclareBlockers,
            CombatDamage,
            EndofCombat,
            MainSecond,
            EndofTurn,
            None
        }

        public _gamestate GameState;
        public _turnstate TurnState;
        public _gametype GameType;


        public Game()
        {
            GameState = _gamestate.None;
            TurnState = _turnstate.None;
            GameType = _gametype.None;
        }

        public Game(MOMClientForm form)
        {
            _form = form;
            GameState = _gamestate.None;
            TurnState = _turnstate.None;
            GameType = _gametype.None;
        }

        public void StartSolitareGame()
        {
            GameState = _gamestate.Shuffle;
            TurnState = _turnstate.None;
            GameType = _gametype.Solitare;
            
            // mmb - use xna stuff now
            
        }
    }
}
