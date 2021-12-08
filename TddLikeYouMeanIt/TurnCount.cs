using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt
{
    public abstract class TurnCount : ToSystemType<int>
    {
        public abstract bool IsMultipleOf(int value);
    }

    public sealed class IntTurnCount : TurnCount
    {
        private readonly int _origin;

        public IntTurnCount(int origin) => _origin = origin;

        public override bool IsMultipleOf(int value)
        {
            return (0 == _origin % value);
        }

        protected override int AsSystemType() => _origin;
    }
}