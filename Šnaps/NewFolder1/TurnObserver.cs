using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class TurnObserver //: IObserver
    {
        private int turnCounter = 0;

        private IGameLogic gameLogic = new NormalGameLogic();

        public void Start(IManager manager)
        {

        }

        public void Update(IManager manager)
        {
            turnCounter++;

            //manager.Process(gameLogic);

        }
    }
}
