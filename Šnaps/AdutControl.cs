using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class AdutControl : CardHolder//, IExchangable
    {
        private PictureBox label;
        
        private AdutColor adutColor;

        public AdutControl(PictureBox pictureBox, PictureBox label) : base(pictureBox) 
        { 
            this.label = label;
            
            this.adutColor = AdutColor.Instance;
        }

        private void SetAdutColor()
        {
            this.adutColor.SetColor(base.GetCardColor());
        }

        private void UpdateLabel()
        {
            label.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(GetCardColor());
        }

        private void SetAdutHolderWorking(bool state)
        {
            base.SetHolderVisible(state);
            base.SetHolderEnabled(state);
        }

        // CardHolder methods
        override public void PlaceCard(Card card)
        {
            base.PlaceCard(card);
            SetAdutColor();
            UpdateLabel();
            this.SetAdutHolderWorking(true);
        }

        public Card PullCard()
        {
            this.OutOfCards();
            return base.TakeCard();
        }

        //
        private void OutOfCards()
        {
            this.SetAdutHolderWorking(false);
        }

        public void CloseGame()
        {
            base.SetHolderEnabled(false);
        }

        public void ResetControls()
        {
            base.ClearHolder();
            this.SetAdutHolderWorking(true);
        }
    }
}
