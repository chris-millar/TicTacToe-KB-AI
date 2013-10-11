using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public class NaiveT3Agent : Agent
    {
        Random rand;

        public NaiveT3Agent() : base()
        {
            rand = new Random();
            myAgentType = AgentTypes.Naive;
            resetForNewGame();
            moveReason = MoveReason.NavieMove;
        }


        public override void thinkAtStartOfTurn(int turnNumber, ArrayList availTerritories, ArrayList opponentsTerritories, ArrayList board)
        {
            UpdateMemAboutCurrGameState(availTerritories, opponentsTerritories, board);

            TurnFrame frame = new TurnFrame(turnNumber, parent, WinSetDefinitions);
            frame.Opponent = parent.Opponent;
            frame.setMyTerritories(MyTerritories);
            frame.setOpponentsTerritories(OpponentTerritories);
            frame.setAvail(AvailTerritories);
            frame.setPreBoard(Board);

            UpdatePercepts();
            frame.MySingleSets = null;
            frame.MyDoubleSets = null;
            frame.OppSingleSets = null;
            frame.OppDoubleSets = null;

            frame.GameFrameID = GameIndex;
            ListOfCurrGameTurnFrames.Add(frame);

            CurrTurnFrame = frame;
        }


        public override void UpdatePercepts()
        {
            // Naive agent doesnt have strategic perceptions
        }
        

        public override void decideNextMove()
        {
            MyPick = ApplyStrategy();

            Territory claimed = Board[(int)MyPick] as Territory;

            CurrTurnFrame.ClaimedTerritory = claimed;
            CurrTurnFrame.ReasoningForMove = moveReason;
            CurrTurnFrame.ReasoningForHowMoveReasonDetermined = reasoningAboutMove;
            CurrTurnFrame.WinSetImInterestedIn = setImInterestedIn;
            CurrTurnFrame.WhyImInterestedInThisWinSet = whyImInterestedIn;
        }

        private TerritoryPosition ApplyStrategy()
        {
            int index = rand.Next(0, AvailTerritories.Count);
            TerritoryPosition pick = (TerritoryPosition) AvailTerritories[index];

            setImInterestedIn = new ArrayList();
            setImInterestedIn.Add(pick);

            whyImInterestedIn = new ArrayList();
            whyImInterestedIn.Add(MoveReason.NavieMove);

            moveReason = MoveReason.NavieMove;
            reasoningAboutMove = new ArrayList();
            reasoningAboutMove.Add("I randomly selected a position from the available positions");

            MyTerritories.Add(pick);
            return pick;
        }


        public override String ToString()
        {
            return "Naive T3Agent";
        }


        public override void resetForNewGame()
        {
            MyTerritories = new ArrayList();
            OpponentTerritories = new ArrayList();
            AvailTerritories = new ArrayList();
            moveReason = MoveReason.NULL;
            reasoningAboutMove = new ArrayList();

            TurnIndex = 0;
            ListOfCurrGameTurnFrames = new ArrayList();
            ListOfGameFrames.Add(ListOfCurrGameTurnFrames);
        }
    }
}
