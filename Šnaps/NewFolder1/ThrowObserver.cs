using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Šnaps
{
    class ThrowObserver : Manager, IObserver
    {
        Oponent oponent;

        public void SeatOponent(Oponent oponent)
        {
            this.oponent = oponent;
        }

        private int counter = 0;

        private void Wait()
        {
            Thread.Sleep(1000);
        }

        public void Start(Manager manager)
        {
            manager.Next(0);
        }

        public void Update(Manager manager)
        {
            counter++;
            
            if (counter == 2)
            {
                counter = 0;
                Wait();
                manager.Process();
            }

            manager.Next(counter);

            if (counter == 1)
            {
                cardOnTable = manager.GetCardOnTable();

                this.oponent.PlayCard();

                Process();
            }
        }

        Card cardOnTable;


        /* MANAGER implementation */
        IObserver observer;

        public void Attach(IObserver observer)
        {
            this.observer = observer;
        }

        public void Notify()
        {
            this.observer.Update(this);
        }

        public override void Process()
        {
            //throw new NotImplementedException();
        }

        public override void Next(int next)
        {
            if (next == 0)
                this.oponent.SetAI(new OponentAI_PlaysSecond(cardOnTable));
            else if (next == 1)
                this.oponent.SetAI(new OponentAI_PlaysFirst());
        }
    }
}
