﻿using System;
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
            return GetHand().TakeCardFrom(sender);
        }

        public void PlayCard(PictureBox sender)
        {
            this.cardThrown = true;

            GetHand().SetHandEnabled(false);

            base.PlayCard(GetCardFromSender(sender));
        }

        bool throwingFirst = false;
        bool cardThrown = false;


        override public void YourTurnToPLayFirst(Label label)
        {
            //GetHand().MakeSelectionOfCardsThatAreAllowedToBePlayed(null);
            GetHand().SetHandEnabled(true);

            label.Text = "Your turn";
            label.BackColor = System.Drawing.Color.LightBlue;

            //Call(tempCard);

            this.throwingFirst = true;
            this.cardThrown = false;
        }

        override public void UpdateAboutOponentsCard(Card card)
        {
            if (throwingFirst == false) // if I throw second I have to respond to his played card
            {
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

        public override void Call(Card card)
        {
            if (card.GetCardValue() == 3 || card.GetCardValue() == 4)
            {
                if (GetHand().CanCall(card))
                {
                    DialogResult dialogResult = MessageBox.Show("", "Želite li zvati?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (card.GetCardColor() == AdutColor.GetColor())
                            AddPoints(40);
                        else
                            AddPoints(20);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        override public void RoundStart()
        {
            base.RoundStart();
            AddPoints(0);
        }
    }
}
