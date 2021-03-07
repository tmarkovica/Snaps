using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class ClosedGameLogic : GameLogic
    {
        public bool myTurn { get; set; }

        override public bool IsFirstCardWinner(Card card1, Card card2)
        {
            if (IsCardAdut(card1))
            {
                if (IsCardAdut(card2))
                {
                    Console.WriteLine("Adut1 <> Adut2");
                    return AreCardsSameColor(card1, card2);
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
                        Console.WriteLine("Card1 < Card2 - boje različite, myTurn = " + myTurn);
                        return myTurn;
                    }
                }
            }
        }

        override public bool IsFirstCardStronger(Card card1, Card card2)
        {
            return true;
        }
    }
}
