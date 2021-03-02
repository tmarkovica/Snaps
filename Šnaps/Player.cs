using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class Player : ITableObserver// : IPlayerMechanics
    {
        IPlayerMechanics gameMechanism;

        ITableObservable tableCardHolder;

        Hand hand;

        public Player(Hand hand) { this.hand = hand; }

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
        }

        virtual public void UpdateAboutOponentsCard(Card card)
        {
            this.hand.MakeSelectionOfCardsThatAreAllowedToBePlayed(card);
        }

        public void DrawCard(Card card)
        {
            this.hand.AddCard(card);
        }

        public Hand GetHand() { return this.hand; }

        virtual public void YourTurnToPLay() { }
    }
}
