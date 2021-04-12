using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardChallange.Models
{
    public class Deck
    {
        public Deck()
        {
            //Cards = new[] { CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade }.SelectMany(_2=> new[] {CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10,
            //CardFace.Jack, CardFace.Queen, CardFace.King},(l,r)).Select(_ => new Card(_., _.Second));
            //Cards = from card in new[] { CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade }
            //        from face in new[] {CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10,
            //                            CardFace.Jack, CardFace.Queen, CardFace.King}
            //        select new Card(card, face);

            Cards = new[] { CardSuit.Club, CardSuit.Diamond, CardSuit.Heart, CardSuit.Spade }
                    .SelectMany(r => new[] {CardFace.Ace, CardFace.Card2, CardFace.Card3, CardFace.Card4, CardFace.Card5, CardFace.Card6, CardFace.Card7, CardFace.Card8, CardFace.Card9, CardFace.Card10, CardFace.Jack, CardFace.Queen, CardFace.King}.AsEnumerable(),
                                (suit, face) => new Card(suit, face));
        }
        public IEnumerable<Card> Cards { get; }
    }
}
