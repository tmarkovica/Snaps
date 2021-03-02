using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Šnaps
{
    class NormalGameLogic : GameLogic
    {
        public NormalGameLogic(string adutColor) : base(adutColor) { }

        override public bool IsFirstCardWinner(Card card1, Card card2)
        {
            if (IsCardAdut(card1))
            {
                if (IsCardAdut(card2))
                {
                    Console.WriteLine("Adut1 <> Adut2");
                    return IsFirstCardHigherValue(card1, card2);
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
                    if (AreCardsSameColor(card1, card2))
                    {
                        Console.WriteLine("Card1 <> Card2 - u istoj boji");
                        return IsFirstCardHigherValue(card1, card2);
                    }
                    else
                    {
                        Console.WriteLine("Card1 < Card2 - boje različite, myTurn = " + true);
                        return true;
                    }
                }
            }
        }

        override public bool IsFirstCardStronger(Card card1, Card card2)
        {
            List<Card> cards = new List<Card>() { card1, card2 };

            if (IsCardAdut(cards[0]))
                if (IsCardAdut(cards[1]))
                    return IsFirstCardHigherValue(card1, card2);
                else
                    return true;
            else
                if (IsCardAdut(card2))
                    return false;
                else
                        if (AreCardsSameColor(card1, card2))
                    return IsFirstCardHigherValue(card1, card2);
                else
                    return false;
        }
    }
}
