using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class GameMechanism : IPlayerMechanics
    {
        Iterator iterator; // turn manager
        CardDealer cardDealer;

        public GameMechanism(Iterator iterator) 
        {
            this.iterator = iterator;

            this.iterator.IntroduceGameMechanicsToPlayers(this);

            this.cardDealer = CardDealer.Instance;
        }

        public void DealCards()
        {
            //this.cardDealer.Shuffle();
            Adut adut = Adut.GetInstance();
            adut.PlaceCard(this.cardDealer.PullCard());

            int numberOfDrawIterations = 5 * this.iterator.NumberOfParticipants;

            for (int i = 0; i < numberOfDrawIterations; i++)
            {
                DrawCard(this.cardDealer.PullCard());
            }
        }

        public void DrawCard(Card card)
        {
            if (card == null)
                card = Adut.GetInstance().PullCard();

            this.iterator.CurrentPlayer.DrawCard(card);
        }



        List<ITurnStartingPlayer> players = new List<ITurnStartingPlayer>();

        public void AddPlayer(ITurnStartingPlayer player) { this.players.Add(player); }
            
        public void EnoughPoints(Player player)
        {
            //new GameRound(this.players);
        }

        public void Plays(Player player)
        {
            //player.PlayCard(); // allowPlay

            foreach (Player pl in this.players)
            {
                if (pl == player) { }

            }
        }

        public void StartRound()
        {
            this.iterator.CurrentPlayer.YourTurnToPLay();
            this.iterator.PrepNextPlayer();
        }

        public void DrawCards()
        {
            //foreach ()
        }
    }
}
