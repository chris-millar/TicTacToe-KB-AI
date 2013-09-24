using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public class TurnFrame
    {
        public Player player;
        public Player Opponent;
        public int TurnNumber;
        public ArrayList Board;
        public ArrayList Avail;
        public ArrayList MyTerritories;
        public ArrayList OpponentsTerritories;

        public Territory ClaimedTerritory;
        public MoveReason ReasoningForMove;
        public ArrayList ReasoningForHowMoveReasonDetermined; //String Arraylist

        public TurnFrame(int turnNum, Player player)
        {
            this.TurnNumber = turnNum;
            this.player = player;
            ReasoningForHowMoveReasonDetermined = new ArrayList();
        }

        public void AddLineToReasoningForHowMoveDetermined(String line)
        {
            ReasoningForHowMoveReasonDetermined.Add(line);
        }

        public void setBoard(ArrayList currBoard)
        {
            Board = new ArrayList();
            Territory terr;
            for (int i = 0; i < currBoard.Count; i++)
            {
                terr = new Territory(((Territory)currBoard[i]).position);
                terr.setOwner(((Territory)currBoard[i]).getOwner());
                terr.symbol = ((Territory)currBoard[i]).symbol;
                Board.Add(terr);
            }
        }

        public void setAvail(ArrayList currAvail)
        {
            Avail = new ArrayList();
            //Territory terr;
            for (int i = 0; i < currAvail.Count; i++)
            {
                //terr = new Territory(((Territory)currAvail[i]).position);
                //terr.setOwner(((Territory)currAvail[i]).getOwner());
                //terr.symbol = ((Territory)currAvail[i]).symbol;
                Avail.Add(currAvail[i]);
            }
        }

        public void setMyTerritories(ArrayList currMyTerritories)
        {
            MyTerritories = new ArrayList();
            //TerritoryPosition terr;
            for (int i = 0; i < currMyTerritories.Count; i++)
            {
                //terr = new Territory(((TerritoryPosition)currMyTerritories[i]));
                //terr.setOwner(((Territory)currMyTerritories[i]).getOwner());
                //terr.symbol = ((Territory)currMyTerritories[i]).symbol;
                MyTerritories.Add(currMyTerritories[i]);
            }
        }

        public void setOpponentsTerritories(ArrayList currOpponentsTerritories)
        {
            OpponentsTerritories = new ArrayList();
            //Territory terr;
            for (int i = 0; i < currOpponentsTerritories.Count; i++)
            {
                //terr = new Territory(((Territory)currOpponentsTerritories[i]).position);
                //terr.setOwner(((Territory)currOpponentsTerritories[i]).getOwner());
                //terr.symbol = ((Territory)currOpponentsTerritories[i]).symbol;
                OpponentsTerritories.Add(currOpponentsTerritories[i]);
            }
        }
    }
}
