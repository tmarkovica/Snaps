using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    class Participants : IAbstractCollection
    {
        private List<Player> players;

        public Participants()
        {
            this.players = new List<Player>();
        }

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count { get { return this.players.Count; } }

        public void Add(Player player)
        {
            this.players.Add(player);
        }

        public Player this[int index]
        {
            get { return this.players[index]; }
        }

        private Referee referee;
        
        public Referee Referee
        {
            get { return referee; }
            set { this.referee = value; }
        }
    }
}
