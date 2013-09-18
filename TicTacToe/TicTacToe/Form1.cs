using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Agent playerOneAgent;
        Agent playerTwoAgent;
        TicTacToeGame game;


        public Form1()
        {
            InitializeComponent();
            player1_comboBox.SelectedIndex = 0;
            player2_comboBox.SelectedIndex = 0;
        }

        private void player1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;

            //String message = String.Format("It's Player 1 : {0}", box.SelectedItem.ToString());
            //Console.WriteLine(message);

            if (box.SelectedItem.ToString().Equals("Naive Agent"))
            {
                playerOneAgent = new NaiveTicTacToeAgent();
            }
            else if (box.SelectedItem.ToString().Equals("Smart Agent"))
            {
                playerOneAgent = new SmartTicTacToeAgent();
            }
            else
            {
                //Console.WriteLine("Error: Player 1 unable to pick Agent");
            }
        }

        private void player2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;

            //String message = String.Format("It's Player 2 : {0}", box.SelectedItem.ToString());
            //Console.WriteLine(message);

            if (box.SelectedItem.ToString().Equals("Naive Agent"))
            {
                playerTwoAgent = new NaiveTicTacToeAgent();
            }
            else if (box.SelectedItem.ToString().Equals("Smart Agent"))
            {
                playerTwoAgent = new SmartTicTacToeAgent();
            }
            else
            {
                //Console.WriteLine("Error: Player 2 unable to pick Agent");
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {


            if (playerOneAgent != null && playerTwoAgent != null)
            {
                /*
                String messageOne = String.Format("Player 1 Agent: {0}", playerOneAgent.ToString());
                String messageTwo = String.Format("Player 2 Agent: {0}", playerTwoAgent.ToString());
                Console.WriteLine(messageOne);
                Console.WriteLine(messageTwo);
                */

                game = new TicTacToeGame(playerOneAgent, playerTwoAgent);
                game.NewInfo += new EventHandler(game_NewInfo);
                game.TurnOver += new EventHandler(game_TurnOver);

                fakeConsole_textBox.Clear();
                fakeConsole_textBox.Update();

                game.start();
            }
            else
            {
                if (playerOneAgent == null)
                {
                    //Console.WriteLine("Player 1 is NULL");
                }

                if (playerTwoAgent == null)
                {
                    //Console.WriteLine("Player 2 is NULL");
                }
            }
        }

        void game_TurnOver(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void game_NewInfo(object sender, EventArgs e)
        {
            String message = sender as String;

            //fakeConsole_textBox.AppendText(message);
            AppendTextBoxLine(fakeConsole_textBox, message);
        }

        private void AppendTextBoxLine(TextBox box, String str)
        {
            if (box.Text.Length > 0)
            {
                box.AppendText(Environment.NewLine);
            }
            box.AppendText(str);
        }


    }
}
