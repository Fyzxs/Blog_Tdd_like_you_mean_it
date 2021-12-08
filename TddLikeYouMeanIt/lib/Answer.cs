namespace TddLikeYouMeanIt.lib
{
    public abstract class Answer : ToSystemType<string>{ }

    public sealed class FizzBuzzAnswer : Answer
    {
        protected override string AsSystemType() => "FizzBuzz";
    }

    public sealed class FizzAnswer : Answer
    {
        protected override string AsSystemType() => "Fizz";
    }

    public sealed class BuzzAnswer : Answer
    {
        protected override string AsSystemType() => "Buzz";
    }

    public sealed class InputAsStringAnswer : Answer
    {
        private readonly TurnCount _input;

        public InputAsStringAnswer(TurnCount input) => _input = input;
        protected override string AsSystemType() => ((int)_input).ToString();
    }
}