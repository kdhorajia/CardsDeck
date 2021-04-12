using CardChallange.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests
{
    [Binding]
    public class DeckOfPlayingCardsSteps
    {
        Deck deck;
        int allCardsCount;
        private IEnumerable<CardSuit> Suits;
        private IEnumerable<Card> singleSuitCards;
        private string keyCardFace;

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            deck = new Deck();
        }

        [When(@"I count each card")]
        public void WhenICountEachCard()
        {
            allCardsCount = deck.Cards.Count();
        }

        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            Suits = deck.Cards.GroupBy(_ => _.Suit).Select(_ => _.Key);
        }

        [When(@"I count all the cards in a single suit")]
        public void WhenICountAllTheCardsInASingleSuit()
        {
            singleSuitCards = deck.Cards.SortForSuit(CardSuit.Heart);
        }

        [When(@"I have a card with (.*)")]
        public void WhenIHaveACardWith(string cardFace)
        {
            keyCardFace = cardFace;
        }

        [Then(@"I have a total of (.*) cards")]
        public void ThenIHaveATotalOfCards(int expectedCount)
        {
            Assert.AreEqual(expectedCount, allCardsCount, "Deck should have 52 cards");
        }

        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {
            new[] { CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade }.All(_ => Suits.Any(_s => _ == _s));
        }

        [Then(@"I have (.*) cards: (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIHaveCardsAceJackQueenKing(int expectedCount, string ace, string card2, string card3, string card4, string card5, string card6, string card7, string card8, string card9, string card10, string jack, string queen, string king)
        {
            var expectedOrder = new[] { ace, card2, card3, card4, card5, card6, card7, card8, card9, card10, jack, queen, king };
            var actualOrder = singleSuitCards.Select(_ => _.Face.ToString());

            Assert.AreEqual(expectedCount, singleSuitCards.Count());
            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }

        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string keyValue, Table table)
        {
            foreach (var row in table.Rows)
            {
                var face = Enum.Parse<CardFace>(row[keyCardFace]);
                var expectedFaceValue = int.Parse(row[keyValue]);

                var card = deck.Cards.First(_ => _.Face == face);
                Assert.AreEqual(expectedFaceValue, card.FaceValue);
            }
        }

        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {
            var cards = deck.Cards.SortForSuit(CardSuit.Heart).Where(_ => _.FaceValue == 10);
            var expectedOrder = new[] { CardFace.Card10, CardFace.Jack, CardFace.Queen, CardFace.King };
            var actualOrder = cards.Select(_ => _.Face);

            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }
    }
}
