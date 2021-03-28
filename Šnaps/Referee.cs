using System;
using System.Collections.Generic;
using System.Drawing;
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
            int points = 0;
            foreach (ICollectable cardFromHolder in tableCardholders)
            {
                Card temp = cardFromHolder.PullCard();
                points += temp.GetCardValue();
                cards.Add(temp);
            }
            this.Points = points;
            return cards;
        }
        
        Form formDiscardPile = new Form();
        int lastX = 0;
        int lastY = 0;
        
        private void ShowDiscardPile(List<Card> cards)
        {
            formDiscardPile.Show();    

            foreach (Card card in cards)
            {
                Point lastPoint = new Point(lastX, lastY);

                var picture = new PictureBox
                {
                    Name = "pictureBox",
                    Size = new Size(128, 213),
                    Location = lastPoint,
                    Image = card.GetImage(),

                };
                formDiscardPile.Controls.Add(picture);

                lastX += 128;
            }

            lastX += 40;

            if (lastX >= 1280)
            {
                lastX = 0;
                lastY += 213 + 40;
            }
        }

        private int GetTurnWinnerIndex()
        {
            List<Card> cards = CollectCards();

            Console.WriteLine("/////////:");
            foreach (Card c in cards)
                Console.WriteLine("-- " + c.GetCardImageName());

            
            ShowDiscardPile(cards);


            if (GameClosed == false)
            {
                return FindTurnWinner_NormalGameLogic(cards);
            }
            else
            {
                return FindTurnWinner_ClosedGameLogic(cards);
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

        public int StartingPlayerIndex
        {
            get;
            private set;
        }

        public void DetermineNextStartingPlayer(Iterator iterator)
        {
            this.StartingPlayerIndex = GetTurnWinnerIndex();
            iterator.SetStartingPlayerByIndex(this.StartingPlayerIndex);
            iterator.StartingPlayer.AddPoints(Points);
        }

        private int FindTurnWinner_NormalGameLogic(List<Card> cards)
        {
            if (this.StartingPlayerIndex == 0)
            {
                if (NormalGameLogic.IsFirstCardWinner(cards[0], cards[1]))
                    return 0;
                else
                    return 1;
            }
            else
            {
                if (NormalGameLogic.IsFirstCardWinner(cards[1], cards[0]))
                    return 1;
                else
                    return 0;
            }
        }

        private int FindTurnWinner_ClosedGameLogic(List<Card> cards)
        {
            if (this.StartingPlayerIndex == 0)
            {
                if (ClosedGameLogic.IsFirstCardWinner(cards[0], cards[1]))
                    return 0;
                else
                    return 1;
            }
            else
            {
                if (ClosedGameLogic.IsFirstCardWinner(cards[1], cards[0]))
                    return 1;
                else
                    return 0;
            }
        }
    }
}
