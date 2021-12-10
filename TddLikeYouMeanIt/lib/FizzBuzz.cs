namespace TddLikeYouMeanIt.lib
{
    public sealed class FizzBuzz : IRuleEvalAction
    {
        private readonly IRuleEvalAction _action;

        public FizzBuzz() : this(
            new MultipleOfThreeAndFive_RuleEvalAction(
                new MultipleOfFive_RuleEvalAction(
                    new MultipleOfThree_RuleEvalAction(
                        new AsString_RuleEvalAction())))
        )
        { }

        private FizzBuzz(IRuleEvalAction action) => _action = action;

        public Answer Act(TurnCount source) => _action.Act(source);
    }
}