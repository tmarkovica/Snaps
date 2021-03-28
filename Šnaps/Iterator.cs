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

        private int throwCounter; // value 0 to participants.Count

        private int turnCounter; // value 0 to 10; when 4 or less CanCloseGame, CanExchangeAdut; when 5 last cards to draw; 6 or more no more drawing cards

        public Iterator(Participants participants)
        {
            this.participants = participants;
            this.currentPlayerIndex = 0;
            this.throwCounter = 0;
            this.turnCounter = 0;
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

        Label labelTurn;

        public void SetTurnLabel(Label label) { this.labelTurn = label; }

        public void CloseGame()
        {
            this.participants.Referee.CloseGame();
        }

        public bool HaveFourTurnsPassed()
        {
            if (this.turnCounter > 4)
                return true;
            else
                return false;
        }

        public void PlayersDraw()
        {
            int i = this.currentPlayerIndex;
            do
            {
                this.CurrentPlayer.DrawCard();
            } while (i != this.currentPlayerIndex);
        }

        public void NewTurn()
        {
            this.turnCounter++;
            Console.WriteLine("******************************* turnCounter = " + this.turnCounter);
            
            if (this.throwCounter > 5) // when you run out of cards to draw
                this.participants.Referee.CloseGame();

            this.participants.Referee.StartingPlayerIndex = this.currentPlayerIndex;

            PlayersDraw();

            if (this.turnCounter < 10)
                this.participants[this.currentPlayerIndex].YourTurnToPLay(labelTurn);
        }

        public void NewRound()
        {
            this.throwCounter = 0; // ovisno o pobjedniku
            this.turnCounter = 0;
            /*
            if (this.throwCounter == 0)
                this.participants.Referee.GameStarts();*/ // ako bude potrebno

            this.participants.Referee.GameClosed = false;

            ResetPlayersHands();
            

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("NEW ROUND OF SNAPS");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("-------------------------------------------------------------------------------");

            this.NewTurn();
        }

        private void DetermineTurnWinner()
        {
            int tempCurrent = this.currentPlayerIndex;

            int turnWinnerIndex = this.participants.Referee.GetTurnWinnerIndex();

            participants[turnWinnerIndex].AddPoints(this.participants.Referee.Points);

            this.currentPlayerIndex = turnWinnerIndex;

            Console.WriteLine("Winner is player: " + this.currentPlayerIndex);

            if (this.turnCounter < 9)
                NewTurn();
            else
                NewRound();
        }

        public void ResetPlayersHands()
        {
            for (int j = 0; j < this.NumberOfParticipants; j++)
                this.CurrentPlayer.ResetHand();
        }
    }
}
