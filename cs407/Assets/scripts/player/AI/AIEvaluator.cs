using SharpNeat.Core;
using SharpNeat.Phenomes;
using UnityEngine;

namespace AI
{
    class AIEvaluator : ICoevolutionPhenomeEvaluator<IBlackBox>
    {
        private ulong _evalCount;
        static System.Random randomNumGenerator = new System.Random();

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
            // build fighter brains
            AIFighter player1Brain = new AIFighter(box1);
            AIFighter player2Brain = new AIFighter(box2);

            //TODO: Make function that starts new game and returns that game's master game object
            //start game
            Master_Game_Object currGame = new Master_Game_Object();

            //get player objects
            Player player1 = currGame.player1;//
            Player player2 = currGame.player2;//

            //assign brains to players
            //TODO: create assignBrain function
            player1.assignBrain(player1Brain);
            player2.assignBrain(player2Brain);

            //play game
            while (!currGame.gi.isOver)
            {
                //Unity's thread manager will yeild this loop to other game functions
                //until this game finishes.
            }

            //get game results
            Player winner = currGame.winner;
            double timeLeft = currGame.remainingTime;

            if (player1 == winner)
            {
                //player 1 wins. They get 1000 win bonus + points for how fast they won
                fitness1 = new FitnessInfo(1000 + timeLeft, 100 + timeLeft);

                //player 2 loses. They only get points for how long they lasted
                fitness2 = new FitnessInfo(300 - timeLeft, 300 - timeLeft);
            }
            else if (player2 == winner)
            {
                //player 1 loses. They only get points for how long they lasted
                fitness1 = new FitnessInfo(300 - timeLeft, 300 - timeLeft);

                //player 2 wins. They get 1000 win bonus + points for how fast they won
                fitness2 = new FitnessInfo(1000 + timeLeft, 100 + timeLeft);
            }
            else
            {
                //Nobody won. Nobody gets points.
                fitness1 = new FitnessInfo(0,0);
                fitness2 = new FitnessInfo(0,0);
            }

            // Update the evaluation counter.
            _evalCount++;

            //end the game
            Object.Destroy(currGame);
        }

        /// <summary>
        /// Reset the internal state of the evaluation scheme if any exists.
        /// </summary>
        public void Reset()
        {
        }
    }
}
