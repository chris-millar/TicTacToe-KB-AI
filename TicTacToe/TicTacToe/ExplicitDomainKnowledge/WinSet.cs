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
        public WinSetEnum setId;
        public String Name
        {
            get { return determineName(); }
        }

        public WinSet(TerritoryPosition p1, TerritoryPosition p2, TerritoryPosition p3, WinSetEnum id)
        {
            list = new ArrayList();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            setId = id;
        }

        private String determineName()
        {
            String ret;
            switch (setId)
            {
                case WinSetEnum.RowTop:
                    ret = "Top Row";
                    break;
                case WinSetEnum.RowMiddle:
                    ret = "Middle Row";
                    break;
                case WinSetEnum.RowBottom:
                    ret = "Bottom Row";
                    break;
                case WinSetEnum.ColLeft:
                    ret = "Left Col";
                    break;
                case WinSetEnum.ColMiddle:
                    ret = "Middle Col";
                    break;
                case WinSetEnum.ColRight:
                    ret = "Right Col";
                    break;
                case WinSetEnum.DiagNeg:
                    ret = "Neg Diag";
                    break;
                case WinSetEnum.DiagPos:
                    ret = "Pos Diag";
                    break;
                default:
                    ret = "";
                    break;
            }

            return ret;
        }

        
    }

    public enum WinSetEnum
    {
        RowTop = 0,
        RowMiddle,
        RowBottom,
        ColLeft,
        ColMiddle,
        ColRight,
        DiagNeg,
        DiagPos
    }
}
