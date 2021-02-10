using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{    
    class CardStorage : ICardStorage
    {
        private List<CardHolder> cardsHolder;

        public CardStorage()
        {
            this.cardsHolder = new List<CardHolder>();
        }

        public void CreateHolders(List<PictureBox> oponentsButtons)
        {
            foreach (PictureBox button in oponentsButtons)
            {
                cardsHolder.Add(new CardHolder(button));
            }
        }

        virtual public void PlaceNewCard(Card card)
        {
            foreach (CardHolder holder in cardsHolder)
            {
                if (holder.IsHolderEmpty())
                {
                    holder.PlaceCard(card);
                    break;
                }
            }
        }

        public void ClearStorage()
        {
            foreach (CardHolder holder in cardsHolder)
            {
                holder.SetImage();
            }
        }

        public List<CardHolder> GetCardStorage()
        {
            return cardsHolder;
        }
    }
}
