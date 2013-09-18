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
        public TicTacToeGame game;

        public AppManager()
        {
            ui = new MainUI();
            ui.AgentOneSelection += new EventHandler(ui_AgentOneSelection);
            ui.AgentTwoSelection += new EventHandler(ui_AgentTwoSelection);
            ui.StartButtonPressed += new EventHandler(ui_StartButtonPressed);
            ui.InitSelections();
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
            if (game == null || game.canStartNewGame())
            {
                game = new TicTacToeGame(playerOneAgent, playerTwoAgent);
                game.NewInfo += new EventHandler(game_NewInfo);

                ui.ResetFauxConsole();

                game.start();
            }
        }

        void game_NewInfo(object sender, EventArgs e)
        {
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
