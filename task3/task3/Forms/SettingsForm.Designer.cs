namespace task3
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            groupBox1 = new GroupBox();
            checkBoxForceJumpPvP = new CheckBox();
            checkBoxShowMovesPvP = new CheckBox();
            comboBoxFirstMovePvP = new ComboBox();
            label4 = new Label();
            comboBoxBoardSizePvP = new ComboBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            textBoxPlayer2PvP = new TextBox();
            textBoxPlayer1PvP = new TextBox();
            label2 = new Label();
            label1 = new Label();
            buttonStartGamePvP = new Button();
            tabControlSetting = new TabControl();
            tabPagePvP = new TabPage();
            tabPagePvE = new TabPage();
            groupBox3 = new GroupBox();
            checkBoxForceJumpPvE = new CheckBox();
            checkBoxShowMovesPvE = new CheckBox();
            comboBoxFirstMovePvE = new ComboBox();
            label5 = new Label();
            comboBoxBoardSizePvE = new ComboBox();
            label6 = new Label();
            groupBox4 = new GroupBox();
            textBoxPlayer1PvE = new TextBox();
            label8 = new Label();
            buttonStartGamePvE = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControlSetting.SuspendLayout();
            tabPagePvP.SuspendLayout();
            tabPagePvE.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxForceJumpPvP);
            groupBox1.Controls.Add(checkBoxShowMovesPvP);
            groupBox1.Controls.Add(comboBoxFirstMovePvP);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxBoardSizePvP);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(208, 187);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game Settings";
            // 
            // checkBoxForceJumpPvP
            // 
            checkBoxForceJumpPvP.AutoSize = true;
            checkBoxForceJumpPvP.Location = new Point(7, 144);
            checkBoxForceJumpPvP.Name = "checkBoxForceJumpPvP";
            checkBoxForceJumpPvP.Size = new Size(87, 19);
            checkBoxForceJumpPvP.TabIndex = 5;
            checkBoxForceJumpPvP.Text = "Force Jump";
            checkBoxForceJumpPvP.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowMovesPvP
            // 
            checkBoxShowMovesPvP.AutoSize = true;
            checkBoxShowMovesPvP.Checked = true;
            checkBoxShowMovesPvP.CheckState = CheckState.Checked;
            checkBoxShowMovesPvP.Location = new Point(7, 119);
            checkBoxShowMovesPvP.Name = "checkBoxShowMovesPvP";
            checkBoxShowMovesPvP.Size = new Size(93, 19);
            checkBoxShowMovesPvP.TabIndex = 4;
            checkBoxShowMovesPvP.Text = "Show moves";
            checkBoxShowMovesPvP.UseVisualStyleBackColor = true;
            // 
            // comboBoxFirstMovePvP
            // 
            comboBoxFirstMovePvP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFirstMovePvP.FormattingEnabled = true;
            comboBoxFirstMovePvP.Items.AddRange(new object[] { "Player 1", "Player 2" });
            comboBoxFirstMovePvP.Location = new Point(7, 90);
            comboBoxFirstMovePvP.Name = "comboBoxFirstMovePvP";
            comboBoxFirstMovePvP.Size = new Size(121, 23);
            comboBoxFirstMovePvP.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 72);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 2;
            label4.Text = "First Move:";
            // 
            // comboBoxBoardSizePvP
            // 
            comboBoxBoardSizePvP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBoardSizePvP.FormattingEnabled = true;
            comboBoxBoardSizePvP.Items.AddRange(new object[] { "8x8" });
            comboBoxBoardSizePvP.Location = new Point(7, 37);
            comboBoxBoardSizePvP.MaxDropDownItems = 3;
            comboBoxBoardSizePvP.Name = "comboBoxBoardSizePvP";
            comboBoxBoardSizePvP.Size = new Size(121, 23);
            comboBoxBoardSizePvP.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 19);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 0;
            label3.Text = "Board Size:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxPlayer2PvP);
            groupBox2.Controls.Add(textBoxPlayer1PvP);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(221, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(208, 187);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Players Settings";
            // 
            // textBoxPlayer2PvP
            // 
            textBoxPlayer2PvP.Location = new Point(6, 107);
            textBoxPlayer2PvP.Name = "textBoxPlayer2PvP";
            textBoxPlayer2PvP.Size = new Size(133, 23);
            textBoxPlayer2PvP.TabIndex = 4;
            textBoxPlayer2PvP.Text = "Player 2";
            // 
            // textBoxPlayer1PvP
            // 
            textBoxPlayer1PvP.ForeColor = SystemColors.MenuText;
            textBoxPlayer1PvP.Location = new Point(6, 49);
            textBoxPlayer1PvP.Name = "textBoxPlayer1PvP";
            textBoxPlayer1PvP.Size = new Size(133, 23);
            textBoxPlayer1PvP.TabIndex = 3;
            textBoxPlayer1PvP.Text = "Player 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Player 2 Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "Player 1 Name:";
            // 
            // buttonStartGamePvP
            // 
            buttonStartGamePvP.Location = new Point(181, 235);
            buttonStartGamePvP.Name = "buttonStartGamePvP";
            buttonStartGamePvP.Size = new Size(74, 31);
            buttonStartGamePvP.TabIndex = 4;
            buttonStartGamePvP.Text = "Start";
            buttonStartGamePvP.UseVisualStyleBackColor = true;
            buttonStartGamePvP.Click += ButtonStartPvP;
            // 
            // tabControlSetting
            // 
            tabControlSetting.Controls.Add(tabPagePvP);
            tabControlSetting.Controls.Add(tabPagePvE);
            tabControlSetting.Location = new Point(1, 1);
            tabControlSetting.Name = "tabControlSetting";
            tabControlSetting.SelectedIndex = 0;
            tabControlSetting.Size = new Size(445, 308);
            tabControlSetting.TabIndex = 6;
            // 
            // tabPagePvP
            // 
            tabPagePvP.Controls.Add(groupBox1);
            tabPagePvP.Controls.Add(groupBox2);
            tabPagePvP.Controls.Add(buttonStartGamePvP);
            tabPagePvP.Location = new Point(4, 24);
            tabPagePvP.Name = "tabPagePvP";
            tabPagePvP.Padding = new Padding(3);
            tabPagePvP.Size = new Size(437, 280);
            tabPagePvP.TabIndex = 1;
            tabPagePvP.Text = "Player vs Player";
            // 
            // tabPagePvE
            // 
            tabPagePvE.Controls.Add(groupBox3);
            tabPagePvE.Controls.Add(groupBox4);
            tabPagePvE.Controls.Add(buttonStartGamePvE);
            tabPagePvE.Location = new Point(4, 24);
            tabPagePvE.Name = "tabPagePvE";
            tabPagePvE.Size = new Size(437, 280);
            tabPagePvE.TabIndex = 2;
            tabPagePvE.Text = "Player vs Computer";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBoxForceJumpPvE);
            groupBox3.Controls.Add(checkBoxShowMovesPvE);
            groupBox3.Controls.Add(comboBoxFirstMovePvE);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(comboBoxBoardSizePvE);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(7, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(208, 187);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Game Settings";
            // 
            // checkBoxForceJumpPvE
            // 
            checkBoxForceJumpPvE.AutoSize = true;
            checkBoxForceJumpPvE.Checked = true;
            checkBoxForceJumpPvE.CheckState = CheckState.Checked;
            checkBoxForceJumpPvE.Location = new Point(7, 144);
            checkBoxForceJumpPvE.Name = "checkBoxForceJumpPvE";
            checkBoxForceJumpPvE.Size = new Size(87, 19);
            checkBoxForceJumpPvE.TabIndex = 6;
            checkBoxForceJumpPvE.Text = "Force Jump";
            checkBoxForceJumpPvE.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowMovesPvE
            // 
            checkBoxShowMovesPvE.AutoSize = true;
            checkBoxShowMovesPvE.Checked = true;
            checkBoxShowMovesPvE.CheckState = CheckState.Checked;
            checkBoxShowMovesPvE.Location = new Point(7, 119);
            checkBoxShowMovesPvE.Name = "checkBoxShowMovesPvE";
            checkBoxShowMovesPvE.Size = new Size(93, 19);
            checkBoxShowMovesPvE.TabIndex = 4;
            checkBoxShowMovesPvE.Text = "Show moves";
            checkBoxShowMovesPvE.UseVisualStyleBackColor = true;
            // 
            // comboBoxFirstMovePvE
            // 
            comboBoxFirstMovePvE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFirstMovePvE.FormattingEnabled = true;
            comboBoxFirstMovePvE.Items.AddRange(new object[] { "Player", "Computer" });
            comboBoxFirstMovePvE.Location = new Point(7, 90);
            comboBoxFirstMovePvE.Name = "comboBoxFirstMovePvE";
            comboBoxFirstMovePvE.Size = new Size(121, 23);
            comboBoxFirstMovePvE.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 72);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 2;
            label5.Text = "First Move:";
            // 
            // comboBoxBoardSizePvE
            // 
            comboBoxBoardSizePvE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBoardSizePvE.FormattingEnabled = true;
            comboBoxBoardSizePvE.Items.AddRange(new object[] { "8x8" });
            comboBoxBoardSizePvE.Location = new Point(7, 37);
            comboBoxBoardSizePvE.MaxDropDownItems = 3;
            comboBoxBoardSizePvE.Name = "comboBoxBoardSizePvE";
            comboBoxBoardSizePvE.Size = new Size(121, 23);
            comboBoxBoardSizePvE.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 19);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 0;
            label6.Text = "Board Size:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxPlayer1PvE);
            groupBox4.Controls.Add(label8);
            groupBox4.Location = new Point(221, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(208, 187);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Player Settings";
            // 
            // textBoxPlayer1PvE
            // 
            textBoxPlayer1PvE.ForeColor = SystemColors.MenuText;
            textBoxPlayer1PvE.Location = new Point(6, 49);
            textBoxPlayer1PvE.Name = "textBoxPlayer1PvE";
            textBoxPlayer1PvE.Size = new Size(133, 23);
            textBoxPlayer1PvE.TabIndex = 3;
            textBoxPlayer1PvE.Text = "Player";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 31);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 1;
            label8.Text = "Player Name:";
            // 
            // buttonStartGamePvE
            // 
            buttonStartGamePvE.Location = new Point(181, 235);
            buttonStartGamePvE.Name = "buttonStartGamePvE";
            buttonStartGamePvE.Size = new Size(74, 31);
            buttonStartGamePvE.TabIndex = 8;
            buttonStartGamePvE.Text = "Start";
            buttonStartGamePvE.UseVisualStyleBackColor = true;
            buttonStartGamePvE.Click += ButtonStartPvE;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(446, 310);
            Controls.Add(tabControlSetting);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControlSetting.ResumeLayout(false);
            tabPagePvP.ResumeLayout(false);
            tabPagePvE.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button buttonStartGamePvP;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox comboBoxBoardSizePvP;
        private ComboBox comboBoxFirstMovePvP;
        private Label label4;
        private TextBox textBoxPlayer2PvP;
        private TextBox textBoxPlayer1PvP;
        private CheckBox checkBoxShowMovesPvP;
        private TabControl tabControlSetting;
        private TabPage tabPagePvP;
        private TabPage tabPagePvE;
        private GroupBox groupBox3;
        private CheckBox checkBoxShowMovesPvE;
        private ComboBox comboBoxFirstMovePvE;
        private Label label5;
        private ComboBox comboBoxBoardSizePvE;
        private Label label6;
        private GroupBox groupBox4;
        private TextBox textBoxPlayer1PvE;
        private Label label8;
        private Button buttonStartGamePvE;
        private CheckBox checkBoxForceJumpPvP;
        private CheckBox checkBoxForceJumpPvE;
    }
}