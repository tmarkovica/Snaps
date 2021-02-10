using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{

    class CardHolder
    {
        private PictureBox sender { get; set; }

        private Card card { get; set; }

        public CardHolder() { this.card = null; }

        public CardHolder(PictureBox sender)
        {
            this.sender = sender;
            this.card = null;
        }

        public void PlaceCard(Card card)
        {
            if (this.card == null)
            {
                this.card = card;
                SetImage();
            }
        }

        public void ClearHolder()
        {
            this.card = null;
            this.sender.Image = null;
        }

        public Card TakeCard()
        {
            Card temp = null;

            if (!IsHolderEmpty()) // this.card != null
            {
                temp = this.card;
                ClearHolder();
            }
            return temp;
        }

        public void SetImage()
        {
            if (this.card != null) 
            {
                this.sender.Image = this.card.GetImage();
                this.sender.Enabled = true;
                this.sender.Visible = true;
            }
            else
            {
                this.sender.Image = null;
                this.sender.Enabled = false;
                this.sender.Visible = false;
            }
        }

        public string GetCardName()
        {
            if (card == null)
                return "";
            return card.GetCardName();
        }

        public string GetCardColor()
        {
            if (card == null)
                return "";
            return card.GetCardColor();
        }

        public int GetCardValue()
        {
            if (card == null)
                return 0;
            return card.GetCardValue();
        }

        public Card GetCard() { return card; }

        public bool IsSenderMatchingTheHolder(PictureBox sender)
        {
            if (this.sender == sender)
                return true;
            else
                return false;
        }

        public bool IsHolderEmpty()
        {
            if (this.card == null)
                return true;
            else
                return false;
        }

        public void RemoveThisCardFromHolder(Card card) 
        {
            if (this.card == card)
            {
                this.card = null;
                SetImage();
            }
        }

    }
}
