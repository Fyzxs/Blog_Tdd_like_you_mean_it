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

            //ARRANGE

            //ACT
            string actual = Transform(1);

            //ASSERT
            actual.Should().Be("1");
        }

        public string Transform(int i)
        {
            return "1";
        }
    }
}