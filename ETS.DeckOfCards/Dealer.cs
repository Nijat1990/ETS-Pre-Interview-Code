using System;
using System.Collections.Generic;
using System.Text;

namespace ETS.DeckOfCards
{
    abstract class Dealer
    {
        private readonly Deck _deck;
        public int? DealerId { get; set; }
        public int Name { get; set; }
        public abstract Card DealOneCard();
        public abstract void ShuffleDeck();

        public Dealer(int? id, string name, Deck deck)
        {
            if(id == null || name == null || deck == null)
            {
                throw new ArgumentException("");
            }
        }
    }
}
