using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe.ExplicitDomainKnowledge
{
    public class WinSet
    {
        public ArrayList list;

        public WinSet(TerritoryPosition p1, TerritoryPosition p2, TerritoryPosition p3)
        {
            list = new ArrayList();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
        }

        
    }
}
