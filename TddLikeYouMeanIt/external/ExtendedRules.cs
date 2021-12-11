using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt.external
{
    public sealed class MultipleOfSevenRule : MultipleOfRule
    {
        public MultipleOfSevenRule() : base(7) { }
    }

    public sealed class MultipleOfThreeAndSevenRule : CompoundRule
    {
        public MultipleOfThreeAndSevenRule()
            : base(new MultipleOfThreeRule(), new MultipleOfSevenRule()) { }
    }

    public sealed class MultipleOfFiveAndSevenRule : CompoundRule
    {
        public MultipleOfFiveAndSevenRule()
            : base(new MultipleOfFiveRule(), new MultipleOfSevenRule()) { }
    }

    public sealed class MultipleOfThreeAndFiveAndSevenRule : CompoundRule
    {
        public MultipleOfThreeAndFiveAndSevenRule()
            : base(new MultipleOfThreeRule(), new MultipleOfFiveRule(), new MultipleOfSevenRule()) { }
    }

    public sealed class BangAnswer : Answer
    {
        protected override string AsSystemType() => "Bang";
    }

    public sealed class FizzBangAnswer : Answer
    {
        protected override string AsSystemType() => "FizzBang";
    }

    public sealed class BuzzBangAnswer : Answer
    {
        protected override string AsSystemType() => "BuzzBang";
    }
    public sealed class FizzBuzzBangAnswer : Answer
    {
        protected override string AsSystemType() => "FizzBuzzBang";
    }

    public sealed class MultipleOfSevenRuleEval : ComparableRuleEval
    {
        public MultipleOfSevenRuleEval() : base(new MultipleOfSevenRule(), new BangAnswer()) { }
    }

    public sealed class MultipleOfThreeAndSevenRuleEval : ComparableRuleEval
    {
        public MultipleOfThreeAndSevenRuleEval() : base(new MultipleOfThreeAndSevenRule(), new FizzBangAnswer()) { }
    }

    public sealed class MultipleOfFiveAndSevenRuleEval : ComparableRuleEval
    {
        public MultipleOfFiveAndSevenRuleEval() : base(new MultipleOfFiveAndSevenRule(), new BuzzBangAnswer()) { }
    }

    public sealed class MultipleOfThreeAndFiveAndSevenRuleEval : ComparableRuleEval
    {
        public MultipleOfThreeAndFiveAndSevenRuleEval() : base(new MultipleOfThreeAndFiveAndSevenRule(), new FizzBuzzBangAnswer()) { }
    }
}
