namespace TicTacToe
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //System.Windows.Forms.ListViewItem
            MyTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("My Territories");
            OppTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("Opp Territories");
            AvailTerritory_ListViewItem = new System.Windows.Forms.ListViewItem("Avail Territories");
            WinSets_ListViewItem = new System.Windows.Forms.ListViewItem("Win Sets");
            FirstTurn_ListViewItem = new System.Windows.Forms.ListViewItem("FirstTurn");
            CanWin_ListViewItem = new System.Windows.Forms.ListViewItem("CanWin");
            CanBlock_ListViewItem = new System.Windows.Forms.ListViewItem("CanBlock");
            CanSetUpWin_ListViewItem = new System.Windows.Forms.ListViewItem("CanSetUpWin");
            NoGoodMove_ListViewItem = new System.Windows.Forms.ListViewItem("NoGoodMove");
            MyPPWS_ListViewItem = new System.Windows.Forms.ListViewItem("My PPWS");
            MyPWS_ListViewItem = new System.Windows.Forms.ListViewItem("My PWS");
            OppPWS_ListViewItem = new System.Windows.Forms.ListViewItem("Opp PWS");
            MyTerritory_ListViewItem.Tag = AgentPercepts.MyTerr;
            OppTerritory_ListViewItem.Tag = AgentPercepts.OppTerr;
            AvailTerritory_ListViewItem.Tag = AgentPercepts.AvailTerr;
            WinSets_ListViewItem.Tag = AgentPercepts.WinSets;
            FirstTurn_ListViewItem.Tag = AgentPercepts.FirstTurn;
            CanWin_ListViewItem.Tag = AgentPercepts.CanWin;
            CanBlock_ListViewItem.Tag = AgentPercepts.CanBlock;
            CanSetUpWin_ListViewItem.Tag = AgentPercepts.CanSetUpNextTurnWin;
            NoGoodMove_ListViewItem.Tag = AgentPercepts.NoGoodMove;
            MyPPWS_ListViewItem.Tag = AgentPercepts.MyPPWS;
            MyPWS_ListViewItem.Tag = AgentPercepts.MyPWS;
            OppPWS_ListViewItem.Tag = AgentPercepts.OppPWs;
            this.player1_label = new System.Windows.Forms.Label();
            this.player2_label = new System.Windows.Forms.Label();
            this.player1_comboBox = new System.Windows.Forms.ComboBox();
            this.player2_comboBox = new System.Windows.Forms.ComboBox();
            this.start_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HundredGames_RadioButton = new System.Windows.Forms.RadioButton();
            this.TenGames_RadioButton = new System.Windows.Forms.RadioButton();
            this.OneGame_RadioButton = new System.Windows.Forms.RadioButton();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.fakeConsole_textBox = new System.Windows.Forms.TextBox();
            this.ActualGameBoard_Panel = new System.Windows.Forms.Panel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.AgentsPerception_Panel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Percept_ListView = new System.Windows.Forms.ListView();
            this.Turn_ListView = new System.Windows.Forms.ListView();
            this.TurnNum_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Player_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerSymbol_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TurnID_Panel = new System.Windows.Forms.Panel();
            this.fill_Symbol_Label = new System.Windows.Forms.Label();
            this.fill_Agent_Label = new System.Windows.Forms.Label();
            this.fill_Player_Label = new System.Windows.Forms.Label();
            this.fill_Turn_Label = new System.Windows.Forms.Label();
            this.Symbol_Label = new System.Windows.Forms.Label();
            this.Agent_Label = new System.Windows.Forms.Label();
            this.Player_Label = new System.Windows.Forms.Label();
            this.Turn_label = new System.Windows.Forms.Label();
            this.Reasoning_Panel = new System.Windows.Forms.Panel();
            this.Reasoning_TextBox = new System.Windows.Forms.TextBox();
            this.Reasoning_Label = new System.Windows.Forms.Label();
            this.fill_Why_Label = new System.Windows.Forms.Label();
            this.Why_Label = new System.Windows.Forms.Label();
            this.fill_PositionChosen_Label = new System.Windows.Forms.Label();
            this.ClaimedPos_Label = new System.Windows.Forms.Label();
            this.Statistics_Panel = new System.Windows.Forms.Panel();
            this.GameStats_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TurnID_Panel.SuspendLayout();
            this.Reasoning_Panel.SuspendLayout();
            this.Statistics_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_label.Location = new System.Drawing.Point(9, 23);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(65, 16);
            this.player1_label.TabIndex = 0;
            this.player1_label.Text = "Player 1";
            // 
            // player2_label
            // 
            this.player2_label.AutoSize = true;
            this.player2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_label.Location = new System.Drawing.Point(9, 68);
            this.player2_label.Name = "player2_label";
            this.player2_label.Size = new System.Drawing.Size(65, 16);
            this.player2_label.TabIndex = 1;
            this.player2_label.Text = "Player 2";
            this.player2_label.Click += new System.EventHandler(this.player2_label_Click);
            // 
            // player1_comboBox
            // 
            this.player1_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_comboBox.FormattingEnabled = true;
            this.player1_comboBox.Items.AddRange(new object[] {
                AgentTypes.Naive,
                AgentTypes.Smart });
            this.player1_comboBox.Location = new System.Drawing.Point(12, 42);
            this.player1_comboBox.Name = "player1_comboBox";
            this.player1_comboBox.Size = new System.Drawing.Size(108, 23);
            this.player1_comboBox.TabIndex = 3;
            this.player1_comboBox.SelectedIndexChanged += new System.EventHandler(this.player1_comboBox_SelectedIndexChanged);
            // 
            // player2_comboBox
            // 
            this.player2_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_comboBox.FormattingEnabled = true;
            this.player2_comboBox.Items.AddRange(new object[] {
                AgentTypes.Naive,
                AgentTypes.Smart });
            this.player2_comboBox.Location = new System.Drawing.Point(12, 87);
            this.player2_comboBox.Name = "player2_comboBox";
            this.player2_comboBox.Size = new System.Drawing.Size(108, 23);
            this.player2_comboBox.TabIndex = 4;
            this.player2_comboBox.SelectedIndexChanged += new System.EventHandler(this.player2_comboBox_SelectedIndexChanged);
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.Location = new System.Drawing.Point(6, 202);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(118, 29);
            this.start_button.TabIndex = 5;
            this.start_button.Text = "Start Game";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HundredGames_RadioButton);
            this.groupBox1.Controls.Add(this.TenGames_RadioButton);
            this.groupBox1.Controls.Add(this.OneGame_RadioButton);
            this.groupBox1.Controls.Add(this.start_button);
            this.groupBox1.Controls.Add(this.player2_comboBox);
            this.groupBox1.Controls.Add(this.player2_label);
            this.groupBox1.Controls.Add(this.player1_comboBox);
            this.groupBox1.Controls.Add(this.player1_label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 237);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Play Options";
            // 
            // HundredGames_RadioButton
            // 
            this.HundredGames_RadioButton.AutoSize = true;
            this.HundredGames_RadioButton.Location = new System.Drawing.Point(12, 172);
            this.HundredGames_RadioButton.Name = "HundredGames_RadioButton";
            this.HundredGames_RadioButton.Size = new System.Drawing.Size(79, 17);
            this.HundredGames_RadioButton.TabIndex = 8;
            this.HundredGames_RadioButton.TabStop = true;
            this.HundredGames_RadioButton.Text = "100 Games";
            this.HundredGames_RadioButton.UseVisualStyleBackColor = true;
            this.HundredGames_RadioButton.CheckedChanged += new System.EventHandler(this.HundredGames_RadioButton_CheckedChanged);
            // 
            // TenGames_RadioButton
            // 
            this.TenGames_RadioButton.AutoSize = true;
            this.TenGames_RadioButton.Location = new System.Drawing.Point(12, 149);
            this.TenGames_RadioButton.Name = "TenGames_RadioButton";
            this.TenGames_RadioButton.Size = new System.Drawing.Size(73, 17);
            this.TenGames_RadioButton.TabIndex = 7;
            this.TenGames_RadioButton.TabStop = true;
            this.TenGames_RadioButton.Text = "10 Games";
            this.TenGames_RadioButton.UseVisualStyleBackColor = true;
            this.TenGames_RadioButton.CheckedChanged += new System.EventHandler(this.TenGames_RadioButton_CheckedChanged);
            // 
            // OneGame_RadioButton
            // 
            this.OneGame_RadioButton.AutoSize = true;
            this.OneGame_RadioButton.Location = new System.Drawing.Point(12, 126);
            this.OneGame_RadioButton.Name = "OneGame_RadioButton";
            this.OneGame_RadioButton.Size = new System.Drawing.Size(62, 17);
            this.OneGame_RadioButton.TabIndex = 6;
            this.OneGame_RadioButton.TabStop = true;
            this.OneGame_RadioButton.Text = "1 Game";
            this.OneGame_RadioButton.UseVisualStyleBackColor = true;
            this.OneGame_RadioButton.CheckedChanged += new System.EventHandler(this.OneGame_RadioButton_CheckedChanged);
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 150;
            this.lineShape1.X2 = 150;
            this.lineShape1.Y1 = 18;
            this.lineShape1.Y2 = 489;
            // 
            // fakeConsole_textBox
            // 
            this.fakeConsole_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fakeConsole_textBox.Location = new System.Drawing.Point(12, 514);
            this.fakeConsole_textBox.Multiline = true;
            this.fakeConsole_textBox.Name = "fakeConsole_textBox";
            this.fakeConsole_textBox.ReadOnly = true;
            this.fakeConsole_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fakeConsole_textBox.Size = new System.Drawing.Size(409, 418);
            this.fakeConsole_textBox.TabIndex = 8;
            // 
            // ActualGameBoard_Panel
            // 
            this.ActualGameBoard_Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ActualGameBoard_Panel.Location = new System.Drawing.Point(6, 14);
            this.ActualGameBoard_Panel.Name = "ActualGameBoard_Panel";
            this.ActualGameBoard_Panel.Size = new System.Drawing.Size(227, 217);
            this.ActualGameBoard_Panel.TabIndex = 9;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1064, 562);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // AgentsPerception_Panel
            // 
            this.AgentsPerception_Panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AgentsPerception_Panel.Location = new System.Drawing.Point(6, 14);
            this.AgentsPerception_Panel.Name = "AgentsPerception_Panel";
            this.AgentsPerception_Panel.Size = new System.Drawing.Size(227, 217);
            this.AgentsPerception_Panel.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ActualGameBoard_Panel);
            this.groupBox2.Location = new System.Drawing.Point(160, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 237);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actual GameBoard";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AgentsPerception_Panel);
            this.groupBox3.Location = new System.Drawing.Point(160, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 237);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agent\'s Perception";
            // 
            // Percept_ListView
            // 
            this.Percept_ListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percept_ListView.FullRowSelect = true;
            this.Percept_ListView.GridLines = true;
            this.Percept_ListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            MyTerritory_ListViewItem,
            OppTerritory_ListViewItem,
            AvailTerritory_ListViewItem,
            WinSets_ListViewItem,
            MyPPWS_ListViewItem,
            MyPWS_ListViewItem,
            OppPWS_ListViewItem});
            this.Percept_ListView.LabelWrap = false;
            this.Percept_ListView.Location = new System.Drawing.Point(12, 255);
            this.Percept_ListView.MultiSelect = false;
            this.Percept_ListView.Name = "Percept_ListView";
            this.Percept_ListView.Scrollable = false;
            this.Percept_ListView.Size = new System.Drawing.Size(131, 235);
            this.Percept_ListView.TabIndex = 13;
            this.Percept_ListView.UseCompatibleStateImageBehavior = false;
            this.Percept_ListView.View = System.Windows.Forms.View.List;
            this.Percept_ListView.SelectedIndexChanged += new System.EventHandler(this.Percept_ListView_SelectedIndexChanged);
            // 
            // Turn_ListView
            // 
            this.Turn_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TurnNum_ColumnHeader,
            this.Player_ColumnHeader,
            this.PlayerSymbol_ColumnHeader});
            this.Turn_ListView.FullRowSelect = true;
            this.Turn_ListView.Location = new System.Drawing.Point(858, 18);
            this.Turn_ListView.MultiSelect = false;
            this.Turn_ListView.Name = "Turn_ListView";
            this.Turn_ListView.Size = new System.Drawing.Size(194, 474);
            this.Turn_ListView.TabIndex = 14;
            this.Turn_ListView.UseCompatibleStateImageBehavior = false;
            this.Turn_ListView.View = System.Windows.Forms.View.Details;
            this.Turn_ListView.SelectedIndexChanged += new System.EventHandler(this.Turn_ListView_SelectedIndexChanged);
            // 
            // TurnNum_ColumnHeader
            // 
            this.TurnNum_ColumnHeader.Text = "Turn #";
            this.TurnNum_ColumnHeader.Width = 52;
            // 
            // Player_ColumnHeader
            // 
            this.Player_ColumnHeader.Text = "Player Name";
            this.Player_ColumnHeader.Width = 74;
            // 
            // PlayerSymbol_ColumnHeader
            // 
            this.PlayerSymbol_ColumnHeader.Text = "Symbol";
            // 
            // TurnID_Panel
            // 
            this.TurnID_Panel.BackColor = System.Drawing.Color.Bisque;
            this.TurnID_Panel.Controls.Add(this.fill_Symbol_Label);
            this.TurnID_Panel.Controls.Add(this.fill_Agent_Label);
            this.TurnID_Panel.Controls.Add(this.fill_Player_Label);
            this.TurnID_Panel.Controls.Add(this.fill_Turn_Label);
            this.TurnID_Panel.Controls.Add(this.Symbol_Label);
            this.TurnID_Panel.Controls.Add(this.Agent_Label);
            this.TurnID_Panel.Controls.Add(this.Player_Label);
            this.TurnID_Panel.Controls.Add(this.Turn_label);
            this.TurnID_Panel.Location = new System.Drawing.Point(405, 18);
            this.TurnID_Panel.Name = "TurnID_Panel";
            this.TurnID_Panel.Size = new System.Drawing.Size(447, 78);
            this.TurnID_Panel.TabIndex = 15;
            // 
            // fill_Symbol_Label
            // 
            this.fill_Symbol_Label.AutoSize = true;
            this.fill_Symbol_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_Symbol_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_Symbol_Label.Location = new System.Drawing.Point(271, 53);
            this.fill_Symbol_Label.Name = "fill_Symbol_Label";
            this.fill_Symbol_Label.Size = new System.Drawing.Size(19, 15);
            this.fill_Symbol_Label.TabIndex = 7;
            this.fill_Symbol_Label.Text = "...";
            // 
            // fill_Agent_Label
            // 
            this.fill_Agent_Label.AutoSize = true;
            this.fill_Agent_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_Agent_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_Agent_Label.Location = new System.Drawing.Point(271, 39);
            this.fill_Agent_Label.Name = "fill_Agent_Label";
            this.fill_Agent_Label.Size = new System.Drawing.Size(19, 15);
            this.fill_Agent_Label.TabIndex = 6;
            this.fill_Agent_Label.Text = "...";
            // 
            // fill_Player_Label
            // 
            this.fill_Player_Label.AutoSize = true;
            this.fill_Player_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_Player_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_Player_Label.Location = new System.Drawing.Point(272, 18);
            this.fill_Player_Label.Name = "fill_Player_Label";
            this.fill_Player_Label.Size = new System.Drawing.Size(24, 20);
            this.fill_Player_Label.TabIndex = 5;
            this.fill_Player_Label.Text = "...";
            // 
            // fill_Turn_Label
            // 
            this.fill_Turn_Label.AutoSize = true;
            this.fill_Turn_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_Turn_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_Turn_Label.Location = new System.Drawing.Point(76, 27);
            this.fill_Turn_Label.Name = "fill_Turn_Label";
            this.fill_Turn_Label.Size = new System.Drawing.Size(33, 25);
            this.fill_Turn_Label.TabIndex = 4;
            this.fill_Turn_Label.Text = "...";
            // 
            // Symbol_Label
            // 
            this.Symbol_Label.AutoSize = true;
            this.Symbol_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Symbol_Label.Location = new System.Drawing.Point(207, 53);
            this.Symbol_Label.Name = "Symbol_Label";
            this.Symbol_Label.Size = new System.Drawing.Size(58, 15);
            this.Symbol_Label.TabIndex = 3;
            this.Symbol_Label.Text = "Symbol:";
            // 
            // Agent_Label
            // 
            this.Agent_Label.AutoSize = true;
            this.Agent_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agent_Label.Location = new System.Drawing.Point(218, 38);
            this.Agent_Label.Name = "Agent_Label";
            this.Agent_Label.Size = new System.Drawing.Size(47, 15);
            this.Agent_Label.TabIndex = 2;
            this.Agent_Label.Text = "Agent:";
            // 
            // Player_Label
            // 
            this.Player_Label.AutoSize = true;
            this.Player_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player_Label.Location = new System.Drawing.Point(203, 18);
            this.Player_Label.Name = "Player_Label";
            this.Player_Label.Size = new System.Drawing.Size(63, 20);
            this.Player_Label.TabIndex = 1;
            this.Player_Label.Text = "Player:";
            // 
            // Turn_label
            // 
            this.Turn_label.AutoSize = true;
            this.Turn_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turn_label.Location = new System.Drawing.Point(3, 27);
            this.Turn_label.Name = "Turn_label";
            this.Turn_label.Size = new System.Drawing.Size(80, 25);
            this.Turn_label.TabIndex = 0;
            this.Turn_label.Text = "Turn #";
            // 
            // Reasoning_Panel
            // 
            this.Reasoning_Panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Reasoning_Panel.Controls.Add(this.Reasoning_TextBox);
            this.Reasoning_Panel.Controls.Add(this.Reasoning_Label);
            this.Reasoning_Panel.Controls.Add(this.fill_Why_Label);
            this.Reasoning_Panel.Controls.Add(this.Why_Label);
            this.Reasoning_Panel.Controls.Add(this.fill_PositionChosen_Label);
            this.Reasoning_Panel.Controls.Add(this.ClaimedPos_Label);
            this.Reasoning_Panel.Location = new System.Drawing.Point(405, 102);
            this.Reasoning_Panel.Name = "Reasoning_Panel";
            this.Reasoning_Panel.Size = new System.Drawing.Size(447, 244);
            this.Reasoning_Panel.TabIndex = 16;
            // 
            // Reasoning_TextBox
            // 
            this.Reasoning_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reasoning_TextBox.ForeColor = System.Drawing.Color.DarkRed;
            this.Reasoning_TextBox.Location = new System.Drawing.Point(3, 120);
            this.Reasoning_TextBox.Multiline = true;
            this.Reasoning_TextBox.Name = "Reasoning_TextBox";
            this.Reasoning_TextBox.ReadOnly = true;
            this.Reasoning_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Reasoning_TextBox.Size = new System.Drawing.Size(441, 121);
            this.Reasoning_TextBox.TabIndex = 13;
            // 
            // Reasoning_Label
            // 
            this.Reasoning_Label.AutoSize = true;
            this.Reasoning_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reasoning_Label.Location = new System.Drawing.Point(4, 93);
            this.Reasoning_Label.Name = "Reasoning_Label";
            this.Reasoning_Label.Size = new System.Drawing.Size(308, 20);
            this.Reasoning_Label.TabIndex = 12;
            this.Reasoning_Label.Text = "How was this reasoning determined?:";
            // 
            // fill_Why_Label
            // 
            this.fill_Why_Label.AutoSize = true;
            this.fill_Why_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_Why_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_Why_Label.Location = new System.Drawing.Point(171, 56);
            this.fill_Why_Label.Name = "fill_Why_Label";
            this.fill_Why_Label.Size = new System.Drawing.Size(24, 20);
            this.fill_Why_Label.TabIndex = 11;
            this.fill_Why_Label.Text = "...";
            // 
            // Why_Label
            // 
            this.Why_Label.AutoSize = true;
            this.Why_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Why_Label.Location = new System.Drawing.Point(4, 56);
            this.Why_Label.Name = "Why_Label";
            this.Why_Label.Size = new System.Drawing.Size(161, 20);
            this.Why_Label.TabIndex = 10;
            this.Why_Label.Text = "Why this Position?:";
            // 
            // fill_PositionChosen_Label
            // 
            this.fill_PositionChosen_Label.AutoSize = true;
            this.fill_PositionChosen_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fill_PositionChosen_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.fill_PositionChosen_Label.Location = new System.Drawing.Point(154, 9);
            this.fill_PositionChosen_Label.Name = "fill_PositionChosen_Label";
            this.fill_PositionChosen_Label.Size = new System.Drawing.Size(24, 20);
            this.fill_PositionChosen_Label.TabIndex = 9;
            this.fill_PositionChosen_Label.Text = "...";
            // 
            // ClaimedPos_Label
            // 
            this.ClaimedPos_Label.AutoSize = true;
            this.ClaimedPos_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClaimedPos_Label.Location = new System.Drawing.Point(4, 9);
            this.ClaimedPos_Label.Name = "ClaimedPos_Label";
            this.ClaimedPos_Label.Size = new System.Drawing.Size(144, 20);
            this.ClaimedPos_Label.TabIndex = 8;
            this.ClaimedPos_Label.Text = "Position Chosen:";
            // 
            // Statistics_Panel
            // 
            this.Statistics_Panel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Statistics_Panel.Controls.Add(this.GameStats_TextBox);
            this.Statistics_Panel.Location = new System.Drawing.Point(405, 349);
            this.Statistics_Panel.Name = "Statistics_Panel";
            this.Statistics_Panel.Size = new System.Drawing.Size(447, 143);
            this.Statistics_Panel.TabIndex = 17;
            // 
            // GameStats_TextBox
            // 
            this.GameStats_TextBox.BackColor = System.Drawing.SystemColors.Info;
            this.GameStats_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameStats_TextBox.Location = new System.Drawing.Point(3, 3);
            this.GameStats_TextBox.Multiline = true;
            this.GameStats_TextBox.Name = "GameStats_TextBox";
            this.GameStats_TextBox.ReadOnly = true;
            this.GameStats_TextBox.Size = new System.Drawing.Size(441, 137);
            this.GameStats_TextBox.TabIndex = 0;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 562);
            this.Controls.Add(this.Statistics_Panel);
            this.Controls.Add(this.Reasoning_Panel);
            this.Controls.Add(this.TurnID_Panel);
            this.Controls.Add(this.Turn_ListView);
            this.Controls.Add(this.Percept_ListView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.fakeConsole_textBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "MainUI";
            this.Text = "Tic-Tac-Toe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.TurnID_Panel.ResumeLayout(false);
            this.TurnID_Panel.PerformLayout();
            this.Reasoning_Panel.ResumeLayout(false);
            this.Reasoning_Panel.PerformLayout();
            this.Statistics_Panel.ResumeLayout(false);
            this.Statistics_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.Label player2_label;
        private System.Windows.Forms.ComboBox player1_comboBox;
        private System.Windows.Forms.ComboBox player2_comboBox;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox fakeConsole_textBox;
        private System.Windows.Forms.RadioButton HundredGames_RadioButton;
        private System.Windows.Forms.RadioButton TenGames_RadioButton;
        private System.Windows.Forms.RadioButton OneGame_RadioButton;
        private System.Windows.Forms.Panel ActualGameBoard_Panel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Panel AgentsPerception_Panel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView Percept_ListView;
        private System.Windows.Forms.ListView Turn_ListView;
        private System.Windows.Forms.ColumnHeader TurnNum_ColumnHeader;
        private System.Windows.Forms.ColumnHeader Player_ColumnHeader;
        private System.Windows.Forms.ColumnHeader PlayerSymbol_ColumnHeader;
        private System.Windows.Forms.Panel TurnID_Panel;
        private System.Windows.Forms.Label fill_Symbol_Label;
        private System.Windows.Forms.Label fill_Agent_Label;
        private System.Windows.Forms.Label fill_Player_Label;
        private System.Windows.Forms.Label fill_Turn_Label;
        private System.Windows.Forms.Label Symbol_Label;
        private System.Windows.Forms.Label Agent_Label;
        private System.Windows.Forms.Label Player_Label;
        private System.Windows.Forms.Label Turn_label;
        private System.Windows.Forms.Panel Reasoning_Panel;
        private System.Windows.Forms.TextBox Reasoning_TextBox;
        private System.Windows.Forms.Label Reasoning_Label;
        private System.Windows.Forms.Label fill_Why_Label;
        private System.Windows.Forms.Label Why_Label;
        private System.Windows.Forms.Label fill_PositionChosen_Label;
        private System.Windows.Forms.Label ClaimedPos_Label;
        private System.Windows.Forms.Panel Statistics_Panel;
        private System.Windows.Forms.TextBox GameStats_TextBox;

        System.Windows.Forms.ListViewItem MyTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem OppTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem AvailTerritory_ListViewItem;
        System.Windows.Forms.ListViewItem WinSets_ListViewItem;
        System.Windows.Forms.ListViewItem FirstTurn_ListViewItem;
        System.Windows.Forms.ListViewItem CanWin_ListViewItem;
        System.Windows.Forms.ListViewItem CanBlock_ListViewItem;
        System.Windows.Forms.ListViewItem CanSetUpWin_ListViewItem;
        System.Windows.Forms.ListViewItem NoGoodMove_ListViewItem;
        System.Windows.Forms.ListViewItem MyPPWS_ListViewItem;
        System.Windows.Forms.ListViewItem MyPWS_ListViewItem;
        System.Windows.Forms.ListViewItem OppPWS_ListViewItem;
    }
}

