using System.Collections;
using System.Collections.Generic;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt.external
{
    public interface IRuleEvalCollector
    {
        void Add(ComparableRuleEval ruleEval);
        void Clear();
    }

    public interface IRuleEvalCollection : IEnumerable<IRuleEval>
    {
        Answer DefaultAnswer(TurnInput turnInput);
    }

    public class AsStringFactorRuleCollection : IRuleEvalCollection, IRuleEvalCollector
    {
        private readonly IRuleEval _defaultRuleEval;
        private readonly List<ComparableRuleEval> _collection = new();

        public AsStringFactorRuleCollection() : this(new AsStringRuleEval()) { }

        private AsStringFactorRuleCollection(IRuleEval defaultRuleEval) => _defaultRuleEval = defaultRuleEval;

        public Answer DefaultAnswer(TurnInput turnInput) => _defaultRuleEval.Response(turnInput);

        public IEnumerator<IRuleEval> GetEnumerator() => _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(ComparableRuleEval ruleEval)
        {
            _collection.Add(ruleEval);
            _collection.Sort((x, y) => y.CompareTo(x));
        }

        public void Clear() => _collection.Clear();
    }
}