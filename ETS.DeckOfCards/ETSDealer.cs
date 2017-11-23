using System;
using System.Collections.Generic;

namespace ETS.DeckOfCards
{
    /// <summary>
    /// This class represents spercial type of dealer known as ETSDealer. 
    /// ETSDealer is notoriously known for shuffling their deck every single time he/she
    /// is asked to deal a card.  This is due to further ensure uniform randomeness of Deck of cards.
    /// </summary>
    public class ETSDealer : Dealer
    {
        private readonly DateTime _hireDate;

        public DateTime HireDate { get { return _hireDate; } }

        /// <summary>
        /// Default constructor, hire date of this perticular Dealer is set to 
        /// creation of this dealer object.
        /// </summary>
        /// <param name="id">Id of new Dealer</param>
        /// <param name="name">Name of new Dealer</param>
        /// <param name="deck">Deck of card assigned</param>
        public ETSDealer(int? id, string name, Deck deck)
               : base(id, name, deck)
        {
            _hireDate = DateTime.Now;
        }

        /// <summary>
        /// Constructs ETSDealer type with provided hire date.
        /// Note that hire date must be past time. 
        /// </summary>
        /// <param name="id">Id of new Dealer</param>
        /// <param name="name">name of new Dealer</param>
        /// <param name="deck">Deck of Cards assigned</param>
        /// <param name="hireDate"></param>
        public ETSDealer(int? id, string name, Deck deck, DateTime hireDate)
               :base(id, name, deck)
        {
           if(IsFutureDate(hireDate) == true)
            {
                throw new ArgumentException("Hire Date cannot be a future date");
            }
            _hireDate = hireDate;
        } 

        // Helper method that determins whether the given time is future date
        private bool IsFutureDate(DateTime time)
        {
            if (time.Year > DateTime.Now.Year)
                return true;
            if (time.Month > DateTime.Now.Month)
                return true;
            if (time.Date > DateTime.Now.Date)
                return true;
            return false;
        }

        /// <summary>
        /// Deals just one Card
        /// </summary>
        /// <returns>One Card object</returns>
        public override Card DealOneCard()
        {
            base.Deck.ShuffleDeck();
            Card ret = base.Deck.GetCard();
            return ret;
        }

        /// <summary>
        /// Deals the Cards specified by cardCount parameter
        /// </summary>
        /// <param name="cardCount">Number of Cards to be dealed</param>
        /// <returns>List of Card objects</returns>
        public IList<Card> DealCard(int cardCount)
        {
            if(cardCount < 0 || cardCount > base.Deck.CardsLeft)
            {
                throw new ArgumentException("Card count is not valid");
            }

            IList<Card> ret = new List<Card>();
            for(int i = 0; i < cardCount; i++)
            {
                base.Deck.ShuffleDeck();
                ret.Add(base.Deck.GetCard());
            }
            return ret;
        }

        /// <summary>
        /// Shuffles the deck just one time.
        /// </summary>
        public override void ShuffleDeck()
        {
            base.Deck.ShuffleDeck();
        }

        /// <summary>
        /// Shuffles the deck as many times specified by count parameter
        /// </summary>
        /// <param name="count">number of times to shuffle the deck</param>
        public void ShuffleDeck(int count)
        {
            if(count <= 0)
            {
                return;
            }

            for(int i = 0; i < count; i++)
            {
                base.Deck.ShuffleDeck();
            }
        }
    }
}
