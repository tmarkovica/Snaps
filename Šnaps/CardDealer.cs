using System;

namespace Šnaps
{
    class CardDealer
    {
        private DeckOfCards deck;
        private int cardCounter;

        public CardDealer()
        {
            deck = new DeckOfCards();
        }

        public CardDealer(DeckOfCards deckOfCards) { this.deck = deckOfCards; }

        virtual public void Shuffle()
        {
            deck.ShuffleCards();
            cardCounter = 0;
        }

        virtual public Card PullCard()
        {
            Card tempCard = deck.GetCard(cardCounter);
            if (cardCounter <= 20)
                cardCounter++;

            return tempCard;
        }

        public bool IsOutOfCards() 
        {
            if (cardCounter >= 20) return true; 
            else return false; 
        }
    }
}
