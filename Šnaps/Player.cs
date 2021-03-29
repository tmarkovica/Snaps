using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Player : ITableObserver, IRoundStart
    {
        IPlayerMechanics gameMechanism;

        ITableObservable tableCardHolder;

        Hand hand;

        public Player(Hand hand) 
        {
            this.hand = hand;
            this.Score = 0;
        }

        public void ExplainGameMechanics(IPlayerMechanics mechanics) { this.gameMechanism = mechanics; }

        public void SeatPlayer(ITableObservable holder) { this.tableCardHolder = holder; }

        public void GreetOtherPlayers(List<ITableObserver> observers)
        {
            foreach (ITableObserver observer in observers)
                this.tableCardHolder.Attach(observer);
        }

        public void PlayCard(Card card)
        {
            this.tableCardHolder.PlaceCard(card);
            this.gameMechanism.PrepNextPlayer();
        }

        virtual public void UpdateAboutOponentsCard(Card card)
        {
            //this.hand.MakeSelectionOfCardsThatAreAllowedToBePlayed(card);
        }

        public void DrawCard(Card card)
        {
            this.hand.AddCard(card);
        }

        public void DrawCard()
        {
            this.hand.AddCard(this.gameMechanism.GetCardFromDealer());
        }

        public Hand GetHand() { return this.hand; }

        virtual public void YourTurnToPLayFirst(Label label) {   }

        // Score
        public int Score
        {
            get;
            private set;
        }
        
        virtual public void AddPoints(int points)
        {
            this.Score += points;
        }

        virtual public void EnoughPoints()
        {
            this.gameMechanism.EnoughPoints();
        }

        public void ResetHand() 
        { 
            this.hand.ResetHand(); 
        }

        virtual public void ExchangeAdut()
        {
            this.gameMechanism.ExchangeAdut(this.hand.GetHolderOfAdutExchanger());
        }

        virtual public void CloseGame()
        {
            this.gameMechanism.CloseGame();
        }

        virtual public void Call(Card card) {}

        virtual public void RoundStart()
        {
            this.Score = 0;
        }
    }
}
