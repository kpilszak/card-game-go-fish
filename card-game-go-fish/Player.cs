using System;
using System.Windows.Forms;

namespace card_game_go_fish
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;
    }
}