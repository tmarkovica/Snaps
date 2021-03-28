using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    static class ClosedGameLogic
    {
        static public bool IsFirstCardWinner(Card card1, Card card2)
        {
            if (GameLogic.IsCardAdut(card1))
            {
                if (GameLogic.IsCardAdut(card2))
                {
                    Console.WriteLine("Adut1 <> Adut2");
                    return GameLogic.AreCardsSameColor(card1, card2);
                }
                else
                {
                    Console.WriteLine("Adut1 > Card2");
                    return true;
                }
            }
            else
            {
                if (GameLogic.IsCardAdut(card2))
                {
                    Console.WriteLine("Card1 < Adut2");
                    return false;
                }
                else
                {
                    if (GameLogic.AreCardsSameColor(card1, card2))
                    {
                        Console.WriteLine("Card1 <> Card2 - u istoj boji");
                        return GameLogic.IsFirstCardHigherValue(card1, card2);
                    }
                    else
                    {
                        Console.WriteLine("Card1 < Card2 - boje različite, myTurn = ");
                        return true;
                    }
                }
            }
        }
    }
}
