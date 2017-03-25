using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class GameState
    {
        public const int aiInputMatrixSize = 100;//change this later
        public const int aiOutputMatrixSize = 100;//change this later too

        //=====================================================================
        //states for AI input matrix
        //=====================================================================
        //environment positions
        public const int nothing_state = 0;
        public const int ground_state = 1;

        //character positions
        public const int self_state = 5;
        public const int opponent_state = 10;

        //missile positions
        public const int selfRangedAttack_state = 0;
        public const int opponentRangedAttack_state = 20;

        //non-positional game state
        public const int isBlocking_state = 1;
        public const int isFiring_state = 1;
        //=====================================================================
    }
}
