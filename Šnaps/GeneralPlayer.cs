using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class GeneralPlayer
    {
        private Hand hand;

        private ThrowManager throwManager;

        public GeneralPlayer() { }

        public void SitToTable(Hand hand)
        {
            this.hand = hand;
        }

        public void SetThrowManager(ThrowManager throwManager) { this.throwManager = throwManager; }

        public void DrawCard(Card card)
        {
            this.hand.PlaceNewCard(card);
        }

        public void ClearHand()
        {
            this.hand.ClearStorage();
        }

        public void PlayCard(Card card)
        {
            this.throwManager.Play(card);

            this.hand.RemoveCardFromHolder(card);
        }

        public void AddPoints(int points)
        {
            this.hand.AddPoints(points);
        }

        public int GetScore()
        {
            return this.hand.GetScore();
        }

        public Hand GetHand() { return this.hand; }

        public void ExchangeAdut()
        {
            
        }

        public bool HaveIColectedEnoughPoints()
        {
            if (hand.GetScore() >= 66)
                return true;
            else
                return false;
        }

        virtual public void CloseGame()
        {

        }
    }
}
