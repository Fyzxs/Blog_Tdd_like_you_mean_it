using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt
{
    [TestClass]
    public class FizzBuzzTests
    {
        private static readonly Random Rand = new();

        [TestMethod]
        public void GivenInputReturnsStringOfInput()
        {
            //ARRANGE
            Dictionary<int, string> regressionValues = new()
            {
                { 1, "1" },
                { 2, "2" },
                { 4, "4" }
            };

            (int sourceInput, string expected) =
                regressionValues.ElementAt(Rand.Next(0, regressionValues.Count));

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf3ReturnsFizz()
        {
            //ARRANGE
            const int multiplicand = 3;
            const string expected = "Fizz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            int sourceInput = multiplier * multiplicand;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf5ReturnsBuzz()
        {
            //ARRANGE
            const int multiplicand = 5;
            const string expected = "Buzz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            int sourceInput = multiplier * multiplicand;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf3And5ReturnsFizzBuzz()
        {
            //ARRANGE
            const int multiplicand = 3 * 5;
            const string expected = "FizzBuzz";
            List<int> multiplierList = new() { 1, 2, 3 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            int sourceInput = multiplier * multiplicand;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        public Answer Transform(int source)
        {
            TurnCount turnCount = new IntTurnCount(source);
            Rule multipleOfThreeRule = new MultipleOfThreeRule();
            if (turnCount.IsMultipleOf(3 * 5)) return new FizzBuzzAnswer();
            if (turnCount.IsMultipleOf(5)) return new BuzzAnswer();
            if (multipleOfThreeRule.Matches(turnCount)) return new FizzAnswer();
            return new InputAsStringAnswer(source);
        }
    }

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
        public MultipleOfThreeRule():base(3){}
    }
}