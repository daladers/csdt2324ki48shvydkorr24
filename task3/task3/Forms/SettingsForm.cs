using task3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class SettingsForm : Form
    {
        public bool isCorrect { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            comboBoxBoardSizePvP.SelectedIndex = 0;
            comboBoxFirstMovePvP.SelectedIndex = 0;
            comboBoxBoardSizePvE.SelectedIndex = 0;
            comboBoxFirstMovePvE.SelectedIndex = 0;
        }

        private void ButtonStartPvP(object sender, EventArgs e)
        {
            if (CheckSettingsPvP() == true)
            {
                Setting.BoardSize = comboBoxBoardSizePvP.Text;
                Setting.ForceJump = checkBoxForceJumpPvP.Checked;
                Setting.ShowMove = checkBoxShowMovesPvP.Checked;
                Setting.FirstMove = WhichTurn(comboBoxFirstMovePvP.Text);
                Setting.Player1Name = textBoxPlayer1PvP.Text;
                Setting.Player2Name = textBoxPlayer2PvP.Text;
                Setting.isAiPlay = false;
                this.Close();
            }
        }
        private void ButtonStartPvE(object sender, EventArgs e)
        {
            if (CheckSettingsPvE() == true)
            {
                Setting.BoardSize = comboBoxBoardSizePvE.Text;
                Setting.ForceJump = checkBoxForceJumpPvE.Checked;
                Setting.ShowMove = checkBoxShowMovesPvE.Checked;
                Setting.FirstMove = WhichTurn(comboBoxFirstMovePvE.Text);
                Setting.Player1Name = textBoxPlayer1PvE.Text;
                Setting.Player2Name = "Computer";
                Setting.isAiPlay = true;
                this.Close();
            }
        }

        private bool CheckSettingsPvP()
        {
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer1PvP, 1, true) == true)
                isCorrect = true;
            else
                return isCorrect;
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer2PvP, 2, true) == true)
                isCorrect = true;
            else
                return isCorrect;
            return isCorrect;
        }

        private bool CheckSettingsPvE()
        {
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer1PvP, 1, false) == true)
                isCorrect = true;
            return isCorrect;
        }

        private bool CheckPlayerName(TextBox Player, int Number, bool isPvP)
        {
            if (Player.Text == "")
            {
                if (isPvP == true)
                {
                    MessageBox.Show("Player " + Number + " name is empty!");

                    return false;
                }
                else
                {
                    MessageBox.Show("Player " + Number + " name is empty!");

                    return false;
                }
            }
            else if (Player.Text.Length > 10)
            {
                if (isPvP == true)
                {
                    MessageBox.Show("Player  " + Number + " name is too long!\n");
                    return false;
                }
                else
                {
                    MessageBox.Show("Player  " + Number + " name is too long!\n");
                    return false;
                }
            }
            return true;
        }

        private bool WhichTurn(string firstStart)
        {
            if (firstStart == "Player 1" || firstStart == "Player")
                return true;
            else
                return false;
        }
    }
}
