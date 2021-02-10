using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IGameLogic
    {
        bool IsFirstCardWinner(Card card1, Card card2);

        bool IsFirstCardStronger(Card card1, Card card2);

        bool IsCardAdut(Card card);

        bool CompareCardColors(Card card1, Card card2);

        bool CompareCardValues(Card card1, Card card2);
    }
}
