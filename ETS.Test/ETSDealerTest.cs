using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETS.DeckOfCards;
using System.Collections.Generic;

namespace ETS.Test
{
    [TestClass]
    public class ETSDealerTest
    {
        [TestMethod]
        public void Constructor_Initialization_EqualsWithOutput()
        {
            // Arrange
            Deck deck = new Deck();
            ETSDealer dealer = new ETSDealer(9975, "Nijat Muhtar", deck);

            // Assert
            Assert.IsNotNull(dealer);
            Assert.AreEqual(9975, dealer.DealerId);
            Assert.AreEqual("Nijat Muhtar", dealer.Name);
            Assert.IsNotNull(dealer.Deck);
            Console.WriteLine(dealer.HireDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNegativeId_ThrowsException()
        {
            // Arrange
            Deck deck = new Deck();
            ETSDealer dealer = new ETSDealer(-9, "Nijat Muhtar", deck);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullId_ThrowsException()
        {
            // Arrange
            Deck deck = new Deck();
            ETSDealer dealer = new ETSDealer(null, "Nijat Muhtar", deck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullName_ThrowsException()
        {
            // Arrange
            Deck deck = new Deck();
            ETSDealer dealer = new ETSDealer(9975, null, deck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullDeck_ThrowsException()
        {
            // Arrange
            Deck deck = new Deck();
            ETSDealer dealer = new ETSDealer(9975, "Nijat", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithFeatureDate_ThrowsException()
        {
            // Arrange
            DateTime future = new DateTime(2099, 1, 1);
            ETSDealer dealer = new ETSDealer(9975, "Nijat", new Deck(), future);
        }

        [TestMethod]
        public void DealOneCard_WithValidInit_ReturnsValidCard()
        {
            // Arrange
            ETSDealer dealer = new ETSDealer(9975, "Nijat", new Deck(), DateTime.Now);
            Card card = dealer.DealOneCard();

            // Assert
            Assert.IsNotNull(card);
            Console.Write(card.ToString());
        }

        [TestMethod]
        public void DealMultipleCard_DealsTenTimes_ReturnsValidState()
        {
            // Assert 
            ETSDealer dealer = new ETSDealer(9975, "Nijat", new Deck(), DateTime.Now);
            List<Card> ret = dealer.DealCard(10);

            // Act 
            int cardleftInDeck = 42;
            int numberOfCardReturned = 10;

            // Assert 
            Assert.IsNotNull(ret);
            foreach (Card c in ret)
                Assert.IsNotNull(c);
            Assert.AreEqual(cardleftInDeck, dealer.Deck.CardsLeft);
            Assert.AreEqual(numberOfCardReturned, ret.Count);
        }



        [TestMethod]
        public void DealMultipleCard_DealsAllCards_ReturnsNull()
        {
            // Assert 
            ETSDealer dealer = new ETSDealer(9975, "Nijat", new Deck(), DateTime.Now);
            List<Card> ret = dealer.DealCard(52);

            // Act 
            int cardleftInDeck = 0;
          
            // Assert 
            Assert.IsNotNull(ret);
            foreach (Card c in ret)
                Assert.IsNotNull(c);
            Assert.AreEqual(cardleftInDeck, dealer.Deck.CardsLeft);

            // since all the card has been used
            // calling DealOneCard should return null
            Assert.IsNull(dealer.DealOneCard());
        }
    }
}
