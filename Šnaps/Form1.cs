using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Hand myHand = GetHand(pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5);
            Hand oponentsHand = GetHand(pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10);


            this.player = new RealPlayer(myHand);
            this.oponent = new Oponent(oponentsHand);

            this.referee = new Referee();

            this.player.SeatPlayer(this.referee.GetPlayerHisSeat(pictureBoxMyPlayedCard));
            oponent.SeatPlayer(this.referee.GetPlayerHisSeat(pictureBoxOponentsPlayedCard));


            Participants participants = new Participants();
            participants.Add(this.player);
            participants.Add(oponent);

            participants.Referee = referee;

            this.game = new Game(participants);

            SetControls();

            this.game.Start();
        }

        RealPlayer player;
        Oponent oponent;

        Referee referee;

        private Hand GetHand(PictureBox pb1, PictureBox pb2, PictureBox pb3, PictureBox pb4, PictureBox pb5)
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>() { pb1, pb2, pb3, pb4, pb5 };
            return new Hand(pictureBoxes);
        }

        public void SetControls()
        {
            this.game.SetAdut_PictureBox(pictureBoxAdut, pictureBoxAdutColor);
            this.game.SetTurnLabel(labelTurn);
        }

        Game game;

        private bool movingEnabled = false;
        private int moveX, moveY;
        private Point startingPoint;
        private PictureBox pictureBox;

        private void MouseDown_PlayCard(object sender, MouseEventArgs e)
        {
            movingEnabled = true;

            moveX = e.X;
            moveY = e.Y;

            pictureBox = sender as PictureBox;
            startingPoint = new Point(pictureBox.Location.X, pictureBox.Location.Y);
        }

        private void MouseMove_PlayCard(object sender, MouseEventArgs e)
        {
            if (movingEnabled)
            {
                //pictureBox.Location = new Point(MousePosition.X - 23 - moveX - this.Left, MousePosition.Y - 46 - moveY - this.Top);
                pictureBox.Location = new Point(MousePosition.X - 9 - moveX - this.Left, MousePosition.Y - 32 - moveY - this.Top);
            }
        }

        private void TransferImage(PictureBox sender)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (pictureBoxMyPlayedCard.Location.X < MousePosition.X && pictureBoxMyPlayedCard.Location.X + pictureBoxMyPlayedCard.Size.Width > MousePosition.X)
                {
                    // 23px je visina ruba prozora
                    if (pictureBoxMyPlayedCard.Location.Y + 23 < MousePosition.Y && pictureBoxMyPlayedCard.Location.Y + 23 + pictureBoxMyPlayedCard.Size.Height > MousePosition.Y)
                    {
                        //pictureBoxMyPlayedCard.Image = pictureBox.Image;

                        //this.game.Play(sender as PictureBox);

                        this.player.PlayCard(sender as PictureBox); //not yet implemented
                    }
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                if (pictureBoxMyPlayedCard.Location.X + this.Left < MousePosition.X && pictureBoxMyPlayedCard.Location.X + this.Left + pictureBoxMyPlayedCard.Size.Width > MousePosition.X)
                {
                    // 31 px je visina ruba prozora kad forma nije full screen
                    if (pictureBoxMyPlayedCard.Location.Y + 31 + this.Top < MousePosition.Y && pictureBoxMyPlayedCard.Location.Y + 31 + this.Top + pictureBoxMyPlayedCard.Size.Height > MousePosition.Y)
                    {
                        //pictureBoxMyPlayedCard.Image = pictureBox.Image;
                        //this.game.Play(sender as PictureBox);

                        this.player.PlayCard(sender as PictureBox); //not yet implemented
                    }
                }
            }
        }

        private void ExchangeAdut(object sender, EventArgs e)
        {
            //this.player.ExchangeAdut(sender as PictureBox); //not yet implemented
        }

        private void MouseUp_PlayCard(object sender, MouseEventArgs e)
        {
            movingEnabled = false;


            TransferImage(sender as PictureBox);

            pictureBox.Location = startingPoint;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("MousePosition: " + MousePosition);
        }

        private void MouseDoubleClick_PlayCard(object sender, MouseEventArgs e)
        {
            //this.game.Play(sender as PictureBox);

            this.player.PlayCard(sender as PictureBox);
        }
        
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void pictureBox10_MouseDoubleClick(object sender, MouseEventArgs e) // samo za testiranje
        {
            this.oponent.PlayCard(sender as PictureBox);
        }
    }
}
