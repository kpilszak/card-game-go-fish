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
            players = new List<Player>
            {
                new Player(playerName, random, textBoxOnForm)
            };
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            matches = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            foreach (Player player in players)
                PullOutMatches(player);
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            Values cardToAskFor = players[0].Peek(selectedPlayerCard).Value;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                    players[0].AskForACard(players, 0, stock, cardToAskFor);
                else
                    players[i].AskForACard(players, i, stock);
                if (PullOutMatches(players[i]))
                {
                    textBoxOnForm.Text += players[i].Name + " is pulling cards " + Environment.NewLine;
                    int card = 1;
                    while (card <= 5 && stock.Count > 0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[0].SortHand();
                if (stock.Count == 0)
                {
                    textBoxOnForm.Text = "No cards on the stock. The end!" + Environment.NewLine;
                    return true;
                }
            }
            return false;
        }

        public bool PullOutMatches(Player player)
        {
            IEnumerable<Values> matchesPulled = player.PullOutMatches();
            foreach (Values value in matchesPulled)
                matches.Add(value, player);
            if (player.CardCount == 0)
                return true;
            return false;
        }

        public string DescribeMatches()
        {
            string whoHasWhichMatches = "";
            foreach (Values value in matches.Keys)
                whoHasWhichMatches += matches[value].Name + " has a match of " + Card.Plural(value, 0) + Environment.NewLine;
            return whoHasWhichMatches;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (Values value in matches.Keys)
            {
                string name = matches[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }
            int mostMatches = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostMatches)
                    mostMatches = winners[name];
            bool tie = false;
            string winnerList = "";
            foreach (string name in winners.Keys)
                if (winners[name] == mostMatches)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += ": " + mostMatches + " matches ";
            if (tie)
                return "Tie between " + winnerList;
            else
                return winnerList;
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
                    description += " cards.\r\n";
            }
            description += "On the stock there is " + stock.Count + " cards left.\r\n";
            return description;
        }
    }
}
