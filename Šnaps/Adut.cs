using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Adut : CardHolder
    {
        private static Adut instance = null;

        private PictureBox label;
        private Adut(PictureBox pictureBox, PictureBox label) : base(pictureBox) { this.label = label; }

        public static void CreateHolder(PictureBox pictureBox, PictureBox label)
        {
            if (instance == null)
                instance = new Adut(pictureBox, label);
        }

        public static Adut GetInstance() { return instance; }

        public static string GetAdutColor()
        {
            return instance.GetCardColor();
        }

        private void UpdateLabel()
        {
            label.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(instance.GetCardColor());
        }

        override public void PlaceCard(Card card)
        {
            base.PlaceCard(card);

            UpdateLabel();
        }

        public Card PullCard()
        {
            return base.TakeCard();
        }
    }
}
