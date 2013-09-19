using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public String name;
        public String symbol;
        private Agent agent;
        public ArrayList ownedTerritories;

        public event EventHandler NewInfo;
        private void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }

        public Player(String name, String symbol, Agent agent)
        {
            this.name = name;
            this.symbol = symbol;
            this.agent = agent;
            agent.NewInfo += new EventHandler(agent_NewInfo);

            agent.setParent(this);

            ownedTerritories = new ArrayList();
        }

        void agent_NewInfo(object sender, EventArgs e)
        {
            String message = sender as String;
            onNewInfo(message);
        }

        public TerritoryPosition makeMove(ArrayList availTerritories, ArrayList ownedByOtherPlayer, ArrayList board)
        {
            //Console.Write(String.Format("Turn: {0}", name));
            TerritoryPosition claimed = agent.decideNextMove(availTerritories, ownedByOtherPlayer, ownedTerritories, board);
            ownedTerritories.Add(claimed);
            return claimed;
        }

        public void setWinSetDefinitions(ArrayList definitions)
        {
            agent.setWinSetDefinitions(definitions);
        }

        public String getSymbol()
        {
            return symbol;
        }

        public bool doOwnTerrPosition(TerritoryPosition pos)
        {
            return ownedTerritories.Contains(pos);
        }
        

    }

    
}
