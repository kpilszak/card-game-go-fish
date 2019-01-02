using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace card_game_go_fish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("Enter your name", "The game can not be started yet.");
                return;
            }
            game = new Game(textName.Text, new List<string> { "John", "Bart" }, textProgress);

        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {

        }
    }
}
