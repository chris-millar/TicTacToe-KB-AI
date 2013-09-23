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
    public partial class MainUI : Form
    {
        //Singleton
        private static MainUI instance = null;
        public static MainUI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainUI();
                }
                return instance;
            }
        }

        public event EventHandler AgentOneSelection;
        public event EventHandler AgentTwoSelection;
        private void onAgentSelection(EventHandler whoToSendTo, AgentType selected)
        {
            if (whoToSendTo != null)
            {
                whoToSendTo(selected, new EventArgs());
            }
        }

        public event EventHandler StartButtonPressed;
        private void onStartButtonPressed()
        {
            if (StartButtonPressed != null)
            {
                StartButtonPressed(this, new EventArgs());
            }
        }

        public event EventHandler RadioButtonPressed;
        private void onRadioButtonPressed(int numGamesToPlay)
        {
            if (RadioButtonPressed != null)
            {
                RadioButtonPressed(numGamesToPlay, new EventArgs());
            }
        }

        public MainUI()
        {
            InitializeComponent();
            player1_comboBox.SelectedIndex = 0;
            player2_comboBox.SelectedIndex = 0;
        }

        public void InitSelections()
        {
            player1_comboBox.SelectedIndex = 1;
            player2_comboBox.SelectedIndex = 1;
        }

        private void player1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            onAgentSelection(AgentOneSelection, box.SelectedItem as AgentType);
        }

        private void player2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            onAgentSelection(AgentTwoSelection,  box.SelectedItem as AgentType);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            onStartButtonPressed();
        }

        public void ResetFauxConsole()
        {
            fakeConsole_textBox.Clear();
            fakeConsole_textBox.Update();
        }

        public void AppendFauxConsole(String message)
        {
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

        private void OneGame_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            onRadioButtonPressed(1);
        }

        private void TenGames_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            onRadioButtonPressed(10);
        }

        private void HundredGames_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            onRadioButtonPressed(100);
        }
    }
}

/*
            this.player1_comboBox.Items.AddRange(new object[] {
                AgentTypes.Naive,
                AgentTypes.Smart });
*/