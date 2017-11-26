using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Ex2TestDecreaseDelta()
        {
            double oldResult = 0;
            double delta = double.MaxValue;
            double result = 0;
            for (long i = 10; i < 10000000000; i *= 10)
            {
                result = Ex2.GetPI(1.0 / i);
                if (delta <= Math.Abs(result - oldResult))
                {
                    Assert.Fail();
                    return;
                }
                delta = Math.Abs(result - oldResult);
                oldResult = result;
            }
        }
        [TestMethod]
        public void Ex2Test2()
        {
            Assert.AreEqual(Math.PI, Ex2.GetPI(0.00000000000000001), 0.00000001);
        }
    }
}
