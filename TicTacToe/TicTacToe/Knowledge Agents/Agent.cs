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

        public ArrayList WinSetDefinitions;

        public ArrayList AvailTerritories;
        public ArrayList OpponentOwnedTerritories;
        public ArrayList myOwnedTerritories;

        public abstract TerritoryPosition decideNextMove(ArrayList avail, ArrayList thierTerr, ArrayList myTerr, ArrayList board);

        public void setParent(Player parent)
        {
            this.parent = parent;
        }

        public void setWinSetDefinitions(ArrayList definitions)
        {
            WinSetDefinitions = definitions;
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
