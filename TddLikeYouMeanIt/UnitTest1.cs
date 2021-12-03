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
                { 3, "3" }
            };

            (int valueToTransform, string transformedValue) = 
                regressionValues.ElementAt(new Random().Next(0, regressionValues.Count));


            //ACT
            string actual = Transform(valueToTransform);

            //ASSERT
            actual.Should().Be(transformedValue);
        }

        //Pass in 3, get back "Fizz"
        [TestMethod]
        public void In3OutFizz()
        {
            //ARRANGE

            //ACT
            string actual = Transform(3);

            //ASSERT
            actual.Should().Be("Fizz");
        }

        public string Transform(int source)
        {
            if (source == 3) return "Fizz";
            return source.ToString();
        }
    }
}