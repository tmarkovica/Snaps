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

        override public void YourTurnToPLayFirst(Label label)
        {          
            label.Text = "Oponents turn";
            label.BackColor = System.Drawing.Color.Red;
            
            this.throwingFirst = true;

            EnoughPoints();

            Card tempCard = this.oponentAI.StartingCard();

            Call(tempCard);

            base.PlayCard(tempCard);
        }

        override public void UpdateAboutOponentsCard(Card card)
        {
            if (this.throwingFirst == false)
                base.PlayCard(this.oponentAI.CounterCard(card));

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
                    MessageBox.Show("Oponent won the round!");
                    base.EnoughPoints();
                }
        }

        public override void Call(Card card)
        {
            if (card.GetCardValue() == 3 || card.GetCardValue() == 4)
            {
                if (GetHand().CanCall(card))
                {
                    DialogResult dialogResult = MessageBox.Show("", "Protivnik ima zvanje");
                    if (card.GetCardColor() == AdutColor.GetColor())
                        AddPoints(40);
                    else
                        AddPoints(20);
                }
            }
        }
    }
}
