using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class PlayerStatistics
    {
        public String Name;
        public AgentType PlayersAgent;
        
        public int Wins;
        public int Losses;
        public int Ties;

        public int[] NumberTurnsToWin;
        public int[] NumberTurnsToLose;

        public PlayerStatistics(Player player, Agent agent)
        {
            Name = player.name;
            PlayersAgent = agent.myAgentType;

            Wins = 0;
            Losses = 0;
            Ties = 0;

            NumberTurnsToWin = new int[10];
            for (int i = 0; i < 10; i++)
            {
                NumberTurnsToWin[i] = 0;
            }

            NumberTurnsToLose = new int[10];
            for (int i = 0; i < 10; i++)
            {
                NumberTurnsToLose[i] = 0;
            }
        }

        public void recordWin(int numTurns)
        {
            Wins++;
            NumberTurnsToWin[numTurns]++;
        }

        public void recordLoss(int numTurns)
        {
            Losses++;
            NumberTurnsToLose[numTurns]++;
        }

        public void recordTie()
        {
            Ties++;
        }
    }
}
