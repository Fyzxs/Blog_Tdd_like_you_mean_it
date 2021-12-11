using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddLikeYouMeanIt.external;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt
{
    [TestClass]
    public class FizzBuzzExternalTests
    {
        private static readonly Random Rand = new();

        [TestMethod]
        public void External_GivenInputReturnsStringOfInput()
        {
            //ARRANGE
            Dictionary<int, string> regressionValues = new()
            {
                { 1, "1" },
                { 2, "2" },
                { 4, "4" }
            };

            KeyValuePair<int, string> keyValuePair = regressionValues.ElementAt(Rand.Next(0, regressionValues.Count));
            TurnInput sourceInput = new IntTurnInput(keyValuePair.Key);
            string expected = keyValuePair.Value;
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);


            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void External_GivenMultipleOf3ReturnsFizz()
        {
            //ARRANGE
            const int multiplicand = 3;
            const string expected = "Fizz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [3*{multiplier}={multiplicand * multiplier}]");
        }

        [TestMethod]
        public void External_GivenMultipleOf5ReturnsBuzz()
        {
            //ARRANGE
            const int multiplicand = 5;
            const string expected = "Buzz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [5*{multiplier}={multiplicand * multiplier}]");
        }

        [TestMethod]
        public void External_GivenMultipleOf3And5ReturnsFizzBuzz()
        {
            //ARRANGE
            const int multiplicand = 3 * 5;
            const string expected = "FizzBuzz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [3*5*{multiplier}={multiplicand * multiplier}]");
        }

        [TestMethod]
        public void External_GivenMultipleOf7ReturnsBang()
        {
            //ARRANGE
            const int multiplicand = 7;
            const string expected = "Bang";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()

            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [7*{multiplier}={multiplicand * multiplier}]");
        }

        [TestMethod]
        public void External_GivenMultipleOf3And7ReturnsFizzBang()
        {
            //ARRANGE
            const int multiplicand = 3 * 7;
            const string expected = "FizzBang";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [3*7{multiplier}={multiplicand * multiplier}]");
        }

        [TestMethod]
        public void External_GivenMultipleOf5And7ReturnsBuzzBang()
        {
            //ARRANGE
            const int multiplicand = 5 * 7;
            const string expected = "BuzzBang";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [5*7*{multiplier}={multiplicand * multiplier}]");

        }

        [TestMethod]
        public void External_GivenMultipleOf3And5And7ReturnsBuzzBang()
        {
            //ARRANGE
            const int multiplicand = 3 * 5 * 7;
            const string expected = "FizzBuzzBang";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnInput sourceInput = new IntTurnInput(multiplier * multiplicand);
            AsStringFactorRuleCollection ruleCollection = new()
            {
                new MultipleOfThreeRuleEval(),

                new MultipleOfFiveRuleEval(),
                new MultipleOfThreeAndFiveRuleEval(),

                new MultipleOfSevenRuleEval(),
                new MultipleOfThreeAndSevenRuleEval(),
                new MultipleOfFiveAndSevenRuleEval(),
                new MultipleOfThreeAndFiveAndSevenRuleEval()
            };

            IFuzzBuzzExternal subject = new FizzBuzzExternal(ruleCollection);

            //ACT
            string actual = subject.Eval(sourceInput);

            //ASSERT
            actual.Should().Be(expected, $"Ran with value of [3*5*7*{multiplier}={multiplicand * multiplier}]");
        }
    }
}