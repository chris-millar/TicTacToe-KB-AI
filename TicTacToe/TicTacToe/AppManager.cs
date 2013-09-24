using System;
using System.Collections.Generic;
using System.Collections;
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

        public ArrayList Frames;
        public TurnFrame CurrFrame;
        public AgentPercepts CurrPercept;

        public int cyclePerceptSize;
        public int cyclePerceptValue;

        public AppManager()
        {
            ui = new MainUI();
            ui.AgentOneSelection += new EventHandler(ui_AgentOneSelection);
            ui.AgentTwoSelection += new EventHandler(ui_AgentTwoSelection);
            ui.StartButtonPressed += new EventHandler(ui_StartButtonPressed);
            ui.RadioButtonPressed += new EventHandler(ui_RadioButtonPressed);
            ui.TurnMenuItemSelected += new EventHandler(ui_TurnMenuItemSelected);
            ui.PerceptMenuItemSelected += new EventHandler(ui_PerceptMenuItemSelected);
            ui.CyclePerceptButtonPressed += new EventHandler(ui_CyclePerceptButtonPressed);
            ui.InitSelections();
        }

        void ui_CyclePerceptButtonPressed(object sender, EventArgs e)
        {
            int value = (int)sender;
            ui.UpdateAgentPercepts(CurrFrame, CurrPercept, false, false);
        }

        void ui_PerceptMenuItemSelected(object sender, EventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            AgentPercepts percept = (AgentPercepts)item.Tag;
            CurrPercept = percept;
            ui.UpdateAgentPercepts(CurrFrame, percept, false, true);
        }

        void ui_TurnMenuItemSelected(object sender, EventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            int turnId = (int)item.Tag;
            CurrFrame = (TurnFrame)Frames[turnId - 1];
            ui.UpdateElements(CurrFrame);
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
                if (_game == null)
                {
                    _game = new TicTacToeGame(playerOneAgent, playerTwoAgent);
                    //_game.UpdateOutputOptions(true, true);
                    _game.TurnOver += new EventHandler(_game_TurnOver);
                    _game.GameOver += new EventHandler(_game_GameOver);
                    _game.NewInfo += new EventHandler(_game_NewInfo);
                    ui.ResetFauxConsole();
                    Frames = new ArrayList();
                }
                else
                {
                    //UnhookEventListener();
                    _game.resetGame(playerOneAgent, playerTwoAgent);
                    ui.ResetFauxConsole();
                    ui.ResetTurnListView();
                    Frames = new ArrayList();
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

        void _game_TurnOver(object sender, EventArgs e)
        {
            if (!experimentInProgress)
            {
                ui.AddTurnToListView(_game.TurnNumber, _game.currTurnPlayer);

                TurnFrame frame = sender as TurnFrame;
                Frames.Add(frame);
                ui.UpdateElements(frame);
            }
        }

        void _game_GameOver(object sender, EventArgs e)
        {
            if (experimentInProgress)
            {
                /*
                gameInProgress = false;
                recordGameStats(playerOneStats, playerTwoStats);
                numGamesPlayed++;
                if (numGamesPlayed < numGamesToPlay)
                    playNewGame();
                else
                {
                    OutputExperimentResults(playerOneStats, playerTwoStats);
                    experimentInProgress = false;
                }
                 */
                gameInProgress = false;
            }
            else //if (!experimentInProgress)
            {
                String gameOverMessage;
                gameOverMessage = _game.GenerateGameOverMessage();
                OutputGameResults(gameOverMessage);
                CurrFrame = (TurnFrame)Frames[Frames.Count - 1];
                gameInProgress = false;
            }
        }

        private void ExecuteExperiemnts()
        {
            experimentInProgress = true;
            _game.showTurn = false;
            PlayerStatistics playerOneStats = new PlayerStatistics(_game.playerOne, playerOneAgent);
            PlayerStatistics playerTwoStats = new PlayerStatistics(_game.playerTwo, playerTwoAgent);
            
            numGamesPlayed = 0;
            //_game.GameOver -= _game_ExperimentWaitForGameOver;
            //_game.GameOver += new EventHandler(_game_ExperimentWaitForGameOver);

            //playNewGame();

            
            for (int i = 0; i < numGamesToPlay; i++)
            {
                playNewGame();
                while (gameInProgress) ;
                recordGameStats(playerOneStats, playerTwoStats);
            }
            

            OutputExperimentResults(playerOneStats, playerTwoStats);
            experimentInProgress = false;
        }

        public int numGamesPlayed;
        //public PlayerStatistics playerOneStats;
        //public PlayerStatistics playerTwoStats;

        /*
        private void _game_ExperimentWaitForGameOver(object sender, EventArgs e)
        {
            if (experimentInProgress)
            {
                gameInProgress = false;
                recordGameStats(playerOneStats, playerTwoStats);
                numGamesPlayed++;
                if (numGamesPlayed < numGamesToPlay)
                    playNewGame();
                else
                {
                    OutputExperimentResults(playerOneStats, playerTwoStats);
                    experimentInProgress = false;
                }
            }
        }
        */

        private void playNewGame()
        {
            gameInProgress = true;
            _game.resetGame(playerOneAgent, playerTwoAgent);
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


        private void OutputExperimentResults(PlayerStatistics playerOneStats, PlayerStatistics playerTwoStats)
        {
            ui.ResetGameStatsField();

            String output = String.Format("Experiment Results for {0} Games Played:", numGamesToPlay);
            ui.AppendGameStatsField(output);

            output = String.Format("Player 1: {0}:", playerOneAgent.ToString());
            ui.AppendGameStatsField(output);

            output = String.Format("W - L - T: {0} - {1} - {2}", playerOneStats.Wins, playerOneStats.Losses, playerOneStats.Ties);
            ui.AppendGameStatsField(output);

            output = String.Format("Turns needed for wins: [5]: {0}   [7]: {1}   [9]: {2}", playerOneStats.NumberTurnsToWin[5], playerOneStats.NumberTurnsToWin[7], playerOneStats.NumberTurnsToWin[9]);
            ui.AppendGameStatsField(output);

            output = String.Format("Turns needed for losses: [6]: {0}   [8]: {1}", playerOneStats.NumberTurnsToLose[6], playerOneStats.NumberTurnsToLose[8]);
            ui.AppendGameStatsField(output);

            ui.AppendGameStatsField("");

            output = String.Format("Player 2: {0}:", playerTwoAgent.ToString());
            ui.AppendGameStatsField(output);

            output = String.Format("W - L - T: {0} - {1} - {2}", playerTwoStats.Wins, playerTwoStats.Losses, playerTwoStats.Ties);
            ui.AppendGameStatsField(output);

            output = String.Format("Turns needed for wins: [6]: {0}   [8]: {1}", playerTwoStats.NumberTurnsToWin[6], playerTwoStats.NumberTurnsToWin[8]);
            ui.AppendGameStatsField(output);

            output = String.Format("Turns needed for losses: [5]: {0}   [7]: {1}   [9]: {2}", playerTwoStats.NumberTurnsToLose[5], playerTwoStats.NumberTurnsToLose[7], playerTwoStats.NumberTurnsToLose[9]);
            ui.AppendGameStatsField(output);
        }

        private void OutputGameResults(String message)
        {
            ui.ResetGameStatsField();
            ui.AppendGameStatsField(message);
        }

        private void UnhookGameEventListener()
        {
            if (_game != null)
            {
                _game.NewInfo -= _game_NewInfo;
                _game.GameOver -= _game_GameOver;
                _game.TurnOver -= _game_TurnOver;
                _game = null;
            }
        }

        void _game_NewInfo(object sender, EventArgs e)
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

/*
        public UserControl snapInView(UserControl selectedView)
        {
            ;

            if (this.SwapablePane_Panel.Controls.Count > 0)
            {
                this.SwapablePane_Panel.Controls.RemoveAt(0);
            }

            selectedView.Dock = DockStyle.Fill;
            this.SwapablePane_Panel.Controls.Add(selectedView);
            
            return selectedView;
             
        }
*/