using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IManager
    {
        void Attach(IObserver observer);

        void Notify_CardIsPlayed();

        void Notify_OponentsThrow();

        void Process();

        void NextThrower();
    }
}
