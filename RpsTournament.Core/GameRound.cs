using System;
using System.Collections.Generic;
using System.Text;

namespace RpsTournament.Core
{
    public struct GameRound
    {
        public int Number { get; set; }
        public Move PlayerMove { get; set; }
        public Move ComputerMove { get; set; }
        public RoundResult Result { get; set; }
    }
}
