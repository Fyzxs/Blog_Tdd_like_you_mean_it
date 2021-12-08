using System.Data;
using System.Linq;

namespace TddLikeYouMeanIt
{
    public interface IRule
    {
        bool Matches(TurnCount turnCount);
    }

    public abstract class MultipleOfRule : IRule
    {
        private readonly int _multipleOf;

        protected MultipleOfRule(int multipleOf) => _multipleOf = multipleOf;

        public bool Matches(TurnCount turnCount) => turnCount % _multipleOf == 0;
    }

    public sealed class MultipleOfThreeRule : MultipleOfRule
    {
        public MultipleOfThreeRule() : base(3) { }
    }

    public sealed class MultipleOfFiveRule : MultipleOfRule
    {
        public MultipleOfFiveRule() : base(5) { }
    }

    public sealed class MultipleOfThreeAndFiveRule : IRule
    {
        private readonly IRule[] _rules;

        public MultipleOfThreeAndFiveRule()
            :this(new MultipleOfThreeRule(), new MultipleOfFiveRule()){}

        private MultipleOfThreeAndFiveRule(params IRule[] rules) => _rules = rules;

        public bool Matches(TurnCount turnCount)
        {
            return _rules.All(it => it.Matches(turnCount));
        }
    }
}