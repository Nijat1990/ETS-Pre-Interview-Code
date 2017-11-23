using System;

namespace ETS.DeckOfCards
{
    /// <summary>
    /// Immutable class that represents a single gaming card 
    /// It has Rank and Suit value represented by Rank and Suit 
    /// enum type.  
    /// </summary>
    public sealed class Card 
    {
        private readonly Rank _rank;
        private readonly Suit _suit;
        
        /// <summary>
        /// Returns integer representaion of Card's Rank
        /// </summary>
        public int RankValue
        {
            get
            {
                // returning integer representation of Rank value is necessary 
                // since integer makes sorting and custom comparing capabilites easy
                int rankVal = (int)_rank;
                return rankVal;
            }
        }

        /// <summary>
        /// Returns integer representation of Card's Suit
        /// </summary>
        public int SuitValue
        {
            get
            {
                int suitVal = (int)_suit;
                return suitVal;
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

        /// <summary>
        /// Constructs a single card object with given 
        /// Rank and Suit enum types
        /// </summary>
        /// <param name="rank">Rank of the card</param>
        /// <param name="suit">Suit of the card</param>
        public Card(Rank rank,  Suit suit )
        {
        //    if(IsValidCard(rank, suit) == false)
        //    {
        //        throw new ArgumentException("Provided Rank and Suit does not constitute valid Card");
        //    }
            _rank = rank;
            _suit = suit;
        }

        // Helper method that validates if valid Card can be constructed with given 
        // Rank and Suit enum type
        //private bool IsValidCard(Rank rank, Suit suit)
        //{
        //    if (rank < Rank.ACE || rank > Rank.KING)
        //        return false;
        //    if (suit < Suit.CLUB || suit > Suit.SPADE)
        //        return false;
        //    return true;
        //}

        /// <summary>
        /// Returns string representation of Card content 
        /// Consisting of its Rank and Suit string value.
        /// </summary>
        /// <returns>String representation of Card </returns>
        public override string ToString()
        {
            return "card : " + RankString(_rank) + " of " + SuitString(_suit);
        }


        // Helper method of toString() that returns the string 
        // representation of given Rank value
        private string RankString(Rank rank)
        {
            switch (rank)
            {
                case Rank.ACE:   return "ACE";
                case Rank.TWO:   return "TWO";
                case Rank.THREE: return "THREE";
                case Rank.FOUR:  return "FOUR";
                case Rank.FIVE:  return "FIVE";
                case Rank.SIX:   return "SIX";
                case Rank.SEVEN: return "SEVEN";
                case Rank.EIGHT: return "EIGHT";
                case Rank.NINE:  return "NINE";
                case Rank.TEN:   return "TEN";
                case Rank.JACK:  return "JACK";
                case Rank.QUEEN: return "QUEEN";
                case Rank.KING:  return "KING";
                default:         return null;
            }
        }

        // Helper method of toString() that returns the string 
        // representation of given Suit value
        private string SuitString(Suit suit)
        {
            switch (suit)
            {
                case Suit.CLUB:    return "CLUB";
                case Suit.DIAMOND: return "DIAMOND";
                case Suit.HEART:   return "HEART";
                case Suit.SPADE:   return "SPADE";
                default:           return "Null";
            }
        }

        /// <summary>
        /// Compares cureent Card object with other card for equality.
        /// If the both Card object has same Suit and Rank values it is deemed equal
        /// otherwise it is not equal.
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>true if equals with current card otherwise false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            Card that = obj as Card;
            return (that.RankValue == this.RankValue 
                            && that.SuitValue == this.SuitValue);
        }

        /// <summary>
        /// Calculates hascode for the current Card object
        /// </summary>
        /// <returns>32 bit integer representation of hashcode</returns>
        public override int GetHashCode()
        {
            return _rank.GetHashCode() ^ _suit.GetHashCode();
        }
    }
}
