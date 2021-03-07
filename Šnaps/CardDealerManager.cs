using System;
using System.Drawing;
using System.Windows.Forms;

namespace Šnaps
{
    class CardDealerManager : CardDealer
    {
        private DeckControl deckControl;
        private AdutControl adutControl;

        public CardDealerManager(DeckControl deckControl, AdutControl adut) : base() 
        {
            this.deckControl = deckControl;
            this.adutControl = adut;
        }

        // CardDealer
        override public Card PullCard()
        {
            Card card = base.PullCard();

            if (base.IsOutOfCards())
            {
                OutOfCards();
            }

            if (card != null)
                return card;

            return adutControl.PullCard();
        }

        public override void Shuffle()
        {
            this.ResetControls();
            base.Shuffle();
            this.adutControl.PlaceCard(base.PullCard());
        }

        //
        private void ResetControls()
        {
            this.deckControl.ResetControls();
            this.adutControl.ResetControls();
        }

        private void OutOfCards()
        {
            this.deckControl.OutOfCards();
        }

        public void CloseGame()
        {
            this.deckControl.CloseGame();
            this.adutControl.CloseGame();
        }

        //
        private void SwapCards(IStorageable holder1, IStorageable holder2)
        {
            Card tempCard = holder1.TakeCard();
            holder1.PlaceCard(holder2.TakeCard());
            holder2.PlaceCard(tempCard);
        }

        public void ExchangeAdut(IStorageable hand)
        {
            this.SwapCards(hand, adutControl);
            MessageBox.Show("Adut je zamijenjen");
        }
    }
}
