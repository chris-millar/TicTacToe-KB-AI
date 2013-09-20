using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TicTacToe.ExplicitDomainKnowledge;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        Player playerOne;
        Player playerTwo;
        Player currTurnPlayer;
        Player otherPlayer;

        public Territory[] board;
        Territory[] availPositions;

        ArrayList boardList;
        ArrayList availList;

        ArrayList winSetDefinitions;

        bool consoleMode;


        public event EventHandler TurnOver;
        private void onTurnOver()
        {
            if (TurnOver != null)
            {
                TurnOver(this, new EventArgs());
            }
        }

        public event EventHandler NewInfo;
        private void onNewInfo(String message)
        {
            if (NewInfo != null)
            {
                NewInfo(message, new EventArgs());
            }
        }

        public TicTacToeGame(Agent one, Agent two)
        {
            consoleMode = false;

            playerOne = new Player("Player 1", "X", one);
            playerOne.NewInfo += new EventHandler(playerOne_NewInfo);

            playerTwo = new Player("Player 2", "O", two);
            playerTwo.NewInfo += new EventHandler(playerTwo_NewInfo);

            initBoard();
            initWinSetDefinitions();

            //turn();
        }


        public void start()
        {
            giveAgentsStaticDomainKnowledge();

            currTurnPlayer = playerOne;
            otherPlayer = playerTwo;

            turn();
        }

        public void initBoard()
        {
            board = new Territory[9];
            availPositions = new Territory[9];

            board[0] = new Territory(TerritoryPosition.NW);
            board[1] = new Territory(TerritoryPosition.N);
            board[2] = new Territory(TerritoryPosition.NE);

            board[3] = new Territory(TerritoryPosition.W);
            board[4] = new Territory(TerritoryPosition.M);
            board[5] = new Territory(TerritoryPosition.E);

            board[6] = new Territory(TerritoryPosition.SW);
            board[7] = new Territory(TerritoryPosition.S);
            board[8] = new Territory(TerritoryPosition.SE);

            boardList = new ArrayList(board);
            availList = new ArrayList();
            
            foreach ( Territory terr in boardList)
            {
                availList.Add(terr.position);
            }

        }

        public void turn()
        {
            String turnMessage = String.Format("\nIt's {0}'s turn: \t [ {1} ]", currTurnPlayer.name, currTurnPlayer.getSymbol());
            if (consoleMode)
                Console.WriteLine(turnMessage);
            else
                onNewInfo(turnMessage);

            //Decide move & make it
            claimTerritory(currTurnPlayer.makeMove(availList, otherPlayer.ownedTerritories, boardList));

            printBoard();

            onNewInfo("");

            if (isGameOver())
            {
                String gameoverMessage;

                if (didPlayerWin())
                    gameoverMessage = String.Format("\nGAME OVER: {0} is the Winner!", currTurnPlayer.name);
                else
                    gameoverMessage = String.Format("\nGAME OVER: Draw! Neither player won.");


                if (consoleMode)
                {
                    Console.WriteLine(gameoverMessage);
                }
                else
                {
                    onNewInfo(gameoverMessage);
                }
            }
            else
            {
                if (currTurnPlayer == playerOne)
                {
                    currTurnPlayer = playerTwo;
                    otherPlayer = playerOne;
                }
                else
                {
                    currTurnPlayer = playerOne;
                    otherPlayer = playerTwo;
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

                onTurnOver();

                turn();
            }
        }

        private void claimTerritory(TerritoryPosition position)
        {
            Territory claimed = boardList[(int) position] as Territory;
            claimed.setOwner(currTurnPlayer);

            availList.Remove(position);
        }

        private bool isGameOver()
        {
            if (didPlayerWin())
                return true;
            else if (noMoreSpacesAvail())
                return true;
            else
                return false;
        }

        private bool didPlayerWin()
        {
            foreach (WinSet set in winSetDefinitions)
            {
                int ownCount = 0;
                foreach (TerritoryPosition pos in set.list)
                {
                    if (currTurnPlayer.doOwnTerrPosition(pos))
                    {
                        ownCount++;
                    }
                }
                if (ownCount == 3)
                {
                    return true;
                }
            }
                
            return false;
        }

        private bool noMoreSpacesAvail()
        {
            return (availList.Count == 0);
        }

        /*
        private void initWinConditions()
        {
            ArrayList winSet0 = new ArrayList { TerritoryPosition.NW, TerritoryPosition.N, TerritoryPosition.NE };
            ArrayList winSet1 = new ArrayList { TerritoryPosition.W,  TerritoryPosition.M, TerritoryPosition.E  };
            ArrayList winSet2 = new ArrayList { TerritoryPosition.SW, TerritoryPosition.S, TerritoryPosition.SE };

            ArrayList winSet3 = new ArrayList { TerritoryPosition.NW, TerritoryPosition.W, TerritoryPosition.SW };
            ArrayList winSet4 = new ArrayList { TerritoryPosition.N,  TerritoryPosition.M, TerritoryPosition.S  };
            ArrayList winSet5 = new ArrayList { TerritoryPosition.NE, TerritoryPosition.E, TerritoryPosition.SE };

            ArrayList winSet6 = new ArrayList { TerritoryPosition.NW, TerritoryPosition.M, TerritoryPosition.SE };
            ArrayList winSet7 = new ArrayList { TerritoryPosition.NE, TerritoryPosition.M, TerritoryPosition.SW };

            winSetDefinitions = new ArrayList();

            winSetDefinitions.Add(winSet0);
            winSetDefinitions.Add(winSet1);
            winSetDefinitions.Add(winSet2);
            winSetDefinitions.Add(winSet3);
            winSetDefinitions.Add(winSet4);
            winSetDefinitions.Add(winSet5);
            winSetDefinitions.Add(winSet6);
            winSetDefinitions.Add(winSet7);
        }
         */

        private void initWinSetDefinitions()
        {
            WinSet winSet0 = new WinSet(TerritoryPosition.NW, TerritoryPosition.N, TerritoryPosition.NE);
            WinSet winSet1 = new WinSet(TerritoryPosition.W, TerritoryPosition.M, TerritoryPosition.E);
            WinSet winSet2 = new WinSet(TerritoryPosition.SW, TerritoryPosition.S, TerritoryPosition.SE);

            WinSet winSet3 = new WinSet(TerritoryPosition.NW, TerritoryPosition.W, TerritoryPosition.SW);
            WinSet winSet4 = new WinSet(TerritoryPosition.N, TerritoryPosition.M, TerritoryPosition.S);
            WinSet winSet5 = new WinSet(TerritoryPosition.NE, TerritoryPosition.E, TerritoryPosition.SE);

            WinSet winSet6 = new WinSet(TerritoryPosition.NW, TerritoryPosition.M, TerritoryPosition.SE);
            WinSet winSet7 = new WinSet(TerritoryPosition.NE, TerritoryPosition.M, TerritoryPosition.SW);

            winSetDefinitions = new ArrayList();

            winSetDefinitions.Add(winSet0);
            winSetDefinitions.Add(winSet1);
            winSetDefinitions.Add(winSet2);
            winSetDefinitions.Add(winSet3);
            winSetDefinitions.Add(winSet4);
            winSetDefinitions.Add(winSet5);
            winSetDefinitions.Add(winSet6);
            winSetDefinitions.Add(winSet7);
        }

        private void giveAgentsStaticDomainKnowledge()
        {
            playerOne.setWinSetDefinitions(winSetDefinitions);
            playerTwo.setWinSetDefinitions(winSetDefinitions);
        }

        private void printBoard()
        {
            String line1 = String.Format("\n{0}  |  {1}  |  {2}", board[0].symbol, board[1].symbol, board[2].symbol);
            String line2 = String.Format("\n{0}  |  {1}  |  {2}", board[3].symbol, board[4].symbol, board[5].symbol);
            String line3 = String.Format("\n{0}  |  {1}  |  {2}", board[6].symbol, board[7].symbol, board[8].symbol);

            if (consoleMode)
            {
                Console.WriteLine(line1);
                Console.WriteLine(line2);
                Console.WriteLine(line3);
            }
            else
            {
                onNewInfo(line1);
                onNewInfo(line2);
                onNewInfo(line3);
            }

        }

        public bool canStartNewGame()
        {
            return true;
        }
        
        void playerOne_NewInfo(object sender, EventArgs e)
        {
            String message = sender as String;
            onNewInfo(message);
        }
        
        void playerTwo_NewInfo(object sender, EventArgs e)
        {
            String message = sender as String;
            onNewInfo(message); 
        }

    }
}
