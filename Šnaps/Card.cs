using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;

namespace Šnaps
{
    class Card : ResourceManager
    {
        private string cardColor;
        private string cardName;
        private int cardValue;

        public Card(string color, string name, int value)
        {
            this.cardColor = color;
            this.cardName = name;
            this.cardValue = value;
        }

        public string GetCardColor() { return cardColor; }

        public string GetCardName() { return cardName; }

        public int GetCardValue() { return cardValue; }

        public string GetCardImageName()
        {
            return cardName + "_" + cardColor;
        }

        public Bitmap GetImage()
        {
            return (Bitmap)GetObject(GetCardImageName());
        }

        public override object GetObject(string name)
        {
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
        }
    }
}
