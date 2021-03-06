﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.player.AI
{
    class AIBrain
    {
        static System.Random randomNumGenerator = new System.Random();

        //agressive moves
        public static int [] getMovesA(int[] gameState)
        {
            //create random actions
            int[] actions = { 0, 0, 0, 0, 0, 0, 0 };

            if (randomNumGenerator.Next(0, 50) == 1)
            {
                actions[0] = randomNumGenerator.Next(0, 5); //left key pressed
                actions[1] = randomNumGenerator.Next(0, 5); //right key pressed
                actions[2] = randomNumGenerator.Next(0, 2); //jump key pressed
                actions[3] = randomNumGenerator.Next(0, 2); //melee attack key pressed
                actions[4] = randomNumGenerator.Next(0, 2); //ranged attack key pressed
                actions[5] = randomNumGenerator.Next(0, 2); //block key pressed
                actions[6] = randomNumGenerator.Next(0, 1); //stand still
            }

            return actions;
        }

        //defensive moves
        public static int[] getMovesB(int[] gameState)
        {
            //create random actions
            int[] actions = { 0, 0, 0, 0, 0, 0, 0 };

            if (randomNumGenerator.Next(0, 50) == 1)
            {
                actions[0] = randomNumGenerator.Next(0, 3); //left key pressed
                actions[1] = randomNumGenerator.Next(0, 3); //right key pressed
                actions[2] = randomNumGenerator.Next(0, 3); //jump key pressed
                actions[3] = randomNumGenerator.Next(0, 1); //melee attack key pressed
                actions[4] = randomNumGenerator.Next(0, 10); //ranged attack key pressed
                actions[5] = randomNumGenerator.Next(0, 1); //block key pressed
                actions[6] = randomNumGenerator.Next(0, 10); //stand still
            }

            return actions;
        }
    }
}
