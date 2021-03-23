using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IOponentsHand
    {
        Card CounterCard(Card card);

        Card StartingCard();
    }
}
