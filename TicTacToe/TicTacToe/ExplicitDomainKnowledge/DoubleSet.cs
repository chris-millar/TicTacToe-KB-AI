using System;
using System.Collections.Generic;
using System.Collections;
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
        public ArrayList list
        {
            get
            {
                if (PosIOwnOne != TerritoryPosition.NULL && PosIOwnTwo != TerritoryPosition.NULL && PosAvail != TerritoryPosition.NULL)
                {
                    return new ArrayList() { PosAvail, PosIOwnOne, PosIOwnTwo };
                }
                else
                {
                    return null;
                }
            }
        }

        public DoubleSet(WinSet set)
        {
            DefiningWinSet = set;
        }
    }
}
