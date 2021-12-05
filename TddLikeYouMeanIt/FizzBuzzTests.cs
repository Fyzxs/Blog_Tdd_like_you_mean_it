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
        private static readonly Random rand = new();

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
                regressionValues.ElementAt(rand.Next(0, regressionValues.Count));

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf3ReturnsFizz()
        {
            //ARRANGE
            Dictionary<int, string> regressionValues = new()
            {
                { 1 * 3, "Fizz" },
                { 2 * 3, "Fizz" },
                { 4 * 3, "Fizz" }
            };

            (int sourceInput, string expected) =
                regressionValues.ElementAt(rand.Next(0, regressionValues.Count));

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf5ReturnsFizz()
        {
            //ARRANGE
            int multiplicand = 5;
            string expected = "Buzz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = rand.Next(0, multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            int sourceInput = multiplier * multiplicand;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        public string Transform(int source)
        {
            if (0 == source % 5) return "Buzz";
            if (0 == source % 3) return "Fizz";
            return source.ToString();
        }
    }
}