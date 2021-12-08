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
        private readonly int _input;

        public InputAsStringAnswer(int input) => _input = input;
        protected override string AsSystemType() => _input.ToString();
    }
}