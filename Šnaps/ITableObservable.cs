using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface ITableObservable
    {
        void Attach(ITableObserver observer);
        void Notify();
        void PlaceCard(Card card);
    }
}
