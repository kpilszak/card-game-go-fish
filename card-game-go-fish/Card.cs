﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_game_go_fish
{
    enum Suits
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts,
    }

    enum Values
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

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
                return Value.ToString() + " of " + Suit.ToString();
            }
        }
    }
}
