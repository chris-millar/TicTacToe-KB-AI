using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public static class AgentTypes
    {
        public static AgentType Naive { get { return new AgentType("Naive", AgentTypeEnum.Naive); } }
        public static AgentType Smart { get { return new AgentType("Smart", AgentTypeEnum.Smart); } }
    }

    public class AgentType
    {
        public String Display;
        public AgentTypeEnum Val;

        public AgentType(String display, AgentTypeEnum val)
        {
            Display = display;
            Val = val;
        }

        public override string ToString()
        {
            return Display;
        }
    }

    public enum AgentTypeEnum
    {
        Naive = 0,
        Smart,
        Human,
        NULL
    }
}
