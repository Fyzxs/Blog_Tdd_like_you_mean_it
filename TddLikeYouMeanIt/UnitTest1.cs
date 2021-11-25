using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddLikeYouMeanIt
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Given an integer of 1 should return string of 1

            string actual = FizzBuzz(1);
            actual.Should().Be("1");
        }

    }
}