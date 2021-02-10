using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Game
    {
        Player player;
        Oponent oponent;

        private ThrowManager throwManager;
        private ThrowObserver throwObserver;

        private TurnManager turnManager;
        private TurnObserver turnObserver;

        public Game()
        {
            this.throwManager = new ThrowManager();
            this.throwObserver = new ThrowObserver();

            this.throwManager.Attach(this.throwObserver);


            this.turnManager = new TurnManager();
            this.turnObserver = new TurnObserver();
            
            this.turnManager.Attach(throwObserver);
        }

        public void SetMyCard_PictureBoxes(List<PictureBox> pictureBoxesMyCards)
        {
            Hand myHand = new Hand();
            myHand.CreateHolders(pictureBoxesMyCards);
            this.player = new Player();
            this.player.SitToTable(myHand);
            this.player.SetThrowManager(this.throwManager);
        }

        public void SetOponentCard_PictureBoxes(List<PictureBox> pictureBoxesOponentsCards)
        {
            Hand oponentsHand = new Hand();
            oponentsHand.CreateHolders(pictureBoxesOponentsCards);

            this.oponent = new Oponent();
            this.oponent.SitToTable(oponentsHand);
            this.oponent.SetThrowManager(this.throwManager);

            this.throwObserver.SeatOponent(oponent);
        }

        public void SetCardsPlayed_PictureBoxes(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            this.throwManager.SetTable(pictureBox1, pictureBox2);
        }

        CardDealer dealer = CardDealer.Instance;

        public void DrawCard(GeneralPlayer player)
        {
            player.DrawCard(dealer.PullCard());
        }

        Adut adut;

        public void SetAdut_PictureBox(PictureBox pictureBox)
        {
            this.adut = Adut.CreateHolder(pictureBox);
        }

        public void Deal()
        {
            dealer.Shuffle();
            player.ClearHand();
            oponent.ClearHand();

            adut.PlaceCard(dealer.PullCard());
            for(int i=0; i<5; i++)
            {
                DrawCard(player);
                DrawCard(oponent);
            }
        }

        public void Play(PictureBox sender)
        {
            this.player.PlayCard(sender);

            //throwManager.Play();
        }


    }
}
