using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Referee
    {
        List<ICollectable> tableCardholders;

        public Referee() { this.tableCardholders = new List<ICollectable>(); }

        public TableCardHolder GetPlayerHisSeat(PictureBox pictureBox)
        {
            TableCardHolder temp = new TableCardHolder(pictureBox);
            this.tableCardholders.Add(temp);
            return temp;
        }

        private List<Card> CollectCards()
        {
            List<Card> cards = new List<Card>();
            foreach (ICollectable cardFromHolder in tableCardholders)
            { 
                cards.Add(cardFromHolder.PullCard());
                Console.WriteLine(cards[0].GetCardImageName() + " vs " + cards[1].GetCardImageName());
            }
 
            return cards;
        }

        public int GetTurnWinnerIndex()
        {
            List<Card> cards = CollectCards();

            NormalGameLogic ngm = new NormalGameLogic(Adut.GetAdutColor());

            Console.WriteLine("We are comparing: " + cards[0].GetCardImageName() + " vs " + cards[1].GetCardImageName());

            if (ngm.IsFirstCardWinner(cards[0], cards[1]))
                return 0;
            else
                return 1;
        }
    }
}
