using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.player.AI
{
    class AIBrain
    {
        public static int [] getMoves(int[] gameState)
        {
            System.Random r = new System.Random();

            //create random actions
            int[] actions = { 0, 0, 0, 0, 0, 0, 0 };

            if (r.Next(0, 50) == 1)
            {
                actions[0] = r.Next(0, 5); //left key pressed
                actions[1] = r.Next(0, 5); //right key pressed
                actions[2] = r.Next(0, 2); //jump key pressed
                actions[3] = r.Next(0, 2); //melee attack key pressed
                actions[4] = r.Next(0, 2); //ranged attack key pressed
                actions[5] = r.Next(0, 2); //block key pressed
                actions[6] = r.Next(0, 1); //stand still
            }

            return actions;
        }
    }
}
