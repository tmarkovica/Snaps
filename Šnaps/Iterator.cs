using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class Iterator //: IAbstractIterator
    {
        private Participants participants;
        private int currentPlayerIndex;
        private int throwCounter;

        public Iterator(Participants participants)
        {
            this.participants = participants;
            this.currentPlayerIndex = 0;
            this.throwCounter = 0;
        }

        public int NumberOfParticipants { get { return this.participants.Count; } }

        private bool IsCounted(int index) { return index >= this.participants.Count; }

        public Player CurrentPlayer
        {
            get
            {
                this.currentPlayerIndex++;
                if (IsCounted(this.currentPlayerIndex))
                    this.currentPlayerIndex = 0;

                return this.participants[currentPlayerIndex];
            }
        }

        public void PrepNextPlayer()
        {
            this.throwCounter++;
            
            if (IsCounted(this.throwCounter))
            {
                throwCounter = 0;
                Console.WriteLine("*Turn is done.");
                //DetermineTurnWinner();
            }
        }

        public void IntroduceGameMechanicsToPlayers(GameMechanism gameMechanism)
        {
            for (int i = 0; i < this.participants.Count; i++)
            {
                participants[i].ExplainGameMechanics(gameMechanism);

                List<ITableObserver> observers = new List<ITableObserver>(); // sve ostale igrače osim trenutno u stavljam u listu

                for (int j = 0; j < this.participants.Count; j++)
                {
                    if (i != j)
                        observers.Add(this.participants[j]);
                }

                this.CurrentPlayer.GreetOtherPlayers(observers);
            }
        }

        private void DetermineTurnWinner()
        {
            int tempCurrent = this.currentPlayerIndex;

            List<Card> cards = new List<Card>();

            int turnWinnerIndex = this.participants.Referee.GetTurnWinnerIndex();

            this.currentPlayerIndex = turnWinnerIndex;

            Console.WriteLine("Winner is player: " + this.currentPlayerIndex);
        }
    }
}
