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



        public Game(Participants participants)
        { 
            this.participants = participants;

            IntroduceGameMechanics();
        }

        GameMechanism gameMechanism;

        private void IntroduceGameMechanics()
        {
            Iterator iterator = this.participants.CreateIterator();

            this.gameMechanism = new GameMechanism(iterator);
        }

        public void SetAdut_PictureBox(PictureBox pictureBoxAdut, PictureBox pictureBoxAdutColor)
        {
            Adut.CreateHolder(pictureBoxAdut, pictureBoxAdutColor);


        }
        public void SetTurnLabel(Label labelTurn)
        {

        }

        public void Start()
        {
            this.gameMechanism.DealCards();

            this.gameMechanism.StartRound();
        }
    }
}
