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

        }

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
                pictureBox.Location = new Point(MousePosition.X - 23 - moveX - this.Left, MousePosition.Y - 46 - moveX - this.Top);
            }
        }

        private void MouseUp_PlayCard(object sender, MouseEventArgs e)
        {
            movingEnabled = false;

            PictureBox pb = sender as PictureBox;

            if (pictureBoxMyPlayedCard.Location.X < MousePosition.X && pictureBoxMyPlayedCard.Location.X + pictureBoxMyPlayedCard.Size.Width > MousePosition.X)
            {
                if (pictureBoxMyPlayedCard.Location.Y + 31 < MousePosition.Y && pictureBoxMyPlayedCard.Location.Y + pictureBoxMyPlayedCard.Size.Height + 31 > MousePosition.Y)
                {
                    pictureBoxMyPlayedCard.Image = pictureBox.Image;
                    //pb.Image = null;
                }
            }
            else
                pictureBox.Location = startingPoint;
        }

        private void MouseDoubleClick_PlayCard(object sender, MouseEventArgs e)
        {

        }
    }
}
