using NUnit.Framework;
using CardChallange;
using CardChallange.Models;

namespace Tests
{
    [TestFixture(TestName = "Card Tests")]
    public class CardTests
    {

        [Test]
        public void CardFaceValue([Values(CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade)] CardSuit suit,
            [Values(CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10,
            CardFace.Jack, CardFace.Queen, CardFace.King)]CardFace face)
        {
            var sut = new Card(suit, face);
            var expectedValue = ((int)face) > 10 ? 10 : ((int)face);

            Assert.AreEqual(expectedValue, sut.FaceValue, "Card {0}, {1} should have face value {2}", sut.Suit, sut.Face, expectedValue);
        }

    }
}