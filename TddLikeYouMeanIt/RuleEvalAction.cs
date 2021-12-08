using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt
{
    public interface IRuleEvalAction
    {
        public Answer Act(TurnCount turnCount);
    }

    public sealed class Default_RuleEvalAction : IRuleEvalAction
    {
        public Answer Act(TurnCount turnCount)
        {
            return new InputAsStringAnswer(turnCount);
        }
    }
}