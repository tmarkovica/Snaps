﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šnaps
{
    interface IPlayerMechanics
    {
        void PrepNextPlayer();

        Card GetCardFromDealer();

        void EnoughPoints();

        void ExchangeAdut(IStorageable holder);

        void CloseGame();
    }
}
