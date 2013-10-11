using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe.ExplicitDomainKnowledge
{
    public class SingleSet
    {
        public WinSet DefiningWinSet;
        public TerritoryPosition PosIOwn;
        public TerritoryPosition PosAvailOne;
        public TerritoryPosition PosAvailTwo;
        public ArrayList list
        {
            get
            {
                if (PosIOwn != TerritoryPosition.NULL && PosAvailOne != TerritoryPosition.NULL && PosAvailTwo != TerritoryPosition.NULL)
                {
                    return new ArrayList() { PosIOwn, PosAvailOne, PosAvailTwo };
                }
                else
                {
                    return null;
                }
            }
        }

        public SingleSet(WinSet set)
        {
            DefiningWinSet = set;
        }

    }
}
