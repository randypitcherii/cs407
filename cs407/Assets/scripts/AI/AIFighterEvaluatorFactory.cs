using AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
