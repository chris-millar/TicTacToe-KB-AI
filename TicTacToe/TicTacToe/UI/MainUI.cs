﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToe.ExplicitDomainKnowledge;
using TicTacToe.UI;

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

        public event EventHandler TurnMenuItemSelected;
        private void onTurnMenuItemSelected(ListViewItem item)
        {
            if (TurnMenuItemSelected != null)
            {
                TurnMenuItemSelected(item, new EventArgs());
            }
        }

        public event EventHandler PerceptMenuItemSelected;
        private void onPerceptMenuItemSelected(ListViewItem item)
        {
            if (PerceptMenuItemSelected != null)
            {
                PerceptMenuItemSelected(item, new EventArgs());
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

        public void ResetGameStatsField()
        {
            GameStats_TextBox.Clear();
            GameStats_TextBox.Update();
        }

        public void AppendGameStatsField(String message)
        {
            AppendTextBoxLine(GameStats_TextBox, message);
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

        private void player2_label_Click(object sender, EventArgs e)
        {

        }

        public void ResetTurnListView()
        {
            Turn_ListView.Items.Clear();
        }

        public void AddTurnToListView(int turnNum, Player player)
        {   String[] subitems = {String.Format("Turn {0}", turnNum), player.name, player.getSymbol() };
            ListViewItem item = new ListViewItem(subitems);
            item.Tag = turnNum;
            Turn_ListView.Items.Add(item);
        }

        public void UpdateElements(TurnFrame frame)
        {
            UpdateTurnIdFields(frame);
            UpdateActualGameBoard(frame);
            UpdateAgentPercepts(frame, AgentPercepts.MyTerr);
            UpdateReasoningFields(frame);
        }

        public void UpdateTurnIdFields(TurnFrame frame)
        {
            fill_Turn_Label.Text = frame.TurnNumber.ToString();
            fill_Player_Label.Text = frame.player.name;
            fill_Agent_Label.Text = frame.player.getAgentType().Display;
            fill_Symbol_Label.Text = frame.player.getSymbol();
        }

        public void UpdateActualGameBoard(TurnFrame frame)
        {
            T3Board gameBoard = BuildGameBoard(frame);
            snapInView(gameBoard, ActualGameBoard_Panel);
        }

        public void UpdateAgentPercepts(TurnFrame frame, AgentPercepts perceptChoice)
        {
            T3Board perceptBoard = BuildPerceptBoard(frame, perceptChoice);
            snapInView(perceptBoard, AgentsPerception_Panel);
        }

        public void UpdateReasoningFields(TurnFrame frame)
        {
            fill_PositionChosen_Label.Text = frame.ClaimedTerritory.getPosition();
            fill_Why_Label.Text = MoveReasonings.ConvertReasoning(frame.ReasoningForMove);

            Reasoning_TextBox.Clear();
            for (int i = 0; i < frame.ReasoningForHowMoveReasonDetermined.Count; i++)
            {
                AppendTextBoxLine(Reasoning_TextBox, (String)frame.ReasoningForHowMoveReasonDetermined[i]);
            }
            
        }

        private T3Board BuildGameBoard(TurnFrame frame)
        {
            T3Board board = new T3Board();

            for (int i = 0; i < 9; i++)
            {
                ((Button)board.BoardButtons[i]).Text = ((Territory)frame.Board[i]).symbol;
            }

            int index = (int) frame.ClaimedTerritory.position;
            ((Button)(board.BoardButtons[index])).BackColor = System.Drawing.Color.DarkRed;

            return board;
        }

        private T3Board BuildPerceptBoard(TurnFrame frame, AgentPercepts percept)
        {
            T3Board board = new T3Board();

            if (percept == AgentPercepts.MyTerr)
            {
                for (int i = 0; i < frame.MyTerritories.Count; i++)
                {
                    int index = (int)frame.MyTerritories[i];
                    ((Button)board.BoardButtons[index]).Text = frame.player.symbol;
                    ((Button)board.BoardButtons[index]).BackColor = System.Drawing.Color.LawnGreen;
                }
            }
            else if (percept == AgentPercepts.OppTerr)
            {
                for (int i = 0; i < frame.OpponentsTerritories.Count; i++)
                {
                    int index = (int)frame.OpponentsTerritories[i];
                    ((Button)board.BoardButtons[index]).Text = frame.Opponent.symbol;
                    ((Button)board.BoardButtons[index]).BackColor = System.Drawing.Color.OrangeRed;
                }
            }
            else if (percept == AgentPercepts.AvailTerr)
            {
                for (int i = 0; i < frame.Avail.Count; i++)
                {
                    int index = (int)frame.Avail[i];
                    ((Button)board.BoardButtons[index]).Text = ".";
                    ((Button)board.BoardButtons[index]).BackColor = System.Drawing.Color.Plum;
                }
            }

            return board;
        }

        private void Turn_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Turn_ListView.SelectedItems.Count > 0)
            {
                ListViewItem item = Turn_ListView.SelectedItems[0];
                onTurnMenuItemSelected(item);
            }

        }

        public UserControl snapInView(UserControl selectedView, Panel swapPanel)
        {

            if (swapPanel.Controls.Count > 0)
            {
                swapPanel.Controls.RemoveAt(0);
            }

            selectedView.Dock = DockStyle.Fill;
            swapPanel.Controls.Add(selectedView);

            return selectedView;

        }

        private void Percept_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Percept_ListView.SelectedItems.Count > 0)
            {
                ListViewItem item = Percept_ListView.SelectedItems[0];
                onPerceptMenuItemSelected(item);
            }
        }
    }
}

/*
            this.player1_comboBox.Items.AddRange(new object[] {
                AgentTypes.Naive,
                AgentTypes.Smart });
*/

/*
            listViewItem1.Tag = AgentPercepts.MyTerr;
            listViewItem2.Tag = AgentPercepts.OppTerr;
            listViewItem3.Tag = AgentPercepts.AvailTerr;
            listViewItem4.Tag = AgentPercepts.WinSets;
            listViewItem5.Tag = AgentPercepts.FirstTurn;
            listViewItem6.Tag = AgentPercepts.CanWin;
            listViewItem7.Tag = AgentPercepts.CanBlock;
            listViewItem8.Tag = AgentPercepts.CanSetUpNextTurnWin;
            listViewItem9.Tag = AgentPercepts.NoGoodMove;
            listViewItem10.Tag = AgentPercepts.MyPPWS;
            listViewItem11.Tag = AgentPercepts.MyPWS;
            listViewItem12.Tag = AgentPercepts.OppPWs;
*/