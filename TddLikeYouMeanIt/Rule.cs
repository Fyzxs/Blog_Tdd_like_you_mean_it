namespace TddLikeYouMeanIt
{
    public abstract class Rule
    {
        public abstract bool Matches(TurnCount turnCount);
    }

    public abstract class MultipleOfRule : Rule
    {
        private readonly int _multipleOf;

        protected MultipleOfRule(int multipleOf) => _multipleOf = multipleOf;

        public override bool Matches(TurnCount turnCount) => turnCount % _multipleOf == 0;
    }

    public sealed class MultipleOfThreeRule : MultipleOfRule
    {
        public MultipleOfThreeRule() : base(3) { }
    }
}