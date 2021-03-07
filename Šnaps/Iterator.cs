using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Iterator
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
                Player player = this.participants[currentPlayerIndex];

                this.currentPlayerIndex++;
                if (IsCounted(this.currentPlayerIndex))
                    this.currentPlayerIndex = 0;

                return player;
            }
        }

        public void PrepNextPlayer()
        {
            this.throwCounter++;

            if (IsCounted(this.throwCounter))
            {
                throwCounter = 0;
                DetermineTurnWinner();
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

            participants[turnWinnerIndex].AddPoints(this.participants.Referee.Points);

            this.currentPlayerIndex = turnWinnerIndex;

            Console.WriteLine("Winner is player: " + this.currentPlayerIndex);

            StartNewTurn();
        }

        public void StartNewTurn()
        {
            Console.WriteLine("******************************* throwCounter = " + this.throwCounter);
            if (this.throwCounter == 0)
                this.participants.Referee.GameStarts();
            else if (this.throwCounter > 5) // when you run out of cards to draw
                this.participants.Referee.CloseGame();


            int i = this.currentPlayerIndex;

            this.CurrentPlayer.DrawCard();

            while (i != this.currentPlayerIndex)
            {
                this.CurrentPlayer.DrawCard();
            }

            this.participants[i].YourTurnToPLay(labelTurn);
        }

        public void NewRound()
        {
            this.throwCounter = 0;

            this.participants.Referee.GameClosed = false;

            //this.StartNewTurn(); // kod ispod umjesto ove linije
            Console.WriteLine("******************************* throwCounter = " + this.throwCounter);
            if (this.throwCounter == 0)
                this.participants.Referee.GameStarts();
            else if (this.throwCounter > 5) // when you run out of cards to draw
                this.participants.Referee.CloseGame();


            int i = this.currentPlayerIndex;

            while (i != this.currentPlayerIndex)
            {
                this.CurrentPlayer.DrawCard();
            }

            this.participants[i].YourTurnToPLay(labelTurn);
        }

        Label labelTurn;

        public void SetTurnLabel(Label label) { this.labelTurn = label; }

        public void CloseGame()
        {
            this.participants.Referee.CloseGame();
        }

        public bool HaveFourTurnsPassed()
        {
            if (this.throwCounter > 4)
            {
                return true;
            }
            else
                return false;
        }
    }
}
