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

        /*public void CreateHolders(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
                this.holders.Add(new CardHolder(pictureBox));
        }*/

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

        public Card GetCardFrom(PictureBox sender)
        {
            foreach (CardHolder holder in holders)
            {
                if (holder.IsSenderMatchingTheHolder(sender))
                {
                    return holder.TakeCard();
                }
            }
            return null;
        }

        public void MakeSelectionOfCardsThatAreAllowedToBePlayed(Card card)
        {
            if (card == null)
                foreach (CardHolder holder in holders)
                    holder.SetHolderEnabled(true);
        }

        public void SetEnabled(bool state)
        {
            foreach (CardHolder holder in holders)
            {
                holder.SetHolderEnabled(state);
            }
        }
    }
}
