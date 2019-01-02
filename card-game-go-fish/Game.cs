using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace card_game_go_fish
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> matches;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(playerName, random, textBoxOnForm));
            matches = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {

        }

        public bool PlayOneRound(int selectedPlayerCard)
        {

        }

        public bool PullOutMatches(Player player)
        {

        }

        public string DescribeMatches()
        {

        }

        public string GetWinnerName()
        {

        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " has " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " card.\r\n";
                else
                    description += "cards.\r\n";
            }
            description += "On the stock there is " + stock.Count + " cards left.\r\n";
            return description;
        }
    }
}
