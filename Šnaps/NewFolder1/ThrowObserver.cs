using System;
using System.Threading;
using System.Threading.Tasks;

namespace Šnaps
{
    class ThrowObserver : IObserver
    {
        private CardHolder tableCard1;
        private CardHolder tableCard2;

        private Oponent oponent;

        private int counter = 0;

        public void Start(IManager manager)
        {
            throw new NotImplementedException();
        }

        public void Update(IManager manager) // updateam status "Who throws" kad je nesto odigrano
        {
            counter++;
            if (counter > 1)
            {
                manager.Process();
            }
            else
                manager.NextThrower();

           
        }

        public void UpdateAIForOponentsThrow(IOponentAI oponentAI)
        {
            this.oponent.SetAI(oponentAI); Console.WriteLine(oponentAI.ToString());
            this.oponent.PlayCard();
        }

        public void SeatOponent(Oponent oponent)
        {
            this.oponent = oponent;
        }
    }
}
