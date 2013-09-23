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
        public ArrayList OpponentTerritories;
        public ArrayList MyTerritories;


        public abstract TerritoryPosition decideNextMove();

        public void setParent(Player parent)
        {
            this.parent = parent;
        }

        public void setWinSetDefinitions(ArrayList definitions)
        {
            WinSetDefinitions = definitions;
        }

        public void UpdateMemAboutCurrGameState(ArrayList availTerritories, ArrayList opponentsTerritories)
        {
            AvailTerritories = availTerritories;
            OpponentTerritories = opponentsTerritories;
        }

        protected void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }

        public virtual void resetForNewGame()
        {
            MyTerritories = new ArrayList();
            OpponentTerritories = new ArrayList();
            AvailTerritories = new ArrayList();
        }
    }
}
