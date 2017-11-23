using System;

namespace ETS.DeckOfCards
{
    /// <summary>
    /// Abstract class Dealer represents the common feature of Dealer of playing cards.
    /// It has unique dealer ID, Name, and Deck that can be assigned later time as demanded. 
    /// Any sub-type of this class must implement functionality of dealing one card and shuffling the Deck
    /// that current dealer is using. 
    /// </summary>
    public abstract class Dealer
    {
        /// <summary>
        /// Dealer's unique id
        /// </summary>
        public int? DealerId { get;}

        /// <summary>
        /// Dealers Name 
        /// </summary>
        public string Name { get;}


        /// <summary>
        /// Dealers assigned Deck 
        /// </summary>
        public Deck Deck { get; set; }
       

        /// <summary>
        /// Default Constructor. Id must be non-negative and non-null integer.
        /// Name and deck must not be null. 
        /// </summary>
        /// <param name="id">New Dealers Id</param>
        /// <param name="name">New Dealers Name</param>
        /// <param name="deck">New Dealers first assigned Deck</param>
        public Dealer(int? id, string name, Deck deck)
        {
            if(id == null || id < 0  || name == null || deck == null)
            {
                throw new ArgumentException("Provided arugument is invalid");
            }
            DealerId = id;
            Name = name;
            Deck = deck;
        }

        /// <summary>
        /// All types of Dealer must be able to at least deal one Card.
        /// </summary>
        /// <returns>Card</returns>
        public abstract Card DealOneCard();


        /// <summary>
        /// All types of Dealer must be able to at least shuffle one Deck
        /// </summary>
        public abstract void ShuffleDeck();
    }
}
