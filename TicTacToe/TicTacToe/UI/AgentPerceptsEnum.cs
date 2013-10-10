using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public enum AgentPercepts
    {
        MyTerr = 0,
        OppTerr,
        AvailTerr,
        WinSets,
        FirstTurn,
        CanWin,
        CanBlock,
        CanSetUpNextTurnWin,
        NoGoodMove,
        MySingleSets,
        MyDoubleSets,
        OppSingleSets,
        OppDoubleSets
    }
}
