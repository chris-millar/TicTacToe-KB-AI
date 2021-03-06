﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public abstract class Agent
    {
        // Meta-Knowledge about Self //
        public Player parent;
        public AgentType myAgentType;
        public event EventHandler NewInfo;
        
        
        // Long Term Memory //
        public ArrayList WinSetDefinitions;
        
        public ArrayList ListOfGameFrames;
        
        
        // Short Term Memory //
        public ArrayList Board;
        public ArrayList AvailTerritories;
        public ArrayList OpponentTerritories;
        public ArrayList MyTerritories;


        public TerritoryPosition MyPick;
        public MoveReason moveReason;
        public ArrayList reasoningAboutMove;

        public ArrayList setImInterestedIn;
        public ArrayList whyImInterestedIn;

        public ArrayList ListOfCurrGameTurnFrames;
        public TurnFrame CurrTurnFrame;
        public int GameIndex;
        public int TurnIndex;


        public abstract void UpdatePercepts();
        public abstract void decideNextMove();
        public abstract void thinkAtStartOfTurn(int turnNumber, ArrayList availTerritories, ArrayList opponentTerritories, ArrayList board);

        public void setParent(Player parent)
        {
            this.parent = parent;
        }

        public void setWinSetDefinitions(ArrayList definitions)
        {
            WinSetDefinitions = definitions;
        }

        public void UpdateMemAboutCurrGameState(ArrayList availTerritories, ArrayList opponentsTerritories, ArrayList board)
        {
            AvailTerritories = availTerritories;
            OpponentTerritories = opponentsTerritories;
            Board = board;
        }

        protected void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }

        public Agent()
        {
            ListOfGameFrames = new ArrayList();
            GameIndex = 0;
            TurnIndex = 0;
        }

        public abstract void resetForNewGame();

        public MoveReason WhatWasReasoningForMove()
        {
            return moveReason;
        }

        public ArrayList WhatWasReasoningForHowMoveReasonDetermined()
        {
            return reasoningAboutMove;
        }

        public ArrayList WhatWinSetImInterestedIn()
        {
            return setImInterestedIn;
        }

        public ArrayList WhyAmImInterestedInThisSet()
        {
            return whyImInterestedIn;
        }
    }
}
