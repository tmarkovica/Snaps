using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Šnaps
{
    class ThrowManager : Manager
    {
        Oponent oponent;

        bool oponentThrows;

        Label labelTurn;

        public void SetTurnLabel(Label label) { this.labelTurn = label; }

        private void Wait()
        {
            Thread.Sleep(1000);
        }

        public override void Process()
        {
            throw new NotImplementedException();
        }

        public void SeatOponent(Oponent oponent)
        {
            this.oponent = oponent;
        }

        private void TurnUpdate()
        {
            oponentThrows = !oponentThrows;

            if (oponentThrows)
            {
                this.labelTurn.Text = "Protivnik igra";
                this.labelTurn.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                this.labelTurn.Text = " Vi igrate";
                this.labelTurn.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        public override void Next()
        {
            TurnUpdate();
        }
    }
}
