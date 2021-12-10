namespace TddLikeYouMeanIt.lib
{
    public abstract class TurnInput : ToSystemType<int> { }

    public sealed class IntTurnInput : TurnInput
    {
        private readonly int _origin;

        public IntTurnInput(int origin) => _origin = origin;

        protected override int AsSystemType() => _origin;
    }
}