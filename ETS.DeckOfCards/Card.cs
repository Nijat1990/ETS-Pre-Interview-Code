using System;

namespace ETS.DeckOfCards
{
    /// <summary>
    /// Immutable class that represents a single gaming card 
    /// </summary>
    public sealed class Card
    {
        private Rank _rank;
        private Suit _suit;

        public Rank Rank
        {
            get
            {
                return _rank;
            }
        }

        public Suit Suit
        {
            get
            {
                return _suit;
            }
        }

        /// <summary>
        /// Defualt Constructor
        /// </summary>
        public Card()
        {
            _rank = Rank.ACE;
            _suit = Suit.CLUB;
        }

        public Card(Rank rank,  Suit suit )
        {
            isValidCard(rank, suit);
            _rank = rank;
            _suit = suit;
        }

        private bool isValidCard(Rank rank, Suit suit)
        {
            return false;
        }



    }
}
