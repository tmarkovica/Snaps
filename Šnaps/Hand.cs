using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Hand : CardStorage
    {
        private int score = 0;

        public int GetScore() { return score; }

        public void AddPoints(int points) { score += points; }

        //*************

        public Card PullPlayedCard(PictureBox sender)
        {
            List<CardHolder> cardsHolder = base.GetCardStorage();

            foreach (CardHolder holder in cardsHolder)
            {
                if (holder.IsSenderMatchingTheHolder(sender))
                {
                    return holder.TakeCard();
                }
            }

            return null;
        }

        public void RemoveCardFromHolder(Card card)
        {
            List<CardHolder> cardsHolder = base.GetCardStorage();

            foreach (CardHolder holder in cardsHolder)
            {
                holder.RemoveThisCardFromHolder(card);
            }
        }

        public List<Card> GetCardsInHand()
        {
            List<Card> cards = new List<Card>();

            List<CardHolder> cardsHolder = base.GetCardStorage();

            foreach (CardHolder holder in cardsHolder)
            {
                cards.Add(holder.TakeCard());
            }

            return cards;
        }
    }
}
