using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Adut : CardHolder
    {
        private static Adut instance = null;
        private Adut(PictureBox pictureBox) : base(pictureBox) { }

        public static Adut CreateHolder(PictureBox pictureBox)
        {
            if (instance == null)
                instance = new Adut(pictureBox);

            return instance;
        }

        public static Adut GetAdut() { return instance; }

        public static string GetAdutColor()
        {
            return instance.GetCardColor();
        }
    }
}
