using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class SmartTicTacToeAgent : Agent
    {
        bool consoleMode;

        /*
        public event EventHandler NewInfo;
        private void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }
        */
          
        public SmartTicTacToeAgent()
        {
            consoleMode = false;
        }

        public override TerritoryPosition decideNextMove(ArrayList avail, ArrayList winDef, ArrayList oppTerr, ArrayList myTerr, ArrayList board, Player opp)
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
            pick = canWin(avail, winDef, board);
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
            pick = canBlock(avail, winDef, board, oppTerr, opp);
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
            pick = canSetUpNextTurnWin(avail, winDef, board, oppTerr, opp, myTerr);
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

        private TerritoryPosition canWin(ArrayList avail, ArrayList winDef, ArrayList board)
        {
            foreach (TerritoryPosition posToConsider in avail)
            {
                foreach (ArrayList list in winDef)
                {
                    if (list.Contains(posToConsider))
                    {
                        int ownCount = 0;
                        foreach (TerritoryPosition pos in list)
                        {
                            if (parent.doOwnTerrPosition(pos) || pos == posToConsider)
                            {
                                ownCount++;
                            }
                        }
                        if (ownCount == 3)
                        {
                            return posToConsider;
                        }
                    }
                }
            }

            return TerritoryPosition.NULL;
        }

        private TerritoryPosition canBlock(ArrayList avail, ArrayList winDef, ArrayList board, ArrayList oppTerr, Player opp)
        {
            foreach (TerritoryPosition posToConsider in avail)
            {
                var winSetsWithPos = from ArrayList list in winDef
                                     where list.Contains(posToConsider)
                                     select list;

                foreach (ArrayList list in winSetsWithPos)
                {
                    var otherTwoPositions = from TerritoryPosition position in list
                                            where opp.ownedTerritories.Contains(position)
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

        private TerritoryPosition canSetUpNextTurnWin(ArrayList avail, ArrayList winDef, ArrayList board, ArrayList oppTerr, Player opp, ArrayList myTerr)
        {
            foreach (TerritoryPosition posToConsider in avail)
            {
                var winSetsWithPos = from ArrayList list in winDef
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
                        else if (opp.ownedTerritories.Contains(pos))
                        {
                            ownedCount--;
                        }
                        else if (parent.ownedTerritories.Contains(pos))
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
            return "Smart TicTacToeAgent";
        }
    }
}
