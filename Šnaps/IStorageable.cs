using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IStorageable
    {
        void PlaceCard(Card card);

        Card TakeCard();
    }
}
