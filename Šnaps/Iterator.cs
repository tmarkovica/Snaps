using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Šnaps
{
    class Iterator
    {
        private Participants participants;

        private int currentPlayerIndex;
        
        public Iterator(Participants participants)
        {
            this.participants = participants;
            this.currentPlayerIndex = 0;
        }

        public int NumberOfParticipants { get { return this.participants.Count; } }

        public bool IsCounted(int index) { return index >= this.participants.Count; }

        public Player CurrentPlayer // evry time currentPlayer is used it cycles to the next player
        {
            get
            {
                Player player = this.participants[currentPlayerIndex];

                this.currentPlayerIndex++;
                if (IsCounted(this.currentPlayerIndex))
                    this.currentPlayerIndex = 0;

                return player;
            }
        }

        public Player StartingPlayer
        {
            get
            {
                return this.participants[currentPlayerIndex];
            }
        }

        public void SetStartingPlayerByIndex(int index)
        {
            this.currentPlayerIndex = index;
        }
    }
}
