using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class TurnObserver : IObserver
    {
        private int turnCounter = 0;

        private IGameLogic gameLogic = new NormalGameLogic();

        public void Start(Manager manager)
        {

        }

        public void Update(Manager manager)
        {
            turnCounter++;

            manager.Process(gameLogic);

        }
    }
}
