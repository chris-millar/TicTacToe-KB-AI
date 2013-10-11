using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public class SmartT3Agent : Agent
    {
        ArrayList MySingleSets;
        ArrayList MyDoubleSets;
        ArrayList OppSingleSets;
        ArrayList OppDoubleSets;

        public bool IsFirstTurn;
        public bool CanWin;
        public bool CanBlock;
        public bool CanSetUpNextTurnWin;
        public bool NoGoodMoveRemaining;

        public SmartT3Agent() : base()
        {
            myAgentType = AgentTypes.Smart;
            resetForNewGame();
        }

        public override void resetForNewGame()
        {
            MyTerritories = new ArrayList();
            OpponentTerritories = new ArrayList();
            AvailTerritories = new ArrayList();

            MySingleSets = new ArrayList();
            OppSingleSets = new ArrayList();
            MyDoubleSets = new ArrayList();
            OppDoubleSets = new ArrayList();

            moveReason = MoveReason.NULL;
            reasoningAboutMove = new ArrayList();

            TurnIndex = 0;
            ListOfCurrGameTurnFrames = new ArrayList();
            ListOfGameFrames.Add(ListOfCurrGameTurnFrames);
        }

        #region Start of Turn Perception

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
            frame.MySingleSets = MySingleSets;
            frame.MyDoubleSets = MyDoubleSets;
            frame.OppSingleSets = OppSingleSets;
            frame.OppDoubleSets = OppDoubleSets;

            frame.IsFirstTurn = IsFirstTurn;
            frame.CanWin = CanWin;
            frame.CanBlock = CanBlock;
            frame.CanSetUpNextTurnWin = CanSetUpNextTurnWin;
            frame.NoGoodMoveRemaining = NoGoodMoveRemaining;

            frame.GameFrameID = GameIndex;
            ListOfCurrGameTurnFrames.Add(frame);

            CurrTurnFrame = frame;
        }

        public override void UpdatePercepts()
        {
            clearOldPercepts();
            calculateMySingleSets();
            calculateMyDoubleSets();
            calculateOppSingleSets();
            calculateOppDoubleSets();

            DetermineIfFirstTurn();
            DetermineIfCanWin();
            DetermineIfCanBlock();
            DetermineIfCanSetUpNextTurnWin();
            DetermineIfNoGoodMoveRemaining();
        }
        
        private void clearOldPercepts()
        {
            MySingleSets = new ArrayList();
            MyDoubleSets = new ArrayList();
            OppSingleSets = new ArrayList();
            OppDoubleSets = new ArrayList();

            IsFirstTurn = false;
            CanWin = false;
            CanBlock = false;
            CanSetUpNextTurnWin = false;
            NoGoodMoveRemaining = false;
        }


        private void calculateMySingleSets()
        {
            foreach (TerritoryPosition posToConsider in MyTerritories)
            {
                var winSetsWithPos = from WinSet set in WinSetDefinitions
                                     where set.list.Contains(posToConsider)
                                     select set;

                foreach (WinSet set in winSetsWithPos)
                {
                    int ownedCount = 0;
                    int availCount = 0;
                    SingleSet singleSet = new SingleSet(set);

                    foreach (TerritoryPosition pos in set.list)
                    {
                        if (pos == posToConsider)
                        {
                            singleSet.PosIOwn = pos;
                            ownedCount++;
                            continue;
                        }
                        else if (AvailTerritories.Contains(pos))
                        {
                            if (availCount == 0)
                            {
                                singleSet.PosAvailOne = pos;
                                availCount++;
                            }
                            else if (availCount == 1)
                            {
                                singleSet.PosAvailTwo = pos;
                                availCount++;
                            }
                        }
                        else if (MyTerritories.Contains(pos))
                        {
                            break;
                        }
                        else if (OpponentTerritories.Contains(pos))
                        {
                            break;
                        }
                    }

                    if (ownedCount == 1 && availCount == 2)
                    {
                        MySingleSets.Add(singleSet);
                    }
                }
            }
        }

        private void calculateMyDoubleSets()
        {
            foreach (WinSet set in WinSetDefinitions)
            {
                int ownedCount = 0;
                int availCount = 0;
                DoubleSet doubleSet = new DoubleSet(set);
                foreach (TerritoryPosition pos in set.list)
                {
                    if (MyTerritories.Contains(pos))
                    {
                        if (ownedCount == 0)
                        {
                            doubleSet.PosIOwnOne = pos;
                            ownedCount++;
                        }
                        else if (ownedCount == 1)
                        {
                            doubleSet.PosIOwnTwo = pos;
                            ownedCount++;
                        }
                    }
                    else if (AvailTerritories.Contains(pos))
                    {
                        doubleSet.PosAvail = pos;
                        availCount++;
                    }
                    else if (OpponentTerritories.Contains(pos))
                    {
                        break;
                    }
                }
                if (ownedCount == 2 && availCount == 1)
                {
                    MyDoubleSets.Add(doubleSet);
                }
  
            }
        }

        private void calculateOppSingleSets()
        {
            foreach (WinSet set in WinSetDefinitions)
            {
                int ownedCount = 0;
                int availCount = 0;
                SingleSet singleSet = new SingleSet(set);
                foreach (TerritoryPosition pos in set.list)
                {
                    if (AvailTerritories.Contains(pos))
                    {
                        if (availCount == 0)
                        {
                            singleSet.PosAvailOne = pos;
                            availCount++;
                        }
                        else if (availCount == 1)
                        {
                            singleSet.PosAvailTwo = pos;
                            availCount++;
                        }
                    }
                    else if (OpponentTerritories.Contains(pos))
                    {
                        singleSet.PosIOwn = pos;
                        ownedCount++;
                    }
                    else if (MyTerritories.Contains(pos))
                    {
                        break;
                    }
                }
                if (ownedCount == 1 && availCount == 2)
                {
                    OppSingleSets.Add(singleSet);
                }

            }
        }

        private void calculateOppDoubleSets()
        {
            foreach (WinSet set in WinSetDefinitions)
            {
                int ownedCount = 0;
                int availCount = 0;
                DoubleSet doubleSet = new DoubleSet(set);
                foreach (TerritoryPosition pos in set.list)
                {
                    if (OpponentTerritories.Contains(pos))
                    {
                        if (ownedCount == 0)
                        {
                            doubleSet.PosIOwnOne = pos;
                            ownedCount++;
                        }
                        else if (ownedCount == 1)
                        {
                            doubleSet.PosIOwnTwo = pos;
                            ownedCount++;
                        }
                    }
                    else if (AvailTerritories.Contains(pos))
                    {
                        doubleSet.PosAvail = pos;
                        availCount++;
                    }
                    else if (MyTerritories.Contains(pos))
                    {
                        break;
                    }
                }
                if (ownedCount == 2 && availCount == 1)
                {
                    OppDoubleSets.Add(doubleSet);
                }

            }
        }
        

        private void DetermineIfFirstTurn()
        {
            if (MyTerritories.Count == 0)
            {
                IsFirstTurn = true;
            }
            else
            {
                IsFirstTurn = false;
            }
        }

        private void DetermineIfCanWin()
        {
            if (MyDoubleSets.Count > 0)
            {
                CanWin = true;
            }
            else
            {
                CanWin = false;
            }
        }

        private void DetermineIfCanBlock()
        {
            if (OppDoubleSets.Count > 0)
            {
                CanBlock = true;
            }
            else
            {
                CanBlock = false;
            }
        }

        private void DetermineIfCanSetUpNextTurnWin()
        {
            if (MySingleSets.Count > 0 && OppDoubleSets.Count == 0)
            {
                CanSetUpNextTurnWin = true;
            }
            else
            {
                CanSetUpNextTurnWin = false;
            }
        }

        private void DetermineIfNoGoodMoveRemaining()
        {
            if (MySingleSets.Count == 0 && MyDoubleSets.Count == 0 && OppDoubleSets.Count == 0)
            {
                NoGoodMoveRemaining = true;
            }
            else
            {
                NoGoodMoveRemaining = false;
            }
        }

        #endregion


        #region Durring Turn Decision Process

        public override void decideNextMove()
        {
            //Project 3 way of doing it:
            MyPick = RuleSelectorAndRuleApplier();   


            Territory claimed = Board[(int)MyPick] as Territory;
            CurrTurnFrame.ClaimedTerritory = claimed;
            CurrTurnFrame.ReasoningForMove = moveReason;
            CurrTurnFrame.ReasoningForHowMoveReasonDetermined = reasoningAboutMove;
            CurrTurnFrame.WinSetImInterestedIn = setImInterestedIn;
            CurrTurnFrame.WhyImInterestedInThisWinSet = whyImInterestedIn;

            CurrTurnFrame.IsFirstTurn = IsFirstTurn;
            CurrTurnFrame.CanWin = CanWin;
            CurrTurnFrame.CanBlock = CanBlock;
            CurrTurnFrame.CanSetUpNextTurnWin = CanSetUpNextTurnWin;
            CurrTurnFrame.NoGoodMoveRemaining = NoGoodMoveRemaining;
  

            //Project 1+2 way of doing it:
                //ORIGdecideNextMove();
                
            //Alternate Method I was trying of doing it:
                //PreDecisionUpdateTrackedSets();
                //TerritoryPosition pick = NEWdecideNextMove();
                //PostDecisionUpdateTracedSets(pick);
                //return pick;
                //return TerritoryPosition.NULL;
        }


        public TerritoryPosition RuleSelectorAndRuleApplier()
        {
            //RULE 1: If I do not own any territories yet, Then pick my first one randomly.
            if (IsFirstTurn)
            {
                return BuildSingleSet();
            }

            //RULE 2: If there is an avail territory that will make me win, Then pick that territory.
            if (CanWin)
            {
                return CompleteMySet();
            }

            //Rule 3: If there is an avail territory that will make opponent win, Then pick that territory to block them.
            if (CanBlock)
            {
                return CompleteOppSet();
            }

            //RULE 4: If there is an avail territory in a winSet from which I already own a territory and my opponent does not own a territory,
            //        Then choose one of the other two avail territories in that winSet.
            if (CanSetUpNextTurnWin)
            {
                return BuildDoubleSet();
            }
            
            //RULE 5: If there are avail territories, Then pick my one randomly.
            if (NoGoodMoveRemaining)
            {
                return PickRandom();
            }

            return TerritoryPosition.NULL;
        }


        private TerritoryPosition BuildSingleSet()
        {
            Random rand = new Random();
            TerritoryPosition pick = (TerritoryPosition)AvailTerritories[rand.Next(0, AvailTerritories.Count)];

            moveReason = MoveReason.FirstTurn;
            reasoningAboutMove = new ArrayList();
            reasoningAboutMove.Add("I choose this position randomly because it is my first turn.");

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition CompleteMySet()
        {
            DoubleSet set = (DoubleSet)MyDoubleSets[0];
            TerritoryPosition pick = set.PosAvail;
            ArrayList reasoning = new ArrayList();

            reasoning.Add(String.Format("WinSet I think I can win from:"));
            reasoning.Add(String.Format("{0} - {1} - {2}", set.DefiningWinSet.list[0], set.DefiningWinSet.list[1], set.DefiningWinSet.list[2]));
            reasoning.Add("");
            reasoning.Add(String.Format("CanWin because:"));
            reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ]",
                set.PosAvail, TerritoryPositionState.Avail,
                set.PosIOwnOne, TerritoryPositionState.Own,
                set.PosIOwnTwo, TerritoryPositionState.Own));

            setImInterestedIn = set.list;
            whyImInterestedIn = new ArrayList() { TerritoryPositionState.Avail, TerritoryPositionState.Own, TerritoryPositionState.Own };

            moveReason = MoveReason.CanWin;
            reasoningAboutMove = reasoning;

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition CompleteOppSet()
        {
            DoubleSet set = (DoubleSet)OppDoubleSets[0];
            TerritoryPosition pick = set.PosAvail;
            ArrayList reasoning = new ArrayList();

            reasoning.Add(String.Format("WinSet I think my opponent can win from:"));
            reasoning.Add(String.Format("{0} - {1} - {2}", set.DefiningWinSet.list[0], set.DefiningWinSet.list[1], set.DefiningWinSet.list[2]));
            reasoning.Add("");
            reasoning.Add(String.Format("CanBlock because:"));
            reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ]",
                set.PosAvail, TerritoryPositionState.Avail,
                set.PosIOwnOne, TerritoryPositionState.OppOwn,
                set.PosIOwnTwo, TerritoryPositionState.OppOwn));

            setImInterestedIn = set.list;
            whyImInterestedIn = new ArrayList() { TerritoryPositionState.Avail, TerritoryPositionState.OppOwn, TerritoryPositionState.OppOwn };

            moveReason = MoveReason.CanBlock;
            reasoningAboutMove = reasoning;

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition BuildDoubleSet()
        {
            SingleSet set = (SingleSet)MySingleSets[0];
            Random rand = new Random();
            TerritoryPosition pick;
            ArrayList reasoning = new ArrayList();
            
            int whichToPick = rand.Next(0, 1);
            if (whichToPick == 0)
            {
                pick = set.PosAvailOne;
            }
            else if (whichToPick == 1)
            {
                pick = set.PosAvailTwo;
            }
            else
            {
                pick = TerritoryPosition.NULL;
            }

            reasoning.Add(String.Format("WinSet I think I can set myself up for a next turn win from:"));
            reasoning.Add(String.Format("{0} - {1} - {2}", set.DefiningWinSet.list[0], set.DefiningWinSet.list[1], set.DefiningWinSet.list[2]));
            reasoning.Add("");
            reasoning.Add(String.Format("CanSetUpNextTurnWin because:"));
            reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                set.PosIOwn, TerritoryPositionState.Own,
                set.PosAvailOne, TerritoryPositionState.Avail,
                set.PosAvailTwo, TerritoryPositionState.Avail));

            setImInterestedIn = set.list;
            whyImInterestedIn = new ArrayList() {TerritoryPositionState.Own, TerritoryPositionState.Avail, TerritoryPositionState.Avail };

            moveReason = MoveReason.CanSetUpNextTurnWin;
            reasoningAboutMove = reasoning;

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition PickRandom()
        {
            Random rand = new Random();
            TerritoryPosition pick = (TerritoryPosition)AvailTerritories[rand.Next(0, AvailTerritories.Count)];
            
            moveReason = MoveReason.NoGoodMove;
            reasoningAboutMove = new ArrayList();
            reasoningAboutMove.Add("I choose this position randomly because there are no more good moves remaining.");

            MyTerritories.Add(pick);
            return pick;
        }

        #endregion


        public override String ToString()
        {
            return "Smart T3Agent";
        }



        #region !!IGNORE!! Project 1+2 Decision Methods

        public TerritoryPosition ORIGdecideNextMove()
        {
            TerritoryPosition pick;
            String message;
            ArrayList reasoning = new ArrayList();
            
            Random rand = new Random();

            //RULE 1: If I do not own any territories yet, Then pick my first one randomly.
            if (MyTerritories.Count == 0)
            {
                pick = (TerritoryPosition) AvailTerritories[rand.Next(0, AvailTerritories.Count)];
                message = String.Format(" - Smart Agent: \t First Pick [{0}]", pick);
                if (parent.shouldDisplayConsole)
                {
                    Console.WriteLine(message);
                }
                if (parent.shouldDisplayUI)
                {
                    onNewInfo(message);
                }

                moveReason = MoveReason.FirstTurn;
                reasoningAboutMove = new ArrayList();
                reasoningAboutMove.Add("I choose this position randomly because it is my first turn.");

                MyTerritories.Add(pick);
                return pick;
            }

            //RULE 2: If there is an avail territory that will make me win, Then pick that territory.
            pick = canWin(reasoning);
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Win [{0}]", pick);
                if (parent.shouldDisplayConsole)
                {
                    Console.WriteLine(message);
                }
                if (parent.shouldDisplayUI)
                {
                    onNewInfo(message);
                }

                moveReason = MoveReason.CanWin;
                reasoningAboutMove = reasoning;

                MyTerritories.Add(pick);
                return pick;
            }

            //Rule 3: If there is an avail territory that will make opponent win, Then pick that territory to block them.
            pick = canBlock(reasoning);
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Block [{0}]", pick);
                if (parent.shouldDisplayConsole)
                {
                    Console.WriteLine(message);
                }
                if (parent.shouldDisplayUI)
                {
                    onNewInfo(message);
                }

                moveReason = MoveReason.CanBlock;
                reasoningAboutMove = reasoning;

                MyTerritories.Add(pick);
                return pick;
            }

            //RULE 4: If there is an avail territory in a winSet from which I already own a territory and my opponent does not own a territory,
            //        Then choose one of the other two avail territories in that winSet.
            pick = canSetUpNextTurnWin(reasoning);
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Set-Up-Next-Turn-Win [{0}]", pick);
                if (parent.shouldDisplayConsole)
                {
                    Console.WriteLine(message);
                }
                if (parent.shouldDisplayUI)
                {
                    onNewInfo(message);
                }

                moveReason = MoveReason.CanSetUpNextTurnWin;
                reasoningAboutMove = reasoning;

                MyTerritories.Add(pick);
                return pick;
            }

            //RULE 5: If there are avail territories, Then pick my one randomly.
            pick = (TerritoryPosition) AvailTerritories[rand.Next(0, AvailTerritories.Count)];
            message = String.Format(" - Smart Agent: \t Pick Rand b/c No-Good-Moves-Left [{0}]", pick);
            if (parent.shouldDisplayConsole)
            {
                Console.WriteLine(message);
            }
            if (parent.shouldDisplayUI)
            {
                onNewInfo(message);
            }

            moveReason = MoveReason.NoGoodMove;
            reasoningAboutMove = new ArrayList();
            reasoningAboutMove.Add("I choose this position randomly because there are no more good moves remaining.");

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition canWin(ArrayList reasoning)
        {
            ArrayList winningPositions = new ArrayList();
            ArrayList conditionForInclusion = new ArrayList();
            ArrayList winningSetDefn;

            foreach (TerritoryPosition posToConsider in AvailTerritories)
            {
                foreach (WinSet set in WinSetDefinitions)
                {
                    winningSetDefn = set.list;
                    if (set.list.Contains(posToConsider))
                    {
                        int count = 0;
                        foreach (TerritoryPosition pos in set.list)
                        {
                            if (MyTerritories.Contains(pos))
                            {
                                winningPositions.Insert(count, pos);
                                conditionForInclusion.Insert(count, TerritoryPositionState.Own);
                                count++;
                            }
                            else if (pos == posToConsider)
                            {
                                winningPositions.Insert(count, pos);
                                conditionForInclusion.Insert(count, TerritoryPositionState.Avail);
                                count++;
                            }
                        }
                        if (count == 3)
                        {
                            reasoning.Add(String.Format("WinSet I think I can win from:"));
                            reasoning.Add(String.Format("{0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                            reasoning.Add("");
                            reasoning.Add(String.Format("CanWin because:"));
                            reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ]", 
                                winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                                winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                                winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                            if (parent.shouldDisplayConsole)
                            {
                                Console.WriteLine(String.Format("WinSet I think I can win from: {0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                                Console.WriteLine(String.Format("CanWin because: [ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                                    winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                                    winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                                    winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                            }
                            setImInterestedIn = winningPositions;
                            whyImInterestedIn = conditionForInclusion;
                            return posToConsider;
                        }
                        winningPositions.Clear();
                        conditionForInclusion.Clear();
                    }
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canBlock(ArrayList reasoning)
        {
            ArrayList winningPositions = new ArrayList();
            ArrayList conditionForInclusion = new ArrayList();
            ArrayList winningSetDefn;

            foreach (TerritoryPosition posToConsider in AvailTerritories)
            {
                var winSetsWithPos = from WinSet set in WinSetDefinitions
                                     where set.list.Contains(posToConsider)
                                     select set;

                foreach (WinSet set in winSetsWithPos)
                {
                    winningSetDefn = set.list;
                    var otherTwoPositions = from TerritoryPosition position in set.list
                                            where OpponentTerritories.Contains(position)
                                            select position;

                    int count = 0;
                    foreach (var v in otherTwoPositions)
                    {
                        winningPositions.Insert(count, v);
                        conditionForInclusion.Insert(count, TerritoryPositionState.OppOwn);
                        count++;
                    }

                    System.Collections.Generic.IEnumerable<TerritoryPosition> availPos = from TerritoryPosition position in set.list
                                                                                         where !(OpponentTerritories.Contains(position))
                                                                                         select position;
                    foreach (var v in availPos)
                    {
                        winningPositions.Add(v);
                        conditionForInclusion.Add(TerritoryPositionState.Avail);
                    }

                    if (count == 2)
                    {
                        reasoning.Add(String.Format("WinSet I think my opponent can win from:"));
                        reasoning.Add(String.Format("{0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                        reasoning.Add("");
                        reasoning.Add(String.Format("CanBlock because:"));
                        reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                            winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                            winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                            winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                        if (parent.shouldDisplayConsole)
                        {
                            Console.WriteLine(String.Format("WinSet I think my opponent can win from: {0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                            Console.WriteLine(String.Format("CanBlock because: [ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                                winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                                winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                                winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                        }
                        setImInterestedIn = winningPositions;
                        whyImInterestedIn = conditionForInclusion;
                        return posToConsider;
                    }

                    winningPositions.Clear();
                    conditionForInclusion.Clear();
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canSetUpNextTurnWin(ArrayList reasoning)
        {
            ArrayList winningPositions = new ArrayList();
            ArrayList conditionForInclusion = new ArrayList();
            ArrayList winningSetDefn;

            foreach (TerritoryPosition posToConsider in AvailTerritories)
            {
                var winSetsWithPos = from WinSet set in WinSetDefinitions
                                     where set.list.Contains(posToConsider)
                                     select set;

                foreach (WinSet set in winSetsWithPos)
                {
                    winningSetDefn = set.list;
                    int ownedCount = 0;
                    foreach (TerritoryPosition pos in set.list)
                    {
                        if (pos == posToConsider)
                        {
                            winningPositions.Add(pos);
                            conditionForInclusion.Add(TerritoryPositionState.Avail);
                            continue;
                        }
                        else if (OpponentTerritories.Contains(pos))
                        {
                            ownedCount--;
                        }
                        else if (MyTerritories.Contains(pos))
                        {
                            winningPositions.Add(pos);
                            conditionForInclusion.Add(TerritoryPositionState.Own);
                            ownedCount++;
                        }
                        else
                        {
                            winningPositions.Add(pos);
                            conditionForInclusion.Add(TerritoryPositionState.Avail);
                        }
                    }

                    if (ownedCount == 1)
                    {
                        reasoning.Add(String.Format("WinSet I think I can set myself up for a next turn win from:"));
                        reasoning.Add(String.Format("{0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                        reasoning.Add("");
                        reasoning.Add(String.Format("CanSetUpNextTurnWin because:"));
                        reasoning.Add(String.Format("[ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                            winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                            winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                            winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                        if (parent.shouldDisplayConsole)
                        {
                            Console.WriteLine(String.Format("WinSet I think I can set myself up for a next turn win from: {0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                            Console.WriteLine(String.Format("CanSetUpNextTurnWin because: [ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ",
                                winningPositions[0], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[0]),
                                winningPositions[1], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[1]),
                                winningPositions[2], EnumToStringConverter.ConvertTerritoryPositionState((TerritoryPositionState)conditionForInclusion[2])));
                        }
                        setImInterestedIn = winningPositions;
                        whyImInterestedIn = conditionForInclusion;
                        return posToConsider;
                    }

                    winningPositions.Clear();
                    conditionForInclusion.Clear();
                }
            }

            return TerritoryPosition.NULL;
        }

        #endregion

        #region !!IGNORE!! First Attempt to Use Sets Only

        /*
        public TerritoryPosition NEWdecideNextMove()
        {
            TerritoryPosition pick;
            Random rand = new Random();

            if (MyTerritories.Count == 0)
            {
                pick = (TerritoryPosition)AvailTerritories[rand.Next(0, AvailTerritories.Count)];
            }

            pick = canWin_lookAtSets();
            if (pick != TerritoryPosition.NULL)
            {
                MyTerritories.Add(pick);
                return pick;
            }

            pick = canBlock_lookAtSets();
            if (pick != TerritoryPosition.NULL)
            {
                MyTerritories.Add(pick);
                return pick;
            }

            pick = canSetUpNextTurnWin_lookAtSets();
            if (pick != TerritoryPosition.NULL)
            {
                MyTerritories.Add(pick);
                return pick;
            }

            pick = (TerritoryPosition)AvailTerritories[rand.Next(0, AvailTerritories.Count)];
            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition canWin_lookAtSets()
        {
            if (MyDoubleSets.Count != 0)
            {
                WinSet winningSet = (WinSet)MyDoubleSets[0];
                foreach (TerritoryPosition pos in winningSet.list)
                {
                    if (!MyTerritories.Contains(pos))
                        return pos;
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canBlock_lookAtSets()
        {
            if (OppDoubleSets.Count != 0)
            {
                WinSet blockingSet = (WinSet)OppDoubleSets[0];
                foreach (TerritoryPosition pos in blockingSet.list)
                {
                    if (!OpponentTerritories.Contains(pos))
                        return pos;
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canSetUpNextTurnWin_lookAtSets()
        {
            if (MySingleSets.Count != 0)
            {
                WinSet potentialSet = (WinSet)MySingleSets[0];
                foreach (TerritoryPosition pos in potentialSet.list)
                {
                    if (!MyTerritories.Contains(pos))
                        return pos;
                }
            }

            return TerritoryPosition.NULL;
        }

        public void PreDecisionUpdateTrackedSets()
        {
            if (OpponentTerritories.Count == 0)
                return;

            foreach (WinSet set in WinSetPosBelongsTo(OppLastMove()))
            {
                bool removed = removeSetFromMineAndReport(set);
                if (!removed)
                {
                    trackOppSet(set);
                }
            }
        }

        public void PostDecisionUpdateTracedSets(TerritoryPosition pick)
        {
            foreach (WinSet set in WinSetPosBelongsTo(pick))
            {
                bool removed = removeSetFromOppAndReport(set);
                if (!removed)
                {
                    trackMySet(set);
                }
            }
        }

        private void trackOppSet(WinSet set)
        {
            if (OppSingleSets.Contains(set))
            {
                OppSingleSets.Remove(set);
                OppDoubleSets.Add(set);
            }
            else
            {
                OppSingleSets.Add(set);
            }
        }

        private void trackMySet(WinSet set)
        {
            if (MySingleSets.Contains(set))
            {
                MySingleSets.Remove(set);
                MyDoubleSets.Add(set);
            }
            else
            {
                MySingleSets.Add(set);
            }
        }

        private bool removeSetFromMineAndReport(WinSet set)
        {
            bool removed = MySingleSets.Contains(set) || MyDoubleSets.Contains(set);
            if (removed)
            {
                MySingleSets.Remove(set);
                MyDoubleSets.Remove(set);
            }
            return removed;
        }

        private bool removeSetFromOppAndReport(WinSet set)
        {
            bool removed = OppSingleSets.Contains(set) || OppDoubleSets.Contains(set);
            if (removed)
            {
                OppSingleSets.Remove(set);
                OppDoubleSets.Remove(set);
            }
            return removed;
        }

        public System.Collections.Generic.IEnumerable<WinSet> WinSetPosBelongsTo(TerritoryPosition pos)
        {
            //ArrayList setsPosBelongsTo = new ArrayList();
            var winSetsWithPos = from WinSet set in WinSetDefinitions
                                 where set.list.Contains(pos)
                                 select set;

            return winSetsWithPos;
        }

        private TerritoryPosition OppLastMove()
        {
            return (TerritoryPosition) OpponentTerritories[OpponentTerritories.Count - 1];
        }
        */

        #endregion


    }
}
