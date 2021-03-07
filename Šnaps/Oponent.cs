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
        public Oponent(Hand hand) : base(hand) { }

        override public void UpdateAboutOponentsCard(Card card)
        {
            
        }

        public Card GetPlayedCard(PictureBox sender) // samo za testiranje
        {
            return GetHand().GetCardFrom(sender);
        }

        public void PlayCard(PictureBox sender) // samo za testiranje
        {
            base.PlayCard(GetPlayedCard(sender));
        }

        override public void YourTurnToPLay(Label label)
        {
            label.Text = "Oponents turn";
            label.BackColor = System.Drawing.Color.Red;
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
