using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IObserver
    {
        void Update(IManager manager);

        void Start(IManager manager);

        void UpdateAIForOponentsThrow(IOponentAI oponentAI);
    }
}
