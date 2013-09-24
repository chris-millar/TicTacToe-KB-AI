using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public class Player
    {
        public String name;
        public String symbol;
        private Agent agent;

        public ArrayList MyTerritories
        {
            get { return agent.MyTerritories; }

            set { agent.MyTerritories = value; }
        }

        public bool shouldDisplayConsole;
        public bool shouldDisplayUI;

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
        }

        void agent_NewInfo(object sender, EventArgs e)
        {
            String message = sender as String;
            onNewInfo(message);
        }

        public TerritoryPosition makeMove(ArrayList availTerritories, ArrayList opponentsTerritories, ArrayList board)
        {
            agent.UpdateMemAboutCurrGameState(availTerritories, opponentsTerritories);
            TerritoryPosition pick = agent.decideNextMove();
            return pick;
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
            return MyTerritories.Contains(pos);
        }

        public void UpdateDisplayOptions(bool console, bool ui)
        {
            shouldDisplayConsole = console;
            shouldDisplayUI = ui;
        }

        public void resetForNewGame()
        {
            agent.resetForNewGame();
        }

        public MoveReason WhatWasReasoningForMove()
        {
            return agent.WhatWasReasoningForMove();
        }

        public ArrayList WhatWasReasoningForHowMoveReasonDetermined()
        {
            return agent.WhatWasReasoningForHowMoveReasonDetermined();
        }

        public ArrayList WhatWinSetImInterestedIn()
        {
            return agent.WhatWinSetImInterestedIn();
        }

        public ArrayList WhyAmImInterestedInThisSet()
        {
            return agent.WhyAmImInterestedInThisSet();
        }

        public AgentType getAgentType()
        {
            return agent.myAgentType;
        }
        

    }

    
}
