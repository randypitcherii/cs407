using SharpNeat.Phenomes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class AIFighter
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
        public ISignalArray GetMoves(int[] gameStateArray)
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

            // Find the highest-scoring available move
            return Brain.OutputSignalArray;
        }
    }
}
