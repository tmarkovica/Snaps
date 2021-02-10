using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class TurnManager : Manager, IObserver
    {
        public override void Next(int next)
        {
            //throw new NotImplementedException();
        }

        public override void Process()
        {
            throw new NotImplementedException();
        }

        Card card1;
        Card card2;

        public void FindTurnWinner(Card card1, Card card2)
        {
            this.card1 = card1;
            this.card2 = card2;

            base.Notify();
        }

        private int nextThrower;

        public override void Process(IGameLogic logic)
        {
            if (logic.IsFirstCardWinner(card1, card2))
            {
                MessageBox.Show("First card is turn winner");

                //oponentAI = new OponentAI_PlaysFirst();

                nextThrower = 0;
            }
            else
            {
                MessageBox.Show("Second card is turn winner");

                //oponentAI = new OponentAI_PlaysFirst();

                nextThrower = 1;
            }

            //base.Notify(oponentAI);
        }

        private IOponentAI oponentAI;

       
        
        // OBSERVER implementation

        public void Update(Manager manager)
        {
            manager.Next(nextThrower);
        }

        public void Start(Manager manager)
        {
            throw new NotImplementedException();
        }
    }
}
