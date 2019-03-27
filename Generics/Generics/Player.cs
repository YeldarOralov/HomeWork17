using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Player
    {
        public List<Card> Cards;
        public int Number { get; set; }

        public Player(int number)
        {
            Number = number;
            Cards = new List<Card>();
        }
        
    }
}
