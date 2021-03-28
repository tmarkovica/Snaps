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

        public int Points
        {
            get;
            private set;
        }

        public Referee() 
        { 
            this.tableCardholders = new List<ICollectable>();
        }

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
            }

            return cards;
        }

        private void CollectPoints(List<Card> cards)
        {
            int points = 0;
            foreach (Card card in cards)
                points += card.GetCardValue();

            this.Points = points;
        }

        public int GetTurnWinnerIndex()
        {
            List<Card> cards = CollectCards();

            this.CollectPoints(cards);

            
            Console.WriteLine("/////////:");
            foreach (Card c in cards)
                Console.WriteLine("-- " + c.GetCardImageName());

            if (this.StartingPlayerIndex == 0)
            {
                if (NormalGameLogic.IsFirstCardWinner(cards[0], cards[1])) // tu nezna ko igra prvi, a ko drugi
                    return 0;
                else
                    return 1;
            }
            else //if (this.StartingPlayerIndex == 1)
            {
                if (NormalGameLogic.IsFirstCardWinner(cards[1], cards[0]))
                    return 1;
                else
                    return 0;
            }

            


        }
        public bool GameClosed
        {
            get;
            set;
        }

        public void CloseGame() 
        {
            this.GameClosed = true;
        }

        public void GameStarts()
        {
            //this.gameLogic = new NormalGameLogic(AdutColor.GetColor());
        }

        public int StartingPlayerIndex
        {
            get;
            set;
        }
    }
}
