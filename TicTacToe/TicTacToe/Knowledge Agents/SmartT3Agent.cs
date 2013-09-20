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
          
        public SmartT3Agent()
        {
            MyTerritories = new ArrayList();
            OpponentTerritories = new ArrayList();
            AvailTerritories = new ArrayList();
        }

        public override TerritoryPosition decideNextMove()
        {
            TerritoryPosition pick;
            String message;
            
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

                MyTerritories.Add(pick);
                return pick;
            }

            //RULE 2: If there is an avail territory that will make me win, Then pick that territory.
            pick = canWin();
            Console.WriteLine(String.Format("{0} canWin() says: {1}", parent.name, pick));
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

                MyTerritories.Add(pick);
                return pick;
            }

            //Rule 3: If there is an avail territory that will make opponent win, Then pick that territory to block them.
            pick = canBlock();
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

                MyTerritories.Add(pick);
                return pick;
            }

            //RULE 4: If there is an avail territory in a winSet from which I already own a territory and my opponent does not own a territory,
            //        Then choose one of the other two avail territories in that winSet.
            pick = canSetUpNextTurnWin();
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

            MyTerritories.Add(pick);
            return pick;
        }

        private TerritoryPosition canWin()
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
                        int ownCount = 0;
                        foreach (TerritoryPosition pos in set.list)
                        {
                            if (MyTerritories.Contains(pos))
                            {
                                winningPositions.Insert(ownCount, pos);
                                conditionForInclusion.Insert(ownCount, "Own");
                                ownCount++;
                            }
                            else if (pos == posToConsider)
                            {
                                winningPositions.Insert(ownCount, pos);
                                conditionForInclusion.Insert(ownCount, "Avail");
                                ownCount++;
                            }
                        }
                        if (ownCount == 3)
                        {
                            Console.WriteLine(String.Format("WinSet I think I can win from: {0} - {1} - {2}", winningSetDefn[0], winningSetDefn[1], winningSetDefn[2]));
                            Console.WriteLine(String.Format("CanWin because: [ {0} - {1} ]  [ {2} - {3} ]  [ {4} - {5} ] ", 
                                winningPositions[0], conditionForInclusion[0],
                                winningPositions[1], conditionForInclusion[1],
                                winningPositions[2], conditionForInclusion[2]));
                            return posToConsider;
                        }
                        winningPositions.Clear();
                        conditionForInclusion.Clear();
                    }
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canBlock()
        {
            foreach (TerritoryPosition posToConsider in AvailTerritories)
            {
                var winSetsWithPos = from WinSet set in WinSetDefinitions
                                     where set.list.Contains(posToConsider)
                                     select set;

                foreach (WinSet set in winSetsWithPos)
                {
                    var otherTwoPositions = from TerritoryPosition position in set.list
                                            where OpponentTerritories.Contains(position)
                                            select position;

                    int count = 0;
                    foreach (var v in otherTwoPositions)
                    {
                        count++;
                    }

                    if (count == 2)
                    {
                        return posToConsider;
                    }
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canSetUpNextTurnWin()
        {
            foreach (TerritoryPosition posToConsider in AvailTerritories)
            {
                var winSetsWithPos = from WinSet set in WinSetDefinitions
                                     where set.list.Contains(posToConsider)
                                     select set;

                foreach (WinSet set in winSetsWithPos)
                {
                    int ownedCount = 0;
                    foreach (TerritoryPosition pos in set.list)
                    {
                        if (pos == posToConsider)
                        {
                            continue;
                        }
                        else if (OpponentTerritories.Contains(pos))
                        {
                            ownedCount--;
                        }
                        else if (MyTerritories.Contains(pos))
                        {
                            ownedCount++;
                        }
                    }

                    if (ownedCount == 1)
                    {
                        return posToConsider;
                    }
                }
            }

            return TerritoryPosition.NULL;
        }

        public override String ToString()
        {
            return "Smart T3Agent";
        }
    }
}
