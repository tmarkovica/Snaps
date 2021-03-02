using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    abstract class GameLogic
    {
        string adutColor = "";

        public GameLogic(string adutColor) { this.adutColor = adutColor; }

        public bool IsCardAdut(Card card)
        {
            if (card == null) return false;
            if (String.Equals(card.GetCardColor(), adutColor))
                return true;
            else
                return false;
        }

        public bool AreCardsSameColor(Card card1, Card card2)
        {
            if (String.Equals(card1.GetCardColor(), card2.GetCardColor()))
                return true;
            else
                return false;
        }

        public bool IsFirstCardHigherValue(Card card1, Card card2)
        {
            if (card1.GetCardValue() > card2.GetCardValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        abstract public bool IsFirstCardWinner(Card card1, Card card2);

        abstract public bool IsFirstCardStronger(Card card1, Card card2);

        
    }
}
