using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.ExplicitDomainKnowledge
{
    public enum MoveReason
    {
        NavieMove = 0,
        FirstTurn,
        CanWin,
        CanBlock,
        CanSetUpNextTurnWin,
        NoGoodMove,
        NULL
    }

    public static class MoveReasonings
    {
        public static String ConvertReasoning(MoveReason reason)
        {
            if (reason == MoveReason.NavieMove)
                return "NaiveMove";
            if (reason == MoveReason.FirstTurn)
                return "FirstTurn";
            if (reason == MoveReason.CanWin)
                return "CanWin";
            if (reason == MoveReason.CanBlock)
                return "CanBlock";
            if (reason == MoveReason.CanSetUpNextTurnWin)
                return "CanSetUpNextTurnWin";
            if (reason == MoveReason.NoGoodMove)
                return "NoGoodMove";

            return "NULL";
        }
    }
}
