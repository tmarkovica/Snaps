using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Šnaps
{
    class DeckOfCards
    {
        private List<Card> deckOfCards;

        public DeckOfCards()
        {
            deckOfCards = new List<Card>()
            {
                new Card("Srce", "Dečko", 2),
                new Card("Srce", "Dama", 3),
                new Card("Srce", "Kralj", 4),
                new Card("Srce", "Deset", 10),
                new Card("Srce", "As", 11),

                new Card("Zelje", "Dečko", 2),
                new Card("Zelje", "Dama", 3),
                new Card("Zelje", "Kralj", 4),
                new Card("Zelje", "Deset", 10),
                new Card("Zelje", "As", 11),

                new Card("Žir", "Dečko", 2),
                new Card("Žir", "Dama", 3),
                new Card("Žir", "Kralj", 4),
                new Card("Žir", "Deset", 10),
                new Card("Žir", "As", 11),

                new Card("Tikva", "Dečko", 2),
                new Card("Tikva", "Dama", 3),
                new Card("Tikva", "Kralj", 4),
                new Card("Tikva", "Deset", 10),
                new Card("Tikva", "As", 11)
            };
        }

        public void ShuffleCards()
        {
            Random random = new Random();

            int numberOfCards = deckOfCards.Count();

            List<Card> shuffledDeckOfCards = new List<Card>();

            int randomNumber;

            for (int i = numberOfCards; i > 0; i--)
            {
                randomNumber = random.Next(0, i);
                shuffledDeckOfCards.Add(deckOfCards[randomNumber]);
                deckOfCards.Remove(deckOfCards[randomNumber]);
            }

            deckOfCards.Clear();
            deckOfCards.AddRange(shuffledDeckOfCards);
        }

        public Card GetCard(int index)
        {
            if (index < 20)
                return deckOfCards.ElementAt(index);
            else
                return null;
        }

        public void WriteCardsInConsole()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write(i + ". " + deckOfCards[i].GetCardImageName() + "\n");
            }
        }
    }
}
