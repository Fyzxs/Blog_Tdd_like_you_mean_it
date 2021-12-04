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
        public void GivenInput3ReturnsFizz()
        {
            //ARRANGE
            string expected = "Fizz";
            int sourceInput = 1 * 3;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenInput6ReturnsFizz()
        {
            //ARRANGE
            string expected = "Fizz";
            int sourceInput = 2 * 3;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenInput9ReturnsFizz()
        {
            //ARRANGE
            string expected = "Fizz";
            int sourceInput = 3 * 3;

            //ACT
            string actual = Transform(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        //Given 9 returns Fizz

        public string Transform(int source)
        {
            if (source == 2 * 3) return "Fizz";
            if (source == 1 * 3) return "Fizz";
            return source.ToString();
        }
    }
}