using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Oponent : Player
    {
        private OponentAI oponentAI;

        private bool throwingFirst = false;

        public Oponent(OponentsHand hand) : base(hand) { this.oponentAI = new OponentAI(hand); }

        public Oponent(OponentAI ai) : base(ai.GetHand()) { this.oponentAI = ai; }

        override public void YourTurnToPLay(Label label)
        {          
            label.Text = "Oponents turn";
            label.BackColor = System.Drawing.Color.Red;
            
            this.throwingFirst = true;

            // obrisati
            Card card = this.oponentAI.StartingCard();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Oponents plays: " + card.GetCardImageName());
            base.PlayCard(card);
            //

            //base.PlayCard(this.oponentAI.StartingCard());
        }

        override public void UpdateAboutOponentsCard(Card card)
        {
            if (this.throwingFirst == false)
                base.PlayCard(this.oponentAI.CounterCard(card));

            throwingFirst = false;
        }

        public Card GetPlayedCard(PictureBox sender) // samo za testiranje
        {
            return GetHand().TakeCardFrom(sender);
        }

        public void PlayCard(PictureBox sender) // samo za testiranje
        {
            base.PlayCard(GetPlayedCard(sender));
        }

        //---* ovo je samo za testiranje brisati posle
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
        //---*
    }
}
