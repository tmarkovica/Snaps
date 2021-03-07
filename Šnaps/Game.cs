using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void IntroduceGameMechanics()
        {
            this.iterator = this.participants.CreateIterator();

            this.gameMechanism = new GameMechanism(iterator);
        }

        public void SetDealer(CardDealerManager dealer) { this.gameMechanism.SetDealer(dealer); }

        public void SetTurnLabel(Label labelTurn)
        {
            this.iterator.SetTurnLabel(labelTurn);
        }

        public void Start()
        {
            this.gameMechanism.StartRound();
        }
    }
}
