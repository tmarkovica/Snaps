using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class OponentAI_PlaysSecond : IOponentAI
    {
        private Card cardOnTable;

        private string adut = Adut.GetAdutColor();

        public OponentAI_PlaysSecond(Card card) 
        { 
            this.cardOnTable = card;
        }

        private bool IsCardAdut(Card card)
        {
            if (String.Equals(card.GetCardColor(), this.adut))
                return true;
            else
                return false;
        }

        private bool IsThisCardStronger(Card card)
        {
            if (card.GetCardValue() > cardOnTable.GetCardValue())
                return true;
            else
                return false;
        }

        public Card GetCardToPlay(Hand hand)
        {
            List<Card> cards = new List<Card>();
            cards = hand.GetCardsInHand();

            return FindBestCardToPlay(cards);
        }

        private Card FindBestCardToPlay(List<Card> cards)
        {
            if (IsCardAdut(cardOnTable))
                return FindCardToBattleAdut(cards);
            else
                return FindCardToBattleRegularCard(cards);
        }

        private Card FindCardToBattleAdut(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                if (IsCardAdut(card))
                    if (IsThisCardStronger(card))
                        return card;
            }

            return FindWeakestCardToPlay(cards);
        }

        private Card FindCardToBattleRegularCard(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                if (!IsCardAdut(card))
                    if (IsThisCardStronger(card))
                        return card;
            }

            return FindWeakestCardToPlay(cards);
        }

        private Card FindWeakestCardToPlay(List<Card> cards)
        {
            Card weakestCard = cards[0];

            foreach (Card card in cards)
            {
                if (weakestCard.GetCardValue() > card.GetCardValue())
                    if (!String.Equals(card.GetCardColor(), this.adut))
                        weakestCard = card;
            }

            return weakestCard;
        }
    }
}
