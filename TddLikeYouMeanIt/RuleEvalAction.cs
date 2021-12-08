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

    public sealed class MultipleOfThree_RuleEvalAction : IRuleEvalAction
    {
        private readonly IRule _rule;
        private readonly IRuleEvalAction _nextAction;

        public MultipleOfThree_RuleEvalAction(IRuleEvalAction nextAction) : this(new MultipleOfThreeRule(), nextAction) { }

        private MultipleOfThree_RuleEvalAction(IRule rule, IRuleEvalAction nextAction)
        {
            _rule = rule;
            _nextAction = nextAction;
        }

        public Answer Act(TurnCount turnCount)
        {
            if (ShouldHandle(turnCount)) return new FizzAnswer();

            return _nextAction.Act(turnCount);
        }

        private bool ShouldHandle(TurnCount turnCount) => _rule.Matches(turnCount);
    }
}