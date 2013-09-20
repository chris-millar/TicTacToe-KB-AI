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

        public NaiveT3Agent()
        {
            rand = new Random();

            MyTerritories = new ArrayList();
            OpponentTerritories = new ArrayList();
            AvailTerritories = new ArrayList();
        }

        public override TerritoryPosition decideNextMove()
        {
            int index = rand.Next(0, AvailTerritories.Count);
            TerritoryPosition pick = (TerritoryPosition) AvailTerritories[index];

            String message = " - Naive Agent: \t Random Pick";
            if (parent.shouldDisplayConsole)
            {
                Console.WriteLine(message);
            }
            if (parent.shouldDisplayUI)
            {
                onNewInfo(message);
            }

            MyTerritories.Add(pick);
            return pick;
        }

        
        public override String ToString()
        {
            return "Naive T3Agent";
        }
    }
}
