using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void GivenMultipleOf5ReturnsFizz()
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
        public void Given15ReturnsFizzBuzz()
        {
            //ARRANGE
            const int sourceInput = 15;
            const string expected = "FizzBuzz";

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        //30 should return FizzBuzz

        [TestMethod]
        public void Given15ReturnsFizzBuzz()
        {
            //ARRANGE
            const int sourceInput = 30;
            const string expected = "FizzBuzz";

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        public string Transform(int source)
        {
            if (source == 15) return "FizzBuzz";
            if (0 == source % 5) return "Buzz";
            if (0 == source % 3) return "Fizz";
            return source.ToString();
        }
    }
}