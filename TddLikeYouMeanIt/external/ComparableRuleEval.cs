using System;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt.external
{
    public abstract class ComparableRuleEval : IRuleEval, IComparable<ComparableRuleEval>
    {
        private readonly Rule _rule;
        private readonly Answer _answer;

        protected ComparableRuleEval(Rule rule, Answer answer)
        {
            _rule = rule;
            _answer = answer;
        }

        public bool Matches(TurnInput turnInput) => _rule.Matches(turnInput);

        public Answer Response(TurnInput turnInput) => _answer; //It's a `getter` :(

        public int CompareTo(ComparableRuleEval? other) => this._rule.CompareTo(other?._rule);
    }
    public sealed class MultipleOfThreeRuleEval : ComparableRuleEval
    {
        public MultipleOfThreeRuleEval() : base(new MultipleOfThreeRule(), new FizzAnswer()) { }
    }

    public sealed class MultipleOfFiveRuleEval : ComparableRuleEval
    {
        public MultipleOfFiveRuleEval() : base(new MultipleOfFiveRule(), new BuzzAnswer()) { }
    }

    public sealed class MultipleOfThreeAndFiveRuleEval : ComparableRuleEval
    {
        public MultipleOfThreeAndFiveRuleEval() : base(new MultipleOfThreeAndFiveRule(), new FizzBuzzAnswer()) { }
    }
}