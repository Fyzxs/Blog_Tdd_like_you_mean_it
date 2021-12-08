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

            IRule multipleOfThreeAndFiveRule = new MultipleOfThreeAndFiveRule();
            if (multipleOfThreeAndFiveRule.Matches(turnCount)) return new FizzBuzzAnswer();
            
            IRule multipleOfFiveRule = new MultipleOfFiveRule();
            if (multipleOfFiveRule.Matches(turnCount)) return new BuzzAnswer();
            
            IRule multipleOfThreeRule = new MultipleOfThreeRule();
            if (multipleOfThreeRule.Matches(turnCount)) return new FizzAnswer();
           
            return new InputAsStringAnswer(turnCount);
        }
    }
}