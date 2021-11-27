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

        //Given an integer of 3 should return string of 3

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

        public string Transform(int source)
        {
            if (source == 2) return "2";
            return "1";
        }
    }
}