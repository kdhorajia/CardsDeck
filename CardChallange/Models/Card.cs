using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardChallange.Models
{
    public class Card
    {
        int _facevalue = 0;
        public Card(CardSuit suit, CardFace face    )
        {
            Suit = suit;
            Face = face;
        }
        public CardSuit Suit { get; }
        public CardFace Face { get; }
        public int FaceValue
        {
            get
            {
                if (_facevalue > 0)
                {
                    return FaceValue;
                }
                _facevalue = ((int)Face);
                _facevalue = _facevalue > 10 ? 10 : _facevalue;
                return _facevalue;
            }
        }
    }
}
