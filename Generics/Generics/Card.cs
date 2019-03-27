using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Card
    {
        public Suits CardSuit { get; set; }
        public Values CardValue { get; set; }

        public Card(Suits suit, Values value)
        {
            CardSuit = suit;
            CardValue = value;
        }
    }
}
