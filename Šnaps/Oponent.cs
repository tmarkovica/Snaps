using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Oponent : Player//, ITableObserver//, ITurnStartingPlayer
    {
        public Oponent(Hand hand) : base(hand) { }

        override public void UpdateAboutOponentsCard(Card card)
        {
            Console.WriteLine("Player played: " + card.GetCardImageName() + " and it's oponents time to throw!");

            //base.PlayCard()
        }

        public Card GetPlayedCard(PictureBox sender) // samo za testiranje
        {
            return GetHand().GetCardFrom(sender);
        }

        public void PlayCard(PictureBox sender) // samo za testiranje
        {
            base.PlayCard(GetPlayedCard(sender));
        }

        override public void YourTurnToPLay()
        {
            
        }
    }
}
