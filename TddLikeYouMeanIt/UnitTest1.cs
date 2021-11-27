using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddLikeYouMeanIt
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void GivenInt1ShouldReturnString1()
        {
            //ARRANGE
            int valueToTransform = 1;
            string transformedValue = "1";

            //ACT
            string actual = Transform(valueToTransform);

            //ASSERT
            actual.Should().Be(transformedValue);
        }

        [TestMethod]
        public void GivenInt2ShouldReturnString2()
        {
            //ARRANGE
            int valueToTransform = 2;
            string transformedValue = "2";

            //ACT
            string actual = Transform(valueToTransform);

            //ASSERT
            actual.Should().Be(transformedValue);
        }
        
        [TestMethod]
        public void GivenInt3ShouldReturnString3()
        {
            //ARRANGE
            int valueToTransform = 3;
            string transformedValue = "3";

            //ACT
            string actual = Transform(valueToTransform);

            //ASSERT
            actual.Should().Be(transformedValue);
        }

        public string Transform(int source)
        {
            if (source == 1) return source.ToString();
            if (source == 1) return "1";
            if (source == 3) return "3";
            if (source == 2) return "2";
            throw new Exception("We broke something");
        }
    }
}