using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    abstract class Manager
    {
        IObserver observer;

        public void Attach(IObserver observer)
        {
            this.observer = observer;
        }

        public void Notify()
        {
            this.observer.Update(this);
        }

        public abstract void Process();

        public abstract void Next();
    }
}
