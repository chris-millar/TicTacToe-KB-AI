using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public class AppManager
    {
        public MainUI ui;

        public Agent playerOneAgent;
        public Agent playerTwoAgent;
        public TicTacToeGame _game;

        public int numGamesToPlay;
        public bool experimentInProgress;
        public bool gameInProgress;

        public AppManager()
        {
            ui = new MainUI();
            ui.AgentOneSelection += new EventHandler(ui_AgentOneSelection);
            ui.AgentTwoSelection += new EventHandler(ui_AgentTwoSelection);
            ui.StartButtonPressed += new EventHandler(ui_StartButtonPressed);
            ui.RadioButtonPressed += new EventHandler(ui_RadioButtonPressed);
            ui.InitSelections();
        }

        void ui_RadioButtonPressed(object sender, EventArgs e)
        {
            if (!experimentInProgress)
            {
                numGamesToPlay = (int)sender;
            }
        }


        void ui_AgentOneSelection(object sender, EventArgs e)
        {
            //AgentType selection = sender as AgentType;
            playerOneAgent = buildAgent(sender as AgentType);
        }
        
        void ui_AgentTwoSelection(object sender, EventArgs e)
        {
            playerTwoAgent = buildAgent(sender as AgentType);
        }

        void ui_StartButtonPressed(object sender, EventArgs e)
        {
            if (_game == null || _game.canStartNewGame())
            {
                if (_game != null)
                {
                    //UnhookEventListener();
                    _game.resetGame();
                    ui.ResetFauxConsole();    
                }
                else
                {
                    _game = new TicTacToeGame(playerOneAgent, playerTwoAgent);
                    //_game.UpdateOutputOptions(true, true);
                    _game.GameOver += new EventHandler(_game_GameOver);
                    _game.NewInfo += new EventHandler(game_NewInfo);
                    ui.ResetFauxConsole();
                }

                if (numGamesToPlay == 1)
                {
                    _game.showTurn = true;
                    _game.start();
                }
                else
                {
                    ExecuteExperiemnts();
                }
            }


        }

        void _game_GameOver(object sender, EventArgs e)
        {
            gameInProgress = false;
        }

        private void ExecuteExperiemnts()
        {
            experimentInProgress = true;
            _game.showTurn = false;
            PlayerStatistics playerOneStats = new PlayerStatistics(_game.playerOne, playerOneAgent);
            PlayerStatistics playerTwoStats = new PlayerStatistics(_game.playerTwo, playerTwoAgent);
            for (int i = 0; i < numGamesToPlay; i++)
            {
                playNewGame();
                while (gameInProgress) ;
                recordGameStats(playerOneStats, playerTwoStats);
            }

            //GenerateExperimentStatistics();
            OutputExperimentResults(playerOneStats, playerTwoStats);
            experimentInProgress = false;
        }

        private void playNewGame()
        {
            gameInProgress = true;
            _game.resetGame();
            _game.start();
        }

        private void recordGameStats(PlayerStatistics playerOneStats, PlayerStatistics playerTwoStats)
        {
            if (_game.gameOverState == GameOverState.Win)
            {
                int turns = NumTurns();
                if (_game.currTurnPlayer == _game.playerOne)
                {
                    playerOneStats.recordWin(turns);
                    playerTwoStats.recordLoss(turns);
                }
                else
                {
                    playerTwoStats.recordWin(turns);
                    playerOneStats.recordLoss(turns);
                }
            }
            else
            {
                playerOneStats.recordTie();
                playerTwoStats.recordTie();
            }
        }

        private int NumTurns()
        {
            return (9 - _game.availList.Count);
        }

        private void GenerateExperimentStatistics()
        {

        }

        private void OutputExperimentResults(PlayerStatistics playerOneStats, PlayerStatistics playerTwoStats)
        {

            String output = String.Format("Experiment Results for {0} Games Played:", numGamesToPlay);
            ui.AppendFauxConsole(output);

            output = String.Format("Player 1: {0}:", playerOneAgent.ToString());
            ui.AppendFauxConsole(output);

            output = String.Format("W - L - T: {0} - {1} - {2}", playerOneStats.Wins, playerOneStats.Losses, playerOneStats.Ties);
            ui.AppendFauxConsole(output);

            output = String.Format("Turns needed for wins: [5]: {0}   [7]: {1}   [9]: {2}", playerOneStats.NumberTurnsToWin[5], playerOneStats.NumberTurnsToWin[7], playerOneStats.NumberTurnsToWin[9]);
            ui.AppendFauxConsole(output);

            output = String.Format("Turns needed for losses: [6]: {0}   [8]: {1}", playerOneStats.NumberTurnsToLose[6], playerOneStats.NumberTurnsToLose[8]);
            ui.AppendFauxConsole(output);

            ui.AppendFauxConsole("");

            output = String.Format("Player 2: {0}:", playerTwoAgent.ToString());
            ui.AppendFauxConsole(output);

            output = String.Format("W - L - T: {0} - {1} - {2}", playerTwoStats.Wins, playerTwoStats.Losses, playerTwoStats.Ties);
            ui.AppendFauxConsole(output);

            output = String.Format("Turns needed for wins: [6]: {0}   [8]: {1}", playerTwoStats.NumberTurnsToWin[6], playerTwoStats.NumberTurnsToWin[8]);
            ui.AppendFauxConsole(output);

            output = String.Format("Turns needed for losses: [5]: {0}   [7]: {1}   [9]: {2}", playerTwoStats.NumberTurnsToLose[5], playerTwoStats.NumberTurnsToLose[7], playerTwoStats.NumberTurnsToLose[9]);
            ui.AppendFauxConsole(output);
        }

        private void UnhookEventListener()
        {
            if (_game != null)
            {
                _game.NewInfo -= game_NewInfo;
                _game = null;
            }
        }

        void game_NewInfo(object sender, EventArgs e)
        {
            if (!experimentInProgress)
                ui.AppendFauxConsole(sender as String);
        }

        private Agent buildAgent(AgentType type)
        {
            if (type.Val == AgentTypeEnum.Naive)
            {
                //Console.WriteLine(String.Format("Should be Naive: {0}", type));
                return new NaiveT3Agent();
            }
            else if (type.Val == AgentTypeEnum.Smart)
            {
                return new SmartT3Agent();
            }
            else
            {
                throw new InvalidOperationException(String.Format("AgentType: {0}", type));
            }
        }

    }
}
