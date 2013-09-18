using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Territory
    {
        private Player owner;
        public TerritoryPosition position;
        public String symbol;

        public Territory(TerritoryPosition pos)
        {
            owner = null;
            position = pos;
            symbol = "#";
        }

        public void setOwner(Player newOwner)
        {
            owner = newOwner;
            symbol = newOwner.getSymbol();
        }
    }
}
