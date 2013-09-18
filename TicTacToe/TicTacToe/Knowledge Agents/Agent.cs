using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public abstract class Agent
    {
        public Player parent;
        public event EventHandler NewInfo;

        public abstract TerritoryPosition decideNextMove(ArrayList avail, ArrayList winDef, ArrayList thierTerr, ArrayList myTerr, ArrayList board, Player opp);

        public void setParent(Player parent)
        {
            this.parent = parent;
        }

        protected void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }
    }
}
