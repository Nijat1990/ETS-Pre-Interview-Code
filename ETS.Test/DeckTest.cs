using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETS.DeckOfCards;
using System.Collections.Generic;

namespace ETS.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Constructor_Initialization_Valid()
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
        public void CardLeft_UsesAllCard_ReturnsZero()
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
        public void ToString_Unshuffled_Outputs()
        {
            // Arrange
            Deck deck = new Deck();

            // Non-shuffled Deck 
            foreach (Card c in deck)
                Console.WriteLine(c.ToString());
        }


        [TestMethod]
        public void ToString_Shuffled_Outputs()
        {
            // Arrange
            Deck deck = new Deck();

            // Act 
            deck.ShuffleDeck();

            // Shuffled Deck
            foreach (Card c in deck)
                Console.WriteLine(c.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCard_WithInvalidIndex_ThrowsException()
        {
            // Arrange
            Deck deck = new Deck();

            // Act 
            deck.GetCard(53);
        }

        [TestMethod]
        public void GetCard_WithValidIndex_DefaultCardEquals()
        {
            // Arrange
            Deck deck = new Deck();
            Card expected = new Card();

            // Act 
            Card actual = deck.GetCard(0);
            bool result = expected.Equals(expected);

            // Act 
            Assert.IsTrue(result);
        }

    }
}
