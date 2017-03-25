using SharpNeat.Core;
using SharpNeat.Phenomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class AIEvaluator: ICoevolutionPhenomeEvaluator<IBlackBox>
    {
        private ulong _evalCount;

        /// <summary>
        /// Gets the total number of evaluations that have been performed.
        /// </summary>
        public ulong EvaluationCount
        {
            get { return _evalCount; }
        }

        /// <summary>
        /// Gets a value indicating whether some goal fitness has been achieved and that
        /// the the evolutionary algorithm/search should stop. This property's value can remain false
        /// to allow the algorithm to run indefinitely.
        /// </summary>
        public bool StopConditionSatisfied
        {
            get { return false; }
        }

        /// <summary>
        /// Evaluate the two black boxes by playing them against each other in a
        /// fight. All permutations of size 2 are going to be
        /// evaluated, so we only play one game.
        /// </summary>
        public void Evaluate(IBlackBox box1, IBlackBox box2,
                            out FitnessInfo fitness1, out FitnessInfo fitness2)
        {
            // build fighters
            AIFighter player1 = new AIFighter(box1);
            AIFighter player2 = new AIFighter(box2);

            //FIX Everything below this point.
            //TODO: Need to find a way to play a full game.
            //TODO: Need to build a score based on the results of a game

            // Play the two boxes against each other.
            var matchResults = TicTacToeGame.PlayGameToEnd(player1, player2);

            // Score player 1
            double score1 = getScore(winner, SquareTypes.X);
            fitness1 = new FitnessInfo(score1, score1);

            // Score player 2
            double score2 = getScore(winner, SquareTypes.O);
            fitness2 = new FitnessInfo(score2, score2);

            // Update the evaluation counter.
            _evalCount++;
        }

        /// <summary>
        /// Reset the internal state of the evaluation scheme if any exists.
        /// </summary>
        public void Reset()
        {
        }
    }
}
