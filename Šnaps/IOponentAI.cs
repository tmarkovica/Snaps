using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IOponentAI
    {
        Card GetCardToPlay(Hand hand);
    }
}
