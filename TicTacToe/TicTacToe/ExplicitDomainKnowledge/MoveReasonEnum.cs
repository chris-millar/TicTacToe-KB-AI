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

    public enum TerritoryPositionState
    {
        Avail = 0,
        Own,
        OppOwn
    }

    public static class EnumToStringConverter
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

        public static String ConvertTerritoryPositionState(TerritoryPositionState state)
        {
            if (state == TerritoryPositionState.Avail)
                return "Avail";
            if (state == TerritoryPositionState.Own)
                return "Own";
            if (state == TerritoryPositionState.OppOwn)
                return "Opp Owns";

            return "NULL";
        }
    }


}
