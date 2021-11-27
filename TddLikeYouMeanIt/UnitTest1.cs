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
            if (source is 1 or 2 or 3) return source.ToString();
            throw new Exception("We broke something");
        }
    }
}