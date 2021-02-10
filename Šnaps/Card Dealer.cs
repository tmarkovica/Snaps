using System;

namespace Šnaps
{
    class CardDealer
    {
        private static CardDealer cardDealerSingleton = null;
        private DeckOfCards deck;
        private int cardCounter;

        private CardDealer()
        {
            deck = new DeckOfCards();
        }

        private static object syncLock = new object();

        public static CardDealer Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (CardDealer.cardDealerSingleton == null)
                        CardDealer.cardDealerSingleton = new CardDealer();

                    return CardDealer.cardDealerSingleton;
                }
            }
        }

        public void Shuffle()
        {
            deck.ShuffleCards();
            cardCounter = 0;
        }

        public Card PullCard()
        {
            Card tempCard = deck.GetCard(cardCounter);
            if (cardCounter <= 20)
                cardCounter++;

            return tempCard;
        }

        public bool IsOutOfCards() 
        { 
            if (cardCounter == 20) return true; 
            else return false; 
        }
    }
}
