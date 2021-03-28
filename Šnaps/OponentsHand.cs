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

        /*
        public void AddCard(Card card)
        {
            foreach (CardHolder holder in holders)
            {
                if (holder.IsHolderEmpty())
                {
                    holder.PlaceCard(card);
                    return;
                }
            }
        }
        public void ResetHand()
        {
            Console.WriteLine("-----------");
            foreach (CardHolder holder in holders)
            {
                holder.ClearHolder();
                holder.SetHolderVisible(false);
                Console.WriteLine(holder.GetHolderStats());
            }
            Console.WriteLine("-----------");
        }

        public CardHolder GetHolderOfAdutExchanger()
        {
            foreach (CardHolder holder in holders)
                if (String.Equals(holder.GetCardName(), "Dečko"))
                    if (String.Equals(holder.GetCardColor(), AdutColor.GetColor()))
                        return holder;
            return null;
        }*/

        //
        /*
        public Card GetCardFrom(PictureBox sender)
        {
            foreach (CardHolder holder in holders)
            {
                if (holder.IsSenderMatchingTheHolder(sender))
                {
                    Card card = holder.TakeCard();

                    holder.SetHolderVisible(false);

                    return card;
                }
            }
            return null;
        }*/

        private Card GetCard(int index) //ovaj pristup nevalja jer svaku kartu koju uzmem vratim na početak liste, a trebala bi ostati na svom mjestu
        {
            Card temp = base.TakeCardFrom(pictureBoxes[index]);
            if (temp != null)
                base.AddCard(temp);
            return temp;
        }

        private Card TakeCardFrom(int index) ////ovaj pristup nevalja jer svaku kartu koju uzmem vratim na početak liste, a trebala bi ostati na svom mjestu
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

        public Card CounterCard(Card card) 
        {
            List<Card> cards = this.CollectCards();

            int weakestCardIndex = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine("cards[" + i + "] = " + cards[i].GetCardImageName());

                //if (NormalGameLogic.IsFirstCardWinner(card, cards[i]) == false) // nezna ko igra prvi a ko drugi!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (NormalGameLogic.IsFirstCardWinner(cards[i], card) == true)
                {
                    Console.WriteLine("Exit 1");
                    return this.SeparateCardFromHandAtIndex(cards, i);
                }
                else if (GameLogic.IsCardAdut(cards[i]) == false)
                    if (GameLogic.IsFirstCardHigherValue(cards[weakestCardIndex], cards[i]))
                    {
                        Console.WriteLine("Exit 2");
                        weakestCardIndex = i;
                    }
            }

            return this.SeparateCardFromHandAtIndex(cards, weakestCardIndex);
        }

        public Card StartingCard()
        {
            List<Card> cards = this.CollectCards();

            for (int i = 0; i < cards.Count; i++)
                if (cards[i] != null)
                    return SeparateCardFromHandAtIndex(cards, 0);

            return null;
        }
    }
}
