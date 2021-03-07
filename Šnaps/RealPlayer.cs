using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class RealPlayer : Player
    {
        public RealPlayer(Hand hand) : base(hand) { }

        private Card GetCardFromSender(PictureBox sender)
        {
            return GetHand().GetCardFrom(sender);
        }

        public void PlayCard(PictureBox sender)
        {
            this.cardThrown = true;

            GetHand().SetHandEnabled(false);

            base.PlayCard(GetCardFromSender(sender));
        }

        bool throwingFirst = false;
        bool cardThrown = false;


        override public void YourTurnToPLay(Label label)
        {
            //GetHand().MakeSelectionOfCardsThatAreAllowedToBePlayed(null);
            GetHand().SetHandEnabled(true);

            label.Text = "Your turn";
            label.BackColor = System.Drawing.Color.LightBlue;

            

            this.throwingFirst = true;
            this.cardThrown = false;

            Console.WriteLine("override void YourTurnToPlay() : throwingFirst = " + this.throwingFirst);
        }

        override public void UpdateAboutOponentsCard(Card card)
        {
            if (throwingFirst == false) // if I throw second I have to respond to his played card
            {
                Console.WriteLine("Oponent played: " + card.GetCardImageName() + " and it's Your time to throw!");
                GetHand().MakeSelectionOfCardsThatAreAllowedToBePlayed(card); // samo za sada je null, promijeniti!!!
            }

            throwingFirst = false;
        }

        private Label labelScore;

        public void SetScoreLabel(Label label)
        {
            this.labelScore = label;
        }

        override public void AddPoints(int points)
        {
            base.AddPoints(points);
            this.labelScore.Text = base.Score.ToString();
        }

        override public void EnoughPoints()
        {
            if (throwingFirst == true)
                if (base.Score >= 66)
                {
                    MessageBox.Show("You won the round!");
                    base.EnoughPoints();
                }
        }
        
        override public void ExchangeAdut()
        {
            if (throwingFirst == true)
                if (this.cardThrown == false)
                    base.ExchangeAdut();
        }

        override public void CloseGame() 
        {
            if (throwingFirst == true)
                if (this.cardThrown == false)
                    base.CloseGame();
        }
    }
}
