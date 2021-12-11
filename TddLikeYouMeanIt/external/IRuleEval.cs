using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt.external
{
    public interface IRuleEval
    {
        bool Matches(TurnInput turnInput);
        Answer Response(TurnInput turnInput);
    }
    public sealed class AsStringRuleEval : IRuleEval
    {
        public bool Matches(TurnInput turnInput) => true;

        public Answer Response(TurnInput turnInput) => new TurnCountAsStringAnswer(turnInput);
    }
}