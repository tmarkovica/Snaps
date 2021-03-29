using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class OponentsHand : Hand
    {
        private List<PictureBox> pictureBoxes;

        public OponentsHand(List<PictureBox> pictureBoxes) : base(pictureBoxes) 
        {
            this.pictureBoxes = new List<PictureBox>();
            this.pictureBoxes = pictureBoxes;
        }

        private Card GetCard(int index)
        {
            Card temp = base.TakeCardFrom(pictureBoxes[index]);
            if (temp != null)
                base.AddCard(temp);
            return temp;
        }

        private Card TakeCardFrom(int index)
        {
            Console.WriteLine("------------------------------- Card taken: " + GetCard(index).GetCardImageName());
            return base.TakeCardFrom(pictureBoxes[index]);
        }

        private List<Card> CollectCards()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                Card card = base.TakeCardFrom(pictureBoxes[i]);
                if (card != null)
                    cards.Add(card);
            }
            return cards;
        }

        private void AddRestOfTheCard(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
                if (cards[i] != null)
                    base.AddCard(cards[i]);
        }

        private Card SeparateCardFromHandAtIndex(List<Card> cards, int index)
        {
            Card card = null;
            if (cards.Count > 0)
            {
                card = cards.ElementAt(index);
                cards.RemoveAt(index);

                this.AddRestOfTheCard(cards);
            }
            
            return card;
        }

        public Card StartingCard()
        {
            List<Card> cards = this.CollectCards();

            Card callingCard = FindCallingCard(cards);

            if (callingCard == null)
                return SeparateCardFromHandAtIndex(cards, GetIndexFrom_OfCard(cards, WeakestCardFrom(cards)));
            else
                return SeparateCardFromHandAtIndex(cards, GetIndexFrom_OfCard(cards, callingCard));
        }

        public Card CounterCard(Card card)
        {
            List<Card> cards = this.CollectCards();

            List<Card> strongerCards = new List<Card>();

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i] != null)
                    if (NormalGameLogic.IsFirstCardWinner(card, cards[i]) == false)
                    {
                        strongerCards.Add(cards[i]);
                    }
            }

            if (strongerCards.Count > 0) // win
            {
                return SeparateCardFromHandAtIndex(cards, GetIndexFrom_OfCard(cards, WeakestCardFrom(strongerCards)));
            }
            else // lose
            {
                return SeparateCardFromHandAtIndex(cards, GetIndexFrom_OfCard(cards, WeakestCardFrom(cards)));
            }
        }

        private Card WeakestCardFrom(List<Card> cards)
        {
            Card weakestCard = cards[0];

            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i] != null)
                    if (GameLogic.IsCardAdut(cards[i]) == false)
                    {
                        if (GameLogic.IsFirstCardHigherValue(weakestCard, cards[i]))
                        {
                            weakestCard = cards[i];
                        }
                    }
            }
            return weakestCard;
        }

        private int GetIndexFrom_OfCard(List<Card> cards, Card card)
        {
            int place = 0;
            for (int i = 0; i < cards.Count; i++)
                if (cards[i] == card)
                    place = i;
            return place;
        }

        private Card FindCallingCard(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i] != null)
                {
                    if (cards[i].GetCardValue() == 4)
                    {
                        for (int j = 0; j < cards.Count; j++)
                            if (cards[j] != null)
                                if (cards[j].GetCardValue() == 3)
                                    if (GameLogic.AreCardsSameColor(cards[i], cards[j]))
                                        return cards[j];
                    }
                    else if (cards[i].GetCardValue() == 3)
                    {
                        for (int j = 0; j < cards.Count; j++)
                            if (cards[j] != null)
                                if (cards[j].GetCardValue() == 4)
                                    if (GameLogic.AreCardsSameColor(cards[i], cards[j]))
                                        return cards[j];
                    }
                }
            }
            return null;
        }
    }
}
