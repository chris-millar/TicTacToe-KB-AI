using System;
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

        public event EventHandler CyclePerceptButtonPressed;
        private void onCyclePerceptButtonPressed(int value)
        {
            if (CyclePerceptButtonPressed != null)
            {
                CyclePerceptButtonPressed(value, new EventArgs());
            }
        }

        public int cyclePerceptSize;
        public int cyclePerceptValue;

        // COLOR DEFINITIONS //
        Color OwnColor = Color.LawnGreen;
        Color OppColor = Color.OrangeRed;
        Color AvailColor = Color.Plum;
        Color ClaimedTerritoryColor = Color.DarkRed;
        Color PickTerritoryColor = Color.DeepSkyBlue;
        Color WinSetColor = Color.Goldenrod;


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
            UpdateAgentPercepts(frame, AgentPercepts.MyTerr, true, true);
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

        public void UpdateAgentPercepts(TurnFrame frame, AgentPercepts perceptChoice, bool shouldUpdateMenu, bool shouldResetCycle)
        {
            if (shouldUpdateMenu)
            {
                UpdatePerceptsMenu(frame);
            }
            T3Board perceptBoard = BuildPerceptBoard(frame, perceptChoice, shouldResetCycle);
            snapInView(perceptBoard, AgentsPerception_Panel);
        }

        public void UpdateReasoningFields(TurnFrame frame)
        {
            fill_PositionChosen_Label.Text = frame.ClaimedTerritory.getPosition();
            fill_Why_Label.Text = EnumToStringConverter.ConvertReasoning(frame.ReasoningForMove);

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
                //((Button)board.BoardButtons[i]).Text = ((Territory)frame.Board[i]).symbol;
                ((Button)board.BoardButtons[i]).Text = ((Territory)frame.PostBoard[i]).symbol;
            }

            int index = (int) frame.ClaimedTerritory.position;
            ((Button)(board.BoardButtons[index])).BackColor = System.Drawing.Color.DarkRed;

            return board;
        }

        private T3Board BuildPerceptBoard(TurnFrame frame, AgentPercepts percept, bool canResetCycle)
        {
            T3Board board = new T3Board();

            if (percept == AgentPercepts.MyTerr)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.MyTerritories.Count; i++)
                {
                    int index = (int)frame.MyTerritories[i];
                    ((Button)board.BoardButtons[index]).Text = frame.player.symbol;
                    ((Button)board.BoardButtons[index]).BackColor = OwnColor;
                }
            }
            else if (percept == AgentPercepts.OppTerr)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.OpponentsTerritories.Count; i++)
                {
                    int index = (int)frame.OpponentsTerritories[i];
                    ((Button)board.BoardButtons[index]).Text = frame.Opponent.symbol;
                    ((Button)board.BoardButtons[index]).BackColor = OppColor;
                }
            }
            else if (percept == AgentPercepts.AvailTerr)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.Avail.Count; i++)
                {
                    int index = (int)frame.Avail[i];
                    ((Button)board.BoardButtons[index]).Text = ".";
                    ((Button)board.BoardButtons[index]).BackColor = AvailColor;
                }
            }
            else if (percept == AgentPercepts.WinSets)
            {
                if (canResetCycle) //magicCount == 0)
                {
                    //magicCount++;
                    CyclePercept_Button.Visible = true;
                    cyclePerceptSize = 8;
                    cyclePerceptValue = 0;
                }

                WinSet set = (WinSet)frame.WinSetDefinitions[cyclePerceptValue];

                for (int i = 0; i < 3; i++)
                {
                    int index = (int)set.list[i];
                    ((Button)board.BoardButtons[index]).Text = "";
                    ((Button)board.BoardButtons[index]).BackColor = WinSetColor;
                }

                //Console.WriteLine(String.Format("val: {0}",cyclePerceptValue));
                //Console.WriteLine(String.Format("max: {0}\n", cyclePerceptSize));
            }
            else if (percept == AgentPercepts.FirstTurn)
            {
                //TODO: 
                /* Once I implement weighting for each territory, this should show a color-gradient
                 * where the darkest spot has the heighest weight, then the next highest weight is a
                 * little lighter, and so on.
                 */
            }
            else if (percept == AgentPercepts.CanWin)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.WinSetImInterestedIn.Count; i++)
                {
                    int index = (int)frame.WinSetImInterestedIn[i];
                    TerritoryPositionState state = (TerritoryPositionState)frame.WhyImInterestedInThisWinSet[i];
                    if (state == TerritoryPositionState.Avail)
                    {
                        ((Button)board.BoardButtons[index]).Text = ".";
                        ((Button)board.BoardButtons[index]).BackColor = PickTerritoryColor;
                    }
                    else if (state == TerritoryPositionState.Own)
                    {
                        ((Button)board.BoardButtons[index]).Text = frame.player.symbol;
                        ((Button)board.BoardButtons[index]).BackColor = OwnColor;
                    }
                }
            }
            else if (percept == AgentPercepts.CanBlock)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.WinSetImInterestedIn.Count; i++)
                {
                    int index = (int)frame.WinSetImInterestedIn[i];
                    TerritoryPositionState state = (TerritoryPositionState)frame.WhyImInterestedInThisWinSet[i];
                    if (state == TerritoryPositionState.Avail)
                    {
                        ((Button)board.BoardButtons[index]).Text = ".";
                        ((Button)board.BoardButtons[index]).BackColor = PickTerritoryColor;
                    }
                    else if (state == TerritoryPositionState.OppOwn)
                    {
                        ((Button)board.BoardButtons[index]).Text = frame.Opponent.symbol;
                        ((Button)board.BoardButtons[index]).BackColor = OppColor;
                    }
                }
            }
            else if (percept == AgentPercepts.CanSetUpNextTurnWin)
            {
                CyclePercept_Button.Visible = false;

                for (int i = 0; i < frame.WinSetImInterestedIn.Count; i++)
                {
                    int index = (int)frame.WinSetImInterestedIn[i];
                    TerritoryPosition id = (TerritoryPosition)frame.WinSetImInterestedIn[i];
                    TerritoryPositionState state = (TerritoryPositionState)frame.WhyImInterestedInThisWinSet[i];
                    if (id == frame.ClaimedTerritory.position)
                    {
                        ((Button)board.BoardButtons[index]).Text = ".";
                        ((Button)board.BoardButtons[index]).BackColor = PickTerritoryColor;
                    }
                    else if (state == TerritoryPositionState.Avail)
                    {
                        ((Button)board.BoardButtons[index]).Text = ".";
                        ((Button)board.BoardButtons[index]).BackColor = AvailColor;
                    }
                    else if (state == TerritoryPositionState.Own)
                    {
                        ((Button)board.BoardButtons[index]).Text = frame.player.symbol;
                        ((Button)board.BoardButtons[index]).BackColor = OwnColor;
                    }
                }
            }
            else if (percept == AgentPercepts.NoGoodMove)
            {
                CyclePercept_Button.Visible = false;
            }
            else if (percept == AgentPercepts.MySingleSets)
            {
                if (canResetCycle)
                {
                    CyclePercept_Button.Visible = true;
                    if (frame.MySingleSets != null && frame.MySingleSets.Count > 0)
                    {
                        cyclePerceptSize = frame.MySingleSets.Count;
                        cyclePerceptValue = 0;
                    }
                }

                if (frame.MySingleSets != null && frame.MySingleSets.Count > 0)
                {
                    SingleSet set = (SingleSet)frame.MySingleSets[cyclePerceptValue];
                    
                    int OwnIndex = (int)set.PosIOwn;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.player.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OwnColor;

                    int AvailIndex = (int)set.PosAvailOne;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;

                    AvailIndex = (int)set.PosAvailTwo;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;
                }
            }
            else if (percept == AgentPercepts.MyDoubleSets)
            {
                if (canResetCycle)
                {
                    CyclePercept_Button.Visible = true;
                    if (frame.MyDoubleSets != null && frame.MyDoubleSets.Count > 0)
                    {
                        cyclePerceptSize = frame.MyDoubleSets.Count;
                        cyclePerceptValue = 0;
                    }
                }

                if (frame.MyDoubleSets != null && frame.MyDoubleSets.Count > 0)
                {
                    DoubleSet set = (DoubleSet)frame.MyDoubleSets[cyclePerceptValue];

                    int OwnIndex = (int)set.PosIOwnOne;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.player.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OwnColor;

                    OwnIndex = (int)set.PosIOwnTwo;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.player.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OwnColor;

                    int AvailIndex = (int)set.PosAvail;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;
                }

            }
            else if (percept == AgentPercepts.OppSingleSets)
            {
                if (canResetCycle)
                {
                    CyclePercept_Button.Visible = true;
                    if (frame.OppSingleSets != null && frame.OppSingleSets.Count > 0)
                    {
                        cyclePerceptSize = frame.OppSingleSets.Count;
                        cyclePerceptValue = 0;
                    }
                }

                if (frame.OppSingleSets != null && frame.OppSingleSets.Count > 0)
                {
                    SingleSet set = (SingleSet)frame.OppSingleSets[cyclePerceptValue];

                    int OwnIndex = (int)set.PosIOwn;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.Opponent.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OppColor;

                    int AvailIndex = (int)set.PosAvailOne;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;

                    AvailIndex = (int)set.PosAvailTwo;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;
                }

            }
            else if (percept == AgentPercepts.OppDoubleSets)
            {
                if (canResetCycle)
                {
                    CyclePercept_Button.Visible = true;
                    if (frame.OppDoubleSets != null && frame.OppDoubleSets.Count > 0)
                    {
                        cyclePerceptSize = frame.OppDoubleSets.Count;
                        cyclePerceptValue = 0;
                    }
                }

                if (frame.OppDoubleSets != null && frame.OppDoubleSets.Count > 0)
                {
                    DoubleSet set = (DoubleSet)frame.OppDoubleSets[cyclePerceptValue];

                    int OwnIndex = (int)set.PosIOwnOne;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.Opponent.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OppColor;

                    OwnIndex = (int)set.PosIOwnTwo;
                    ((Button)board.BoardButtons[OwnIndex]).Text = frame.Opponent.symbol;
                    ((Button)board.BoardButtons[OwnIndex]).BackColor = OppColor;

                    int AvailIndex = (int)set.PosAvail;
                    ((Button)board.BoardButtons[AvailIndex]).Text = ".";
                    ((Button)board.BoardButtons[AvailIndex]).BackColor = AvailColor;
                }

            }

            return board;
        }

        public int magicCount = 0;

        private void UpdatePerceptsMenu(TurnFrame frame)
        {
            if (Percept_ListView.Items.Count > 8)
            {
                Percept_ListView.Items.RemoveAt(8);
            }

            ListViewItem item;
            if (frame.ReasoningForMove == MoveReason.NULL)
                return;
            else if (frame.ReasoningForMove == MoveReason.NavieMove)
                return;
            else if (frame.ReasoningForMove == MoveReason.FirstTurn)
                item = FirstTurn_ListViewItem;
            else if (frame.ReasoningForMove == MoveReason.CanWin)
                item = CanWin_ListViewItem;
            else if (frame.ReasoningForMove == MoveReason.CanBlock)
                item = CanBlock_ListViewItem;
            else if (frame.ReasoningForMove == MoveReason.CanSetUpNextTurnWin)
                item = CanSetUpWin_ListViewItem;
            else //if (frame.ReasoningForMove == MoveReason.NoGoodMove)
                item = NoGoodMove_ListViewItem;

            Percept_ListView.Items.Add(item);
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

        private void CyclePercept_Button_Click(object sender, EventArgs e)
        {
            cyclePerceptValue = StepCircularValue(cyclePerceptValue, cyclePerceptSize);
            onCyclePerceptButtonPressed(cyclePerceptValue);
        }

        private int StepCircularValue(int val, int max)
        {
            if (max == 0)
            {
                return 0;
            }

            val++;
            if (val == max)
            {
                return 0;
            }
            else
            {
                return val;
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
        System.Windows.Forms.ListViewItem MyTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem OppTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem AvailTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem WinSets_ListViewItem;
        System.Windows.Forms.ListViewItem FirstTurn_ListViewItem;
        System.Windows.Forms.ListViewItem CanWin_ListViewItem;
        System.Windows.Forms.ListViewItem CanBlock_ListViewItem;
        System.Windows.Forms.ListViewItem CanSetUpWin_ListViewItem;
        System.Windows.Forms.ListViewItem NoGoodMove_ListViewItem;
        System.Windows.Forms.ListViewItem MySingleSets_ListViewItem;
        System.Windows.Forms.ListViewItem MyDoubleSets_ListViewItem;
        System.Windows.Forms.ListViewItem OppDoubleSets_ListViewItem;
        System.Windows.Forms.ListViewItem OppSingleSets_ListViewItem;
  
            MyTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("My Territories");
            OppTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("Opp Territories");
            AvailTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("Avail Territories");
            WinSets_ListViewItem = new System.Windows.Forms.ListViewItem("Win Sets");
            FirstTurn_ListViewItem = new System.Windows.Forms.ListViewItem("FirstTurn");
            CanWin_ListViewItem = new System.Windows.Forms.ListViewItem("CanWin");
            CanBlock_ListViewItem = new System.Windows.Forms.ListViewItem("CanBlock");
            CanSetUpWin_ListViewItem = new System.Windows.Forms.ListViewItem("CanSetUpWin");
            NoGoodMove_ListViewItem = new System.Windows.Forms.ListViewItem("NoGoodMove");
            MySingleSets_ListViewItem = new System.Windows.Forms.ListViewItem("My SingleSets");
            MyDoubleSets_ListViewItem = new System.Windows.Forms.ListViewItem("My DoubleSets");
            OppSingleSets_ListViewItem = new System.Windows.Forms.ListViewItem("Opp SingleSets");
            OppDoubleSets_ListViewItem = new System.Windows.Forms.ListViewItem("Opp DoubleSets");
            MyTerritory_ListViewItem.Tag = AgentPercepts.MyTerr;
            OppTerritory_ListViewItem.Tag = AgentPercepts.OppTerr;
            AvailTerritory_ListViewItem.Tag = AgentPercepts.AvailTerr;
            WinSets_ListViewItem.Tag = AgentPercepts.WinSets;
            FirstTurn_ListViewItem.Tag = AgentPercepts.FirstTurn;
            CanWin_ListViewItem.Tag = AgentPercepts.CanWin;
            CanBlock_ListViewItem.Tag = AgentPercepts.CanBlock;
            CanSetUpWin_ListViewItem.Tag = AgentPercepts.CanSetUpNextTurnWin;
            NoGoodMove_ListViewItem.Tag = AgentPercepts.NoGoodMove;
            MySingleSets_ListViewItem.Tag = AgentPercepts.MySingleSets;
            MyDoubleSets_ListViewItem.Tag = AgentPercepts.MyDoubleSets;
            OppSingleSets_ListViewItem.Tag = AgentPercepts.OppSingleSets;
            OppDoubleSets_ListViewItem.Tag = AgentPercepts.OppDoubleSets;
  
            this.Percept_ListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            MyTerritory_ListViewItem,
            OppTerritory_ListViewItem,
            AvailTerritory_ListViewItem,
            WinSets_ListViewItem,
            MySingleSets_ListViewItem,
            MyDoubleSets_ListViewItem,
            OppSingleSets_ListViewItem,
            OppDoubleSets_ListViewItem});
*/