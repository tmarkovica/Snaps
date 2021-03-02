using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class TableCardHolder : CardHolder, ITableObservable, ICollectable
    {
        public TableCardHolder(PictureBox pictureBox) : base(pictureBox) { }

        private List<ITableObserver> observers = new List<ITableObserver>();

        public void Attach(ITableObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Notify()
        {
            foreach (ITableObserver observer in observers)
                observer.UpdateAboutOponentsCard(GetCard());
        }

        override public void PlaceCard(Card card)
        {
            base.PlaceCard(card);
            Notify();
        }

        public Card PullCard()
        {
            return base.TakeCard();
        }
    }
}
