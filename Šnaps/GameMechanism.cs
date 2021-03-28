using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Šnaps
{
    class GameMechanism : IPlayerMechanics, IRoundObserver
    {
        CardDealerManager dealer;

        private bool gameClosed = false;

        TurnManager turnManager;

        public GameMechanism(TurnManager manager) 
        {
            this.turnManager = manager;
            this.turnManager.IntroduceGameMechanicsToPlayers(this); 
        }

        public void SetDealer(CardDealerManager dealer)
        {
            this.dealer = dealer;
        }

        private Card DrawCard()
        {
            if (gameClosed == true)
                return null;

            return this.dealer.PullCard();
        }

        private void DealCards()
        {
            this.dealer.Shuffle();

            for (int i = 0; i < 5; i++)
                this.turnManager.PlayersDraw();
        }

        public Card GetCardFromDealer()
        {
            return DrawCard();
        }


        // Collegues
        List<ITurnStartingPlayer> players = new List<ITurnStartingPlayer>();

        public void AddPlayer(ITurnStartingPlayer player) { }// this.players.Add(player); }

        
        private void ResetPlayerHands()
        {
            this.turnManager.ResetPlayerHands();
            this.gameClosed = false;
        }

        public void StartRound()
        {
            ResetPlayerHands();

            this.DealCards();
            this.gameClosed = false;

            this.turnManager.NewRound();
        }

        public void EnoughPoints()
        {
            StartRound();
        }

        public void ExchangeAdut(IStorageable holder)
        {
            if (this.turnManager.HaveFourTurnsPassed() == false) 
            {
                if (holder != null)
                    this.dealer.ExchangeAdut(holder);
            }
        }

        public void CloseGame()
        {
            if (this.turnManager.HaveFourTurnsPassed() == false)
            {
                this.dealer.CloseGame();
                this.gameClosed = true;
                this.turnManager.CloseGame();
            }
        }


        public void PrepNextPlayer()
        {
            this.turnManager.PrepNextPlayer();
        }

        public void Update_RoundEnded()
        {
            StartRound();
        }
    }
}
