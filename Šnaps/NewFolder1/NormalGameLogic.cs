using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Šnaps
{
    class NormalGameLogic : IGameLogic
    {
        string adutColor = "";
        public bool myTurn { get; set; }

        public NormalGameLogic() { }

        public NormalGameLogic(string adutColor)
        {
            this.adutColor = adutColor;
        }

        public bool IsFirstCardWinner(Card card1, Card card2)
        {
            if (IsCardAdut(card1))
            {
                if (IsCardAdut(card2))
                {
                    Console.WriteLine("Adut1 <> Adut2");
                    return CompareCardValues(card1, card2);
                }
                else
                {
                    Console.WriteLine("Adut1 > Card2");
                    return true;
                }
            }
            else
            {
                if (IsCardAdut(card2))
                {
                    Console.WriteLine("Card1 < Adut2");
                    return false;
                }
                else
                {
                    if (CompareCardColors(card1, card2))
                    {
                        Console.WriteLine("Card1 <> Card2 - u istoj boji");
                        return CompareCardValues(card1, card2);
                    }
                    else
                    {
                        Console.WriteLine("Card1 < Card2 - boje različite, myTurn = " + myTurn);
                        return myTurn;
                    }
                }
            }
        }

        public bool IsFirstCardStronger(Card card1, Card card2)
        {
            List<Card> cards = new List<Card>() { card1, card2 };


            if (IsCardAdut(cards[0]))
            {
                if (IsCardAdut(cards[1]))
                {
                    return CompareCardValues(card1, card2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (IsCardAdut(card2))
                {
                    return false;
                }
                else
                {
                    if (CompareCardColors(card1, card2))
                    {
                        return CompareCardValues(card1, card2);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool IsCardAdut(Card card)
        {
            if (card == null) return false;
            if (String.Equals(card.GetCardColor(), adutColor))
                return true;
            else
                return false;
        }

        public bool CompareCardColors(Card card1, Card card2)
        {
            if (String.Equals(card1.GetCardColor(), card2.GetCardColor()))
                return true;
            else 
                return false;
        }

        public bool CompareCardValues(Card card1, Card card2)
        {
            if (card1.GetCardValue() > card2.GetCardValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
