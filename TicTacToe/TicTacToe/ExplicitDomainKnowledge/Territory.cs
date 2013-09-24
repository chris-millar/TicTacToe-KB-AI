using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Territory
    {
        private Player owner;
        public TerritoryPosition position;
        public String symbol;

        public Territory(TerritoryPosition pos)
        {
            owner = null;
            position = pos;
            symbol = "";
        }

        public void setOwner(Player newOwner)
        {
            owner = newOwner;
            if (newOwner == null)
                symbol = "";
            else
                symbol = newOwner.getSymbol();
        }

        public String getPosition()
        {
            if (position == TerritoryPosition.NW)
                return "NW";
            if (position == TerritoryPosition.N)
                return "N";
            if (position == TerritoryPosition.NE)
                return "NE";

            if (position == TerritoryPosition.W)
                return "W";
            if (position == TerritoryPosition.M)
                return "M";
            if (position == TerritoryPosition.E)
                return "E";

            if (position == TerritoryPosition.SW)
                return "SW";
            if (position == TerritoryPosition.S)
                return "S";
            if (position == TerritoryPosition.SE)
                return "SE";

            return "NULL";
        }

        public Player getOwner()
        {
            return owner;
        }


    }
}
