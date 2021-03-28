using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Šnaps
{
    class TurnManager
    {
        private Iterator iterator;

        private Referee referee;

        private IRoundObserver observer;

        public TurnManager(Iterator iterator, Referee referee)
        { 
            this.iterator = iterator;
            this.referee = referee;
        }

        public void SetReferee(Referee referee)
        {
            this.referee = referee;
        }

        public void IntroduceGameMechanicsToPlayers(GameMechanism gameMechanism)
        {
            this.observer = gameMechanism;

            for (int i = 0; i < this.iterator.NumberOfParticipants; i++)
            {
                iterator.StartingPlayer.ExplainGameMechanics(gameMechanism);

                List<ITableObserver> observers = new List<ITableObserver>(); // sve ostale igrače osim trenutnog u stavljam u listu

                for (int j = 0; j < this.iterator.NumberOfParticipants; j++)
                {
                    Player current = this.iterator.CurrentPlayer;

                    if (j != 0)
                        observers.Add(current);
                }
                iterator.CurrentPlayer.GreetOtherPlayers(observers);
            }
        }

        private int throwCounter = 0; // value 0 to participants.Count
        private int turnCounter = 0; // value 0 to 10; when 4 or less CanCloseGame, CanExchangeAdut; when 5 last cards to draw; 6 or more no more drawing cards

        Label labelTurn;
        public void SetTurnLabel(Label label) { this.labelTurn = label; }

        public bool HaveFourTurnsPassed()
        {
            if (this.turnCounter > 4)
                return true;
            else
                return false;
        }

        public void CloseGame()
        {
            this.referee.CloseGame();
            this.turnCounter = 5;
        }

        public void PlayersDraw()
        {
            for (int i = 0; i < this.iterator.NumberOfParticipants; i++)
                this.iterator.CurrentPlayer.DrawCard();
        }

        public void ResetPlayerHands()
        {
            for (int j = 0; j < this.iterator.NumberOfParticipants; j++)
                this.iterator.CurrentPlayer.ResetHand();
        }

        public void NewTurn()
        {
            this.turnCounter++;
            Console.WriteLine("******************************* turnCounter = " + this.turnCounter);

            if (this.throwCounter > 5) // when you run out of cards to draw
                this.referee.CloseGame();

            //this.referee.StartingPlayerIndex = this.currentPlayerIndex;

            //PlayersDraw();

            if (this.turnCounter <= 10)
                this.iterator.StartingPlayer.YourTurnToPLayFirst(labelTurn);
                //this.participants[this.currentPlayerIndex].YourTurnToPLay(labelTurn);
        }

        public void NewRound()
        {
            this.throwCounter = 0; // ovisno o pobjedniku
            this.turnCounter = 0;
            /*
            if (this.throwCounter == 0)
                this.participants.Referee.GameStarts();*/ // ako bude potrebno

            this.referee.GameClosed = false;

            //ResetPlayersHands();


            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("NEW ROUND OF SNAPS");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("-------------------------------------------------------------------------------");

            this.NewTurn();
        }

        private void DetermineTurnWinner()
        {
            this.referee.DetermineNextStartingPlayer(iterator);

            if (this.turnCounter < 10)
            {
                PlayersDraw();
                NewTurn();
            }
            else
            {
                //NewRound();

                observer.Update_RoundEnded();
            }    
        }

        public void PrepNextPlayer()
        {
            this.throwCounter++;

            if (this.iterator.IsCounted(this.throwCounter))
            {
                throwCounter = 0;
                DetermineTurnWinner();
            }
        }
    }
}
