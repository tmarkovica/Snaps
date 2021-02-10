using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class ClosedGameLogic : IGameLogic
    {
        string adutColor;
        public bool myTurn { get; set; }

        public ClosedGameLogic(string adutColor)
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
            throw new NotImplementedException();
        }

        public bool CompareCardColors(Card card1, Card card2)
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

        public bool CompareCardValues(Card card1, Card card2)
        {
            if (String.Equals(card1.GetCardColor(), card2.GetCardColor()))
                return true;
            else
                return false;
        }

        public bool IsCardAdut(Card card)
        {
            if (String.Equals(card.GetCardColor(), adutColor))
                return true;
            else
                return false;
        }
    }
}
