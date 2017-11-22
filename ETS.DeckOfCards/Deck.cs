﻿using System;
using System.Collections.Generic;
using System.Text;


namespace ETS.DeckOfCards
{
    public class Deck 
    {
        private readonly IList<Card> _currentCardDeck;
        private int _cardUsed;

        public Deck()
        {
            _currentCardDeck = new List<Card>();
            int suitSize = Enum.GetNames(typeof(Suit)).Length;
            int rankSize = Enum.GetNames(typeof(Rank)).Length;
            for(int s = 0; s < suitSize; s++)
            {
                for(int r = 0; r < rankSize; r++)
                {
                    Rank rank = (Rank)r;
                    Suit suit = (Suit)s;
                    _currentCardDeck.Add(new Card(rank, suit));
                }
            }
            _cardUsed = 0;
        }

        public int CardsLeft { get { return _currentCardDeck.Count - _cardUsed; } }


        /// <summary>
        /// Shuffles the deck of cards  
        /// </summary>
        public void ShuffleDeck()
        {
            // In each iteration, we pick integer r between 0 ~i uniformily at random
            // and swap the current item with the item at index r
            Random rand = new Random();
            int deckCount = _currentCardDeck.Count;
            for(int i = 0; i < deckCount; i++)
            {
                int r = rand.Next(i+1);
                Exchange(_currentCardDeck, i, r);
            }
        }

        // Helper class that swap the element at i-th index with 
        // with element at j-th index
        private void Exchange(IList<Card> a, int i, int j)
        {
            Card temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }


        public Card GetCard()
        {
            if (_cardUsed == _currentCardDeck.Count)
            {
                return null;
            }
            Card ret = _currentCardDeck[_cardUsed];
            _cardUsed++;
            return ret;
        }

        public Card GetCard(int index)
        {
            if(index < 0 || index >= _currentCardDeck.Count)
            {
                throw new IndexOutOfRangeException("Provided index is out of range of current Deck");
            }

            if(_cardUsed == _currentCardDeck.Count)
            {
                return null;
            }

            Card ret = _currentCardDeck[index];
            _cardUsed++;
            return ret;
        }
    }
}
