using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class GameMechanism : IPlayerMechanics
    {
        Iterator iterator; // turn manager
        CardDealerManager dealer;

        private bool gameClosed = false;

        public GameMechanism(Iterator iterator) 
        {
            this.iterator = iterator;

            this.iterator.IntroduceGameMechanicsToPlayers(this);
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
            {
                for (int j = 0; j < this.iterator.NumberOfParticipants; j++)
                    this.iterator.CurrentPlayer.DrawCard();
            }
        }

        public Card GetCardFromDealer()
        {
            return DrawCard();
        }


        // Collegues
        List<ITurnStartingPlayer> players = new List<ITurnStartingPlayer>();

        public void AddPlayer(ITurnStartingPlayer player) { this.players.Add(player); }

        //
        Label turnLabel;

        public void SetTurnLabel(Label label) { this.turnLabel = label; }
        /*
        private void ResetPlayerHands()
        {
            for (int j = 0; j < this.iterator.NumberOfParticipants; j++)
                this.iterator.CurrentPlayer.ResetHand();

            this.gameClosed = false;
        }*/

        public void StartRound()
        {
            //ResetPlayerHands();

            this.iterator.ResetPlayersHands();

            this.DealCards();
            this.gameClosed = false;

            this.iterator.NewRound();
        }

        public void PrepNextPlayer()
        {
            this.iterator.PrepNextPlayer();
        }

        public void EnoughPoints()
        {
            StartRound();
        }

        public void ExchangeAdut(IStorageable holder)
        {
            if (this.iterator.HaveFourTurnsPassed() == false) 
            {
                if (holder != null)
                    this.dealer.ExchangeAdut(holder);
            }
        }

        public void CloseGame()
        {
            if (this.iterator.HaveFourTurnsPassed() == false)
            {
                this.iterator.CloseGame();
                this.dealer.CloseGame();
                this.gameClosed = true;
            }
        }
    }
}
