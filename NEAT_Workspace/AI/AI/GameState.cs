using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class GameState
    {
        public static int aiInputMatrixSize = 100;//change this later
        public static int aiOutputMatrixSize = 100;//change this later too
        //get game state matrix
        public int[] GetCurrentState()
        {
            //add logic to query game state later, static for now
            return new int[4] {1,2,1,1};
        }
    }
}
