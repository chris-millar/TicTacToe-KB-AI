using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class GameFrame
    {
        public int GameId;
        public ArrayList TurnFrames;
        public GameOverState result;
        public Player Winner;
        public Player Losser;

        public int NumTurnsInGame;

        public GameFrame(int id)
        {
            GameId = id;
        }
    }
}
