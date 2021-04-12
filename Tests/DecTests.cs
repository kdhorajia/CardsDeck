using CardChallange.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture(TestName = "Deck tests")]
    public class DecTests
    {
        Deck deck = null;
        [SetUp]
        public void Initialize()
        {
            deck = new Deck();
        }
        [Test]
        public void FindCardInDeck([Values(CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade)] CardSuit suit,
            [Values(CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10,
            CardFace.Jack, CardFace.Queen, CardFace.King)]CardFace face)
        {
            var sut = new Card(suit, face);
            Assert.NotNull(deck.Cards.FirstOrDefault(_ => _.Face == face && _.Suit == suit), "Card should exist: {0}, {1}", suit, face);
        }

        [Test]
        public void TotalCards()
        {
            Assert.AreEqual(52, deck.Cards.Count(), "Deck should have 52 cards");
        }

        [Test]
        public void TotalSuits()
        {
            var suits_count = deck.Cards.GroupBy(_ => _.Suit).Count();
            Assert.AreEqual(4, suits_count, "Deck should have 4 suits");
        }


        [Test]
        public void CardsInEachSuit([Values(CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade)] CardSuit suit)
        {
            var cardsInSuits_count = deck.Cards.Where(_ => _.Suit == suit).Count();
            Assert.AreEqual(13, cardsInSuits_count, "Suit {0} should have 13 cards", suit);
        }


        [Test]
        public void SortCards([Values(CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade)] CardSuit suit)
        {
            var cards = deck.Cards.SortForSuit(suit);
            var orderdCards = new List<CardFace>(new[] {CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10,
            CardFace.Jack, CardFace.Queen, CardFace.King}.AsEnumerable());

            var i = 0;
            foreach (var card in cards)
            {
                var expectedFace = orderdCards[i];
                Assert.AreEqual(expectedFace, card.Face, "Card should be {0}", expectedFace);
                i++;
            }
        }
    }
}
