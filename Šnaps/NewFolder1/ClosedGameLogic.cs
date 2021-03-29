using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    static class ClosedGameLogic
    {
        static public bool IsFirstCardWinner(Card card1, Card card2)
        {
            if (GameLogic.AreCardsSameColor(card1, card2))
            {
                if (GameLogic.IsFirstCardHigherValue(card1, card2))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
