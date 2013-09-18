using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class NaiveT3Agent : Agent
    {
        Random rand;
        bool consoleMode;

        public NaiveT3Agent()
        {
            rand = new Random();
            consoleMode = false;
        }

        public override TerritoryPosition decideNextMove(ArrayList avail, ArrayList winDef, ArrayList oppTerr, ArrayList myTerr, ArrayList board, Player opp)
        {
            int index = rand.Next(0, avail.Count);
            TerritoryPosition pick = (TerritoryPosition) avail[index];

            String message = " - Naive Agent: \t Random Pick";
            if (consoleMode)
            {
                Console.WriteLine(message);
            }
            else
            {
                onNewInfo(message);
            }

            return pick;
        }

        
        public override String ToString()
        {
            return "Naive TicTacToeAgent";
        }
    }
}
