using System;
using System.Collections.Generic;
using System.Text;

namespace ETS.DeckOfCards
{
    public abstract class Dealer
    {
        public int? DealerId { get;}
        public string Name { get;}
        public Deck Deck { get; }
       
        public Dealer(int? id, string name, Deck deck)
        {
            if(id == null || name == null || deck == null)
            {
                throw new ArgumentException("Null argument cannot be accpeted");
            }
            DealerId = id;
            Name = name;
            Deck = deck;
        }


        public abstract Card DealOneCard();

        public abstract void ShuffleDeck();
    }
}
