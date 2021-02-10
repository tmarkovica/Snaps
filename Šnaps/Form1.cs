using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            game = new Game();

            SetControls();

            game.Deal();
        }

        public void SetControls()
        {
            List<PictureBox> pictureBoxesMyCards = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            List<PictureBox> pictureBoxesOponentsCards = new List<PictureBox>() { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };

            this.game.SetMyCard_PictureBoxes(pictureBoxesMyCards);
            this.game.SetOponentCard_PictureBoxes(pictureBoxesOponentsCards);
            this.game.SetCardsPlayed_PictureBoxes(pictureBoxMyPlayedCard, pictureBoxOponentsPlayedCard);
            this.game.SetAdut_PictureBox(pictureBoxAdut);
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

                        this.game.Play(sender as PictureBox);
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
                        this.game.Play(sender as PictureBox);
                    }
                }
            }
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
            this.game.Play(sender as PictureBox);
        }
    }
}
