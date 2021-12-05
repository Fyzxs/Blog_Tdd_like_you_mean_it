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
        public void GivenInputMultipleOf3ReturnsFizz()
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


        //Given input of 5 get 'Buzz' returned

        [TestMethod]
        public void Given5ReturnsBuzz()
        {
            //ARRANGE
            int sourceInput = 5;
            string expected = "Buzz";

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        public string Transform(int source)
        {
            if (source == 5) return "Buzz";
            if (0 == source % 3) return "Fizz";
            return source.ToString();
        }
    }
}