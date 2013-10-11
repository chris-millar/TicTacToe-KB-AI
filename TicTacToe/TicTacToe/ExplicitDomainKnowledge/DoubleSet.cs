using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.ExplicitDomainKnowledge
{
    public class DoubleSet
    {
        public WinSet DefiningWinSet;
        public TerritoryPosition PosAvail;
        public TerritoryPosition PosIOwnOne;
        public TerritoryPosition PosIOwnTwo;

        public DoubleSet(WinSet set)
        {
            DefiningWinSet = set;
        }
    }
}
