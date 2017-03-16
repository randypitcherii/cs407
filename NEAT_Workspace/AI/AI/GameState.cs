using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class GameState
    {
        //get game state matrix
        public int[] GetCurrentState()
        {
            //add logic to query game state later, static for now
            return new int[4] {1,2,1,1};
        }
    }
}
