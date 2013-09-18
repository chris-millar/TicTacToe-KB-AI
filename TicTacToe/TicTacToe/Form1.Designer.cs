namespace TicTacToe
{
    partial class Form1
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
            this.player1_label = new System.Windows.Forms.Label();
            this.player2_label = new System.Windows.Forms.Label();
            this.player1_comboBox = new System.Windows.Forms.ComboBox();
            this.player2_comboBox = new System.Windows.Forms.ComboBox();
            this.start_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.fakeConsole_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_label.Location = new System.Drawing.Point(33, 33);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(65, 16);
            this.player1_label.TabIndex = 0;
            this.player1_label.Text = "Player 1";
            // 
            // player2_label
            // 
            this.player2_label.AutoSize = true;
            this.player2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_label.Location = new System.Drawing.Point(193, 33);
            this.player2_label.Name = "player2_label";
            this.player2_label.Size = new System.Drawing.Size(65, 16);
            this.player2_label.TabIndex = 1;
            this.player2_label.Text = "Player 2";
            // 
            // player1_comboBox
            // 
            this.player1_comboBox.FormattingEnabled = true;
            this.player1_comboBox.Items.AddRange(new object[] {
            "Naive Agent",
            "Smart Agent"});
            this.player1_comboBox.Location = new System.Drawing.Point(36, 52);
            this.player1_comboBox.Name = "player1_comboBox";
            this.player1_comboBox.Size = new System.Drawing.Size(121, 21);
            this.player1_comboBox.TabIndex = 3;
            this.player1_comboBox.SelectedIndexChanged += new System.EventHandler(this.player1_comboBox_SelectedIndexChanged);
            // 
            // player2_comboBox
            // 
            this.player2_comboBox.FormattingEnabled = true;
            this.player2_comboBox.Items.AddRange(new object[] {
            "Naive Agent",
            "Smart Agent"});
            this.player2_comboBox.Location = new System.Drawing.Point(196, 52);
            this.player2_comboBox.Name = "player2_comboBox";
            this.player2_comboBox.Size = new System.Drawing.Size(121, 21);
            this.player2_comboBox.TabIndex = 4;
            this.player2_comboBox.SelectedIndexChanged += new System.EventHandler(this.player2_comboBox_SelectedIndexChanged);
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.Location = new System.Drawing.Point(92, 383);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(166, 29);
            this.start_button.TabIndex = 5;
            this.start_button.Text = "Start Game";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start_button);
            this.groupBox1.Controls.Add(this.player2_comboBox);
            this.groupBox1.Controls.Add(this.player2_label);
            this.groupBox1.Controls.Add(this.player1_comboBox);
            this.groupBox1.Controls.Add(this.player1_label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 418);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(810, 442);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 377;
            this.lineShape1.X2 = 377;
            this.lineShape1.Y1 = 20;
            this.lineShape1.Y2 = 428;
            // 
            // fakeConsole_textBox
            // 
            this.fakeConsole_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fakeConsole_textBox.Location = new System.Drawing.Point(389, 12);
            this.fakeConsole_textBox.Multiline = true;
            this.fakeConsole_textBox.Name = "fakeConsole_textBox";
            this.fakeConsole_textBox.ReadOnly = true;
            this.fakeConsole_textBox.Size = new System.Drawing.Size(409, 418);
            this.fakeConsole_textBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 442);
            this.Controls.Add(this.fakeConsole_textBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox fakeConsole_textBox;
    }
}

