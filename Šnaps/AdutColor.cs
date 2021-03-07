using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class AdutColor
    {
        private static AdutColor instance = null;

        private AdutColor() { }

        private static object syncLock = new object();

        public static AdutColor Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (AdutColor.instance == null)
                        AdutColor.instance = new AdutColor();

                    return AdutColor.instance;
                }
            }
        }

        private string color = "";

        public void SetColor(string color) { this.color = color; }

        public static string GetColor()
        {
            return instance.color;
        }
    }
}
