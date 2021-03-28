using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class GameLogic
    {
        static public bool IsCardAdut(Card card)
        {
            if (String.Equals(card.GetCardColor(), AdutColor.GetColor()))
                return true;
            else
                return false;
        }

        static public bool AreCardsSameColor(Card card1, Card card2)
        {
            if (String.Equals(card1.GetCardColor(), card2.GetCardColor()))
                return true;
            else
                return false;
        }

        static public bool IsFirstCardHigherValue(Card card1, Card card2)
        {
            if (card1.GetCardValue() > card2.GetCardValue())
                return true;
            else
                return false;
        }
    }
}
