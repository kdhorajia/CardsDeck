using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardChallange.Models
{
    public static class Extensions
    {
        public static IEnumerable<Card> SortForSuit(this IEnumerable<Card> cards, CardSuit suit)
        {
            return cards.Where(_ => _.Suit == suit).OrderBy(_ => (int)_.Face);
        }
    }
}
