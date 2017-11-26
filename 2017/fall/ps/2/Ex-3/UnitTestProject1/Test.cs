using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace Test
{
    [TestClass]
    public class Test
    {
        int n = 100000000;
        double delta = 0.0001;
        double expectedResult = 0.308488; 

        [TestMethod]
        public void TestLeftR()
        {
            Assert.AreEqual(expectedResult, CalcIntegral.CalcIntegralLeftRect(n), delta);

        }
        [TestMethod]
        public void TestRightR()
        {
            Assert.AreEqual(expectedResult, CalcIntegral.CalcIntegralRightRect(n), delta);

        }
        [TestMethod]
        public void TestTrapeze()
        {
            Assert.AreEqual(expectedResult, CalcIntegral.CalcIntegralTrapeze(n), delta);

        }
        [TestMethod]
        public void TestSimpson()
        {
            Assert.AreEqual(expectedResult, CalcIntegral.CalcIntegralSimpson(n), delta);

        }
        [TestMethod]
        public void TestMK()
        {
            Assert.AreEqual(expectedResult, CalcIntegral.CalcIntegralMK(n), delta);

        }
    }
}
