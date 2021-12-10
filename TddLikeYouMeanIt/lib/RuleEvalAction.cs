namespace TddLikeYouMeanIt.lib
{
    public interface IRuleEvalAction
    {
        public Answer Act(TurnInput turnInput);
    }

    public sealed class AsString_RuleEvalAction : IRuleEvalAction
    {
        public Answer Act(TurnInput turnInput) => new TurnCountAsStringAnswer(turnInput);
    }

    public abstract class Base_RuleEvalAction : IRuleEvalAction
    {
        private readonly IRule _rule;
        private readonly Answer _answer;
        private readonly IRuleEvalAction _nextAction;

        protected Base_RuleEvalAction(IRule rule, Answer answer, IRuleEvalAction nextAction)
        {
            _rule = rule;
            _answer = answer;
            _nextAction = nextAction;
        }

        public Answer Act(TurnInput turnInput)
        {
            if (ShouldHandle(turnInput)) return _answer;

            return _nextAction.Act(turnInput);
        }

        private bool ShouldHandle(TurnInput turnInput) => _rule.Matches(turnInput);
    }

    public sealed class MultipleOfThree_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfThree_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfThreeRule(), new FizzAnswer(), nextAction) { }
    }

    public sealed class MultipleOfFive_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfFive_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfFiveRule(), new BuzzAnswer(), nextAction) { }
    }

    public sealed class MultipleOfThreeAndFive_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfThreeAndFive_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfThreeAndFiveRule(), new FizzBuzzAnswer(), nextAction) { }
    }
}