using System.Linq;

namespace TddLikeYouMeanIt.lib
{
    public abstract class Rule
    {
        public abstract bool Matches(TurnInput turnInput);
    }

    public abstract class MultipleOfRule : Rule
    {
        private readonly int _multipleOf;

        protected MultipleOfRule(int multipleOf) => _multipleOf = multipleOf;

        public override bool Matches(TurnInput turnInput) => turnInput % _multipleOf == 0;
    }

    public sealed class MultipleOfThreeRule : MultipleOfRule
    {
        public MultipleOfThreeRule() : base(3) { }
    }

    public sealed class MultipleOfFiveRule : MultipleOfRule
    {
        public MultipleOfFiveRule() : base(5) { }
    }

    public abstract class CompoundRule : Rule
    {
        private readonly Rule[] _rules;

        protected CompoundRule(params Rule[] rules) => _rules = rules;

        public override bool Matches(TurnInput turnInput) => _rules.All(it => it.Matches(turnInput));
    }

    public sealed class MultipleOfThreeAndFiveRule : CompoundRule
    {
        public MultipleOfThreeAndFiveRule()
            : base(new MultipleOfThreeRule(), new MultipleOfFiveRule()) { }
    }
}