using System.Windows.Forms;

namespace Šnaps
{
    class Game
    {
        Participants participants;
        Iterator iterator;

        public Game(Participants participants)
        { 
            this.participants = participants;

            IntroduceGameMechanics();
        }

        GameMechanism gameMechanism;
        TurnManager turnManager;

        private void IntroduceGameMechanics()
        {
            this.iterator = this.participants.CreateIterator();

            this.turnManager = new TurnManager(iterator, this.participants.Referee);
            this.gameMechanism = new GameMechanism(this.turnManager);

            for (int i = 0; i < participants.Count; i++)
                this.gameMechanism.AddPlayer(participants[i]);
        }

        public void SetDealer(CardDealerManager dealer) { this.gameMechanism.SetDealer(dealer); }

        public void SetTurnLabel(Label labelTurn)
        {
            this.turnManager.SetTurnLabel(labelTurn);
        }

        public void Start()
        {
            this.gameMechanism.StartRound();
        }
    }
}