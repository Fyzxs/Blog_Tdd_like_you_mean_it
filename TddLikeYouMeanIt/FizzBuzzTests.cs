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
                regressionValues.ElementAt(new Random().Next(0, regressionValues.Count));

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
                regressionValues.ElementAt(new Random().Next(0, regressionValues.Count));

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
            Dictionary<int, string> regressionValues = new()
            {
                { 1 * multiplicand, "Buzz" },
                { 2 * multiplicand, "Buzz" },
                { 4 * multiplicand, "Buzz" }
            };

            (int sourceInput, string expected) =
                regressionValues.ElementAt(new Random().Next(0, regressionValues.Count));

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