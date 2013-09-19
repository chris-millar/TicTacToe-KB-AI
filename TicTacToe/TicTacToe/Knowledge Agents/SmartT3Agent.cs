using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class SmartT3Agent : Agent
    {
        bool consoleMode;

          
        public SmartT3Agent()
        {
            consoleMode = false;
        }

        public override TerritoryPosition decideNextMove(ArrayList avail, ArrayList oppTerr, ArrayList myTerr, ArrayList board)
        {
            Random rand = new Random();
            
            String message;

            //RULE 1: If I do not own any territories yet, Then pick my first one randomly.
            if (myTerr.Count == 0)
            {
                TerritoryPosition first = (TerritoryPosition)avail[rand.Next(0, avail.Count)];
                message = String.Format(" - Smart Agent: \t First Pick [{0}]", first);
                if (consoleMode)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    onNewInfo(message);
                }
                return first;
            }
            
            TerritoryPosition pick;

            //RULE 2: If there is an avail territory that will make me win, Then pick that territory.
            pick = canWin(avail, board, myTerr);
            Console.WriteLine(String.Format("{0} canWin() says: {1}", parent.name, pick));
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Win [{0}]", pick);
                if (consoleMode)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    onNewInfo(message);
                }
                return pick;
            }

            //Rule 3: If there is an avail territory that will make opponent win, Then pick that territory to block them.
            pick = canBlock(avail, board, oppTerr);
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Block [{0}]", pick);
                if (consoleMode)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    onNewInfo(message);
                }
                return pick;
            }

            //RULE 4: If there is an avail territory in a winSet from which I already own a territory and my opponent does not own a territory,
            //        Then choose one of the other two avail territories in that winSet.
            pick = canSetUpNextTurnWin(avail, board, oppTerr, myTerr);
            if (pick != TerritoryPosition.NULL)
            {
                message = String.Format(" - Smart Agent: \t Can Set-Up-Next-Turn-Win [{0}]", pick);
                if (consoleMode)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    onNewInfo(message);
                }
                return pick;
            }

            //RULE 5: If there are avail territories, Then pick my one randomly.
            pick = (TerritoryPosition)avail[rand.Next(0, avail.Count)];
            message = String.Format(" - Smart Agent: \t Pick Rand b/c No-Good-Moves-Left [{0}]", pick);
            if (consoleMode)
            {
                Console.WriteLine(message);
            }
            else
            {
                onNewInfo(message);
            }
            return pick;
        }

        private TerritoryPosition canWin(ArrayList avail, ArrayList board, ArrayList myTerr)
        {
            ArrayList winningPositions = new ArrayList();
            ArrayList conditionForInclusion = new ArrayList();
            ArrayList winningSetDefn;

            foreach (TerritoryPosition posToConsider in avail)
            {
                foreach (ArrayList list in WinSetDefinitions)
                {
                    winningSetDefn = list;
                    if (list.Contains(posToConsider))
                    {
                        int ownCount = 0;
                        foreach (TerritoryPosition pos in list)
                        {
                            if (myTerr.Contains(pos))
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

        private TerritoryPosition canBlock(ArrayList avail, ArrayList board, ArrayList oppTerr)
        {
            foreach (TerritoryPosition posToConsider in avail)
            {
                var winSetsWithPos = from ArrayList list in WinSetDefinitions
                                     where list.Contains(posToConsider)
                                     select list;

                foreach (ArrayList list in winSetsWithPos)
                {
                    var otherTwoPositions = from TerritoryPosition position in list
                                            where oppTerr.Contains(position)
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

        private TerritoryPosition canSetUpNextTurnWin(ArrayList avail, ArrayList board, ArrayList oppTerr, ArrayList myTerr)
        {
            foreach (TerritoryPosition posToConsider in avail)
            {
                var winSetsWithPos = from ArrayList list in WinSetDefinitions
                                     where list.Contains(posToConsider)
                                     select list;

                foreach (ArrayList list in winSetsWithPos)
                {
                    int ownedCount = 0;
                    foreach (TerritoryPosition pos in list)
                    {
                        if (pos == posToConsider)
                        {
                            continue;
                        }
                        else if (oppTerr.Contains(pos))
                        {
                            ownedCount--;
                        }
                        else if (myTerr.Contains(pos))
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
