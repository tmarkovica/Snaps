using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace Šnaps
{
    class ThrowManager : IManager, IPlayable
    {
        bool oponentThrows = false;
        bool oponentsTurn = false;

        Label labelTurn;

        public void SetTurnLabel(Label label) { this.labelTurn = label; }

        private void ThrowLabelUpdate()
        {
            if (oponentThrows)
            {
                this.labelTurn.Text = "Protivnik igra";
                this.labelTurn.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                this.labelTurn.Text = " Vi igrate";
                this.labelTurn.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void Wait()
        {
            Task.Delay(3000);
            Thread.Sleep(1000);
            
        }

        CardHolder tableCard1;
        CardHolder tableCard2;

        public void SetTable(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            this.tableCard1 = new CardHolder(pictureBox1);
            this.tableCard2 = new CardHolder(pictureBox2);
        }


        // SUBJECT from OBSERVER PATTERN
        IObserver observer;

        public void Attach(IObserver observer)
        {
            this.observer = observer;
        }

        public void Notify_CardIsPlayed()
        {
            this.observer.Update(this);
        }

        public void Notify_OponentsThrow()
        {
            IOponentAI oponentAI;

            if (oponentsTurn)
            {
                oponentAI = new OponentAI_PlaysFirst();
            }
            else
            {
                oponentAI = new OponentAI_PlaysSecond(tableCard1.GetCard());
            }
            
            this.observer.UpdateAIForOponentsThrow(oponentAI);
        }

        private void PlaceCardOnTable(Card card)
        {
            if (oponentThrows)
                tableCard2.PlaceCard(card);
            else
                tableCard1.PlaceCard(card);
        }

        public void Play(Card card)
        {
            this.PlaceCardOnTable(card);

            Notify_CardIsPlayed();
        }

        public void NextThrower()
        {
            oponentThrows = !oponentThrows;
            ThrowLabelUpdate();

            if (this.oponentThrows)
                Notify_OponentsThrow();
        }

        private void ClearHolders()
        {
            //Wait();
            tableCard1.ClearHolder();
            tableCard2.ClearHolder();
        }

        public void Process()
        {
            IGameLogic gameLogic = new NormalGameLogic();
            //Wait();
            /*
            if (gameLogic.IsFirstCardWinner(this.tableCard1.TakeCard(), this.tableCard2.TakeCard()))
            {
                oponentsTurn = false;
                oponentThrows = false;
            }
            else
            {
                oponentsTurn = true;
                oponentThrows = true;
            }*/
            ThrowLabelUpdate();



            SetTimer();

            //ClearHolders();
        }

        private static System.Timers.Timer timer = new System.Timers.Timer();

        private static void SetTimer()
        {
            

            timer.Interval = 2000;
            timer.Enabled = true;

            Console.WriteLine("Loading...");
            timer.Start();

            timer.Elapsed += OnTimedEvent;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Console.WriteLine("Loaded");

            ClearHolders();
        }
    }
}
