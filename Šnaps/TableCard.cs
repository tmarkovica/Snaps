using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class TableCard : ICardStorage
    {
        private CardHolder cardHolder;

        public void CreateHolder(PictureBox pictureBoxe)
        {
            cardHolder = new CardHolder(pictureBoxe);
        }

        public void ClearStorage()
        {
            cardHolder.PlaceCard(null);
        }

        public void PlaceNewCard(Card card) { cardHolder.PlaceCard(card); }
    }
}
