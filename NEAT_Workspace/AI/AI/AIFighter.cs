using SharpNeat.Phenomes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class AIFighter
    {
        /// <summary>
        /// The neural network that this player uses to make its decision.
        /// </summary>
        public IBlackBox Brain { get; set; }

        /// <summary>
        /// Creates a new NEAT player with the specified brain.
        /// </summary>
        public AIFighter(IBlackBox brain)
        {
            Brain = brain;
        }

        /// <summary>
        /// Gets the next moves from the neural network.
        /// </summary>
        public int[] GetMoves(int[] gameStateArray)
        {
            // Clear the network
            Brain.ResetState();

            // Copy the game state into the input array for the network
            Debug.Assert(Equals(Brain.InputSignalArray.Length, GameState.aiInputMatrixSize));
            Debug.Assert(Equals(gameStateArray.Length, GameState.aiInputMatrixSize));
            for (int i = 0; i < GameState.aiInputMatrixSize; i++)
            {
                Brain.InputSignalArray[i] = gameStateArray[i];
            }

            // Activate the network
            Brain.Activate();

            // Get max output value
            double maxSignal = Brain.OutputSignalArray[0];
            for (int i = 1; i < GameState.aiOutputMatrixSize; i++)
            {
                maxSignal = Math.Max(maxSignal, Brain.OutputSignalArray[i]);
            }

            //Apply softmax to output layer and generate the moves output array
            double threshold = 0.5;                     //threshold for softmax. Determines if a move is made or not
            int[] moves = { 0, 0, 0, 0, 0, 0, 0 };      //int array used to make moves in the game
            for (int i = 0; i < GameState.aiOutputMatrixSize; i++)
            {
                //normalize (or apply softmax) the brain output. Max value will = 1.0
                if ((Brain.OutputSignalArray[i] / maxSignal) > threshold)
                {
                    //this ith signal is above threshold. Make this move.
                    moves[i] = 1;
                }
                else
                {
                    //this ith signal is below threshold. Do not make this move.
                    moves[i] = 0;
                }
            }

            //return moves array
            return moves;
        }
    }
}
