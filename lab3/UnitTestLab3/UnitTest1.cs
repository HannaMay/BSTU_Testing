using Lab3;
using NUnit.Framework;

namespace Lab3
{
    [TestFixture]
    public class UnitTest1
    {

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(0, 0, 0, ExpectedResult = true)]
        [TestCase(1, 1, -1, ExpectedResult = false)]
        [TestCase(10, 10, 10, ExpectedResult = true)]
        [TestCase(11, 20, 35, ExpectedResult = false)]
        [TestCase(-20, 10, 40, ExpectedResult = false)]
        [TestCase(20, -20, 30, ExpectedResult = false)]
        [TestCase(121, 25, 43, ExpectedResult = false)]
        [TestCase(111, 213, 322, ExpectedResult = true)]
        [TestCase(173, 1765, 44, ExpectedResult = false)]

        public bool TestMethod(int a, int b, int c)
        {
            return new Triangle(a, b, c).IsTriangle();
        }


    }
}
