using System.Collections.Generic;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt.external
{
    public interface IFuzzBuzzExternal
    {
        Answer Eval(TurnInput turnInput);
    }

    public sealed class FizzBuzzExternal : IFuzzBuzzExternal
    {
        private readonly IRuleEvalCollection _ruleCollection;

        public FizzBuzzExternal(IRuleEvalCollection ruleCollection) => _ruleCollection = ruleCollection;

        public Answer Eval(TurnInput turnInput)
        {
            foreach (IRuleEval rule in _ruleCollection)
            {
                if (rule.Matches(turnInput)) return rule.Response(turnInput);
            }

            return _ruleCollection.DefaultAnswer(turnInput);
        }
    }
}