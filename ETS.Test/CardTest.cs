using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETS.DeckOfCards;

namespace ETS.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Constructor_WithDefaultRankSuit_Valid()
        {
            // Arange
            Card card = new Card();
            int expectedRank = (int)Rank.ACE;
            int expectedSuit = (int)Suit.CLUB;

            // Act
            int actualRank = card.RankValue;
            int actualSuit = card.SuitValue;

            // Assert
            Assert.AreEqual(expectedRank, actualRank);
            Assert.AreEqual(expectedSuit, actualSuit);
        }

        [TestMethod]
        public void Constructor_WithCustomRankSuit_Valid()
        {
            // Arange
            Card card = new Card(Rank.JACK, Suit.HEART);
            int expectedRank = (int)Rank.JACK;
            int expectedSuit = (int)Suit.HEART;

            // Act
            int actualRank = card.RankValue;
            int actualSuit = card.SuitValue;

            // Assert
            Assert.AreEqual(expectedRank, actualRank);
            Assert.AreEqual(expectedSuit, actualSuit);
        }


        [TestMethod]
        public void Equlas_WithDifferentObject_Valid()
        {
            // Arange
            Card card1 = new Card(Rank.JACK, Suit.HEART);
            Card card2 = new Card(Rank.JACK, Suit.HEART);

            // Act
            bool self = card1.Equals(card1);
            bool result1 = card1.Equals(card2);
            bool result2 = card2.Equals(card1);
            int hash1 = card1.GetHashCode();
            int hash2 = card2.GetHashCode();

            // Assert
            Assert.AreEqual(true, self);
            Assert.AreEqual(result1, result2);
            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod]
        public void Equlas_WithDifferentOBject_Valid()
        {
            // Arange
            Card card1 = new Card(Rank.JACK, Suit.HEART);
            Card card2 = new Card(Rank.JACK, Suit.SPADE);

            // Act
            bool result = card1.Equals(card2);
            int hash1 = card1.GetHashCode();
            int hash2 = card2.GetHashCode();

            // Assert
            Assert.IsFalse(result);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void ToString_Content_Valid()
        {
            // Arange 
            Card card = new Card(Rank.JACK, Suit.HEART);
            string expected = "card : JACK of HEART";

            // Act
            string actual = card.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
