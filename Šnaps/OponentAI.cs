namespace Šnaps
{
    class OponentAI
    {
        private OponentsHand hand;

        public OponentAI(OponentsHand hand) 
        {
            this.hand = hand;
        }

        public Hand GetHand() { return this.hand; }

        public Card CounterCard(Card card)
        {
            return this.hand.CounterCard(card);
        }

        public Card StartingCard()
        {
            return this.hand.StartingCard();
        }
    }
}