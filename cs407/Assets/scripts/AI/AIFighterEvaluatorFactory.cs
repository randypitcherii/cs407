using AI;
using SharpNeat.Phenomes;

namespace Assets.scripts.AI
{
    class AIFighterEvaluatorFactory : IEvaluatorFactory
    {
        public ICoevolutionPhenomeEvaluator<IBlackBox> getNewEvaluator()
        {
            return new AIEvaluator();
        }
    }
}
