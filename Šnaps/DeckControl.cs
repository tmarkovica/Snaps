using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class DeckControl //: DeckOfCards
    {
        PictureBox pictureBoxDeck;
        Label labelClosedGame;

        public DeckControl(PictureBox pictureBoxDeck, Label labelClosedGame) : base()
        {
            this.pictureBoxDeck = pictureBoxDeck;
            this.labelClosedGame = labelClosedGame;

            this.pictureBoxDeck.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("zadnja_strana_classic");
        }

        //
        public void OutOfCards()
        {
            this.pictureBoxDeck.Visible = false;
        }

        public void CloseGame()
        {
            this.labelClosedGame.Visible = true;
            this.pictureBoxDeck.Enabled = false;
        }

        public void ResetControls()
        {
            this.pictureBoxDeck.Visible = true;
            this.pictureBoxDeck.Enabled = true;
            this.labelClosedGame.Visible = false;
        }
    }
}
