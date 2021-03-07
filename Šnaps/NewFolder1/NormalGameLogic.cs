using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Šnaps
{
    static class NormalGameLogic// : GameLogic
    {
        static public bool IsCardAdut(Card card)
        {
            if (String.Equals(card.GetCardColor(), AdutColor.GetColor()))
                return true;
            else
                return false;
        }

        static public bool AreCardsSameColor(Card card1, Card card2)
        {
            if (String.Equals(card1.GetCardColor(), card2.GetCardColor()))
                return true;
            else
                return false;
        }

        static public bool IsFirstCardHigherValue(Card card1, Card card2)
        {
            if (card1.GetCardValue() > card2.GetCardValue())
                return true;
            else
                return false;
        }

        static public bool IsFirstCardWinner(Card card1, Card card2)
        {
            Console.WriteLine("----------");
            Console.WriteLine("Comparing: " + card1.GetCardImageName() + " vs " + card2.GetCardImageName());

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
    }
}
