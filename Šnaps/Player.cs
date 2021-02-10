using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Player : GeneralPlayer
    {
        public Player() : base() {  }

        public Card GetPlayedCard(PictureBox sender)
        {
            return GetHand().PullPlayedCard(sender);
        }

        public void PlayCard(PictureBox sender)
        {
            base.PlayCard(GetPlayedCard(sender));
        }
    }
}
