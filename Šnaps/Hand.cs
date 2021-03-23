using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Hand
    {
        List<CardHolder> holders;

        public Hand(List<PictureBox> pictureBoxes) 
        {
            this.holders = new List<CardHolder>();
            foreach (PictureBox pictureBox in pictureBoxes)
                this.holders.Add(new CardHolder(pictureBox));
        }

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

        public Card TakeCardFrom(PictureBox sender)
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
        }

        public void MakeSelectionOfCardsThatAreAllowedToBePlayed(Card card)
        {
            if (card == null)
                SetHandEnabled(true);
            else
                SetHandEnabled(true); // implementirati !!!!!
        }

        public void SetHandEnabled(bool state)
        {
            foreach (CardHolder holder in holders)
            {
                holder.SetHolderEnabled(state);
            }
        }

        /*
        public void ClearHand()
        {
            Console.WriteLine("-----------");
            foreach (CardHolder holder in holders)
            {
                holder.ClearHolder();
                holder.SetHolderVisible(true);
                Console.WriteLine(holder.GetHolderStats());
            }
            Console.WriteLine("-----------");
        }
         * */

        public void ResetHand()
        {
            foreach (CardHolder holder in holders)
            {
                holder.ClearHolder();
                holder.SetHolderVisible(false);
            }
        }

        public CardHolder GetHolderOfAdutExchanger()
        {
            foreach (CardHolder holder in holders)
                if (String.Equals(holder.GetCardName(), "Dečko"))
                    if (String.Equals(holder.GetCardColor(), AdutColor.GetColor()))
                        return holder;
            return null;
        }
    }
}
