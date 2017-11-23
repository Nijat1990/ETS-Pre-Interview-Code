﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETS.DeckOfCards;

namespace ETS.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckCreationValid()
        {
            // Arrange
            Deck deck = new Deck();

            // Assert 
            int count = 0;
            foreach(Card card in deck)
            {
                Console.WriteLine(card.ToString());
                Assert.IsNotNull(card);
                count++;
            }
            Assert.AreEqual(52, count);
        }


        [TestMethod]
        public void CardLeftValid()
        {
            // Arrange
            Deck deck = new Deck();
            int expectedCardLeft = 52;

            // Act
            int actualCardLeft = deck.CardsLeft;

            // Assert
            Assert.AreEqual(actualCardLeft, expectedCardLeft);
            for (int i = 0; i < 52; i++)
                deck.GetCard();
            Assert.AreEqual(0, deck.CardsLeft);
        }



        [TestMethod]
        public void DefaultDeckPeek()
        {
            // Arrange
            Deck deck = new Deck();

            // Non-shuffled Deck 
            foreach (Card c in deck)
                Console.WriteLine(c.ToString());
        }


        [TestMethod]
        public void ShuffledDeckPeek()
        {
            // Arrange
            Deck deck = new Deck();

            // Act 
            deck.ShuffleDeck();

            // Shuffled Deck
            foreach (Card c in deck)
                Console.WriteLine(c.ToString());
        }



    }
}
