using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Oponent : GeneralPlayer
    {
        private IOponentAI oponentAI;

        public Oponent() : base() { }

        public void SetAI(IOponentAI opnentAI)
        {
            this.oponentAI = oponentAI;
        }

        public void PlayCounterCard()
        {
            //base.PlayCard(this.oponentAI.PlayCard(GetHand(), GetGameMechanism().GetCardOnTable()));
        }

        public void PlayCard() // protivnik baca prvi ovaj Turn
        {
            // prije nego zaigra možda ima dovoljno bodova za završiti igru
            if (HaveIColectedEnoughPoints())
            {
                MessageBox.Show("Winner: Protivnik");
                return;
            }
            else
            {
                base.ExchangeAdut();
                CloseGame();


                base.PlayCard(this.oponentAI.GetCardToPlay(GetHand()));
            }
        }

        public override void CloseGame()
        {
            if (CanICloseGame())
            {/*
                if (this.oponentAI.ShouldOponentCloseGame(GetHand()))
                {
                    base.CloseGame();
                }*/
            }
        }

        public bool CanICloseGame()
        {/*
            if (!GetGameMechanism().IsMyTurn())
                if (GetGameMechanism().IsGameClosed())
                    return true;*/
            return false;
        }
    }
}
