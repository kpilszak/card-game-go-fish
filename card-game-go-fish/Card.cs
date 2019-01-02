using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game_go_fish
{      
    class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }

        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public string Name
        {
            get
            {
                return names[(int)Value] + " " + Suits[(int)Suit];
            }
        }

        private static string[] names0And2AndMore = new string[]
        {
            "", "aces", "twos", "threes", "fours", "fives", "sixes", "sevens", "eights", "nines", "tens", "jacks", "queens", "kings"
        };

        private static string[] names1 = new string[]
        {
            "", "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king"
        };

        public static string Plural(Values value, int count)
        {
            if (count == 1)
                return names1[(int)value];
            else
                return names0And2AndMore[(int)value];
        }

        private static string[] suits = new string[] { "spade", "club", "diamond", "heart" };
        private static string[] names = new string[] { "", "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

    }
}
