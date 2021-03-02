using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class RealPlayer : Player //, ITableObserver
    {
        public RealPlayer(Hand hand) : base(hand) { }

        public Card GetPlayedCard(PictureBox sender)
        {
            return GetHand().GetCardFrom(sender);
        }

        public void PlayCard(PictureBox sender)
        {
            Card card = GetPlayedCard(sender);
            Console.WriteLine("You played: " + card.GetCardImageName());

            //base.PlayCard(GetPlayedCard(sender)); //original
            base.PlayCard(card);

            GetHand().SetEnabled(false);
        }

        override public void YourTurnToPLay()
        {
            GetHand().MakeSelectionOfCardsThatAreAllowedToBePlayed(null);

            Console.WriteLine("override void YourTurnToPlay()");
        }

        override public void UpdateAboutOponentsCard(Card card)
        {
            Console.WriteLine("Oponent played: " + card.GetCardImageName() + " and it's oponents time to throw!");
        }
    }
}
