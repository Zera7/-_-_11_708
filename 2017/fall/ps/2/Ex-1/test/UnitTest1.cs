using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using solver;

namespace test
{
    [TestClass]
    public class TriangleTask_Tests
    {
        const double Delta = 0.00000001;

        // Тест первого метода
        [TestMethod]
        public void TestE1Default()
        {
            TestEx1(1, 1, Math.E, 3, 1);
        }
        [TestMethod]
        public void TestE1NaN()
        {
            TestEx1(0, 1, double.NaN, double.NaN, -1);
        }
        [TestMethod]
        public void TestE1Accurate()
        {
            TestEx1(23, 0.0000000001, 1.04443728891, 5);
        }
        public void TestEx1(double x, double k, double expectedResult, double expectedIterations, double delta = Delta)
        {
            var a = Ex1.F1(x, k);
            if (delta == -1)
                Assert.AreEqual(expectedResult, a[0]);
            else
                Assert.AreEqual(expectedResult, a[0], delta);
            Assert.AreEqual(expectedIterations, a[1]);
        }

        // Тест второго метода
        [TestMethod]
        public void TestE2Deault()
        {
            TestEx2(0, 1, 1, 2);
        }
        [TestMethod]
        public void TestE2NaN()
        {
            TestEx2(2, 1, double.NaN, double.NaN, -1);
        }
        [TestMethod]
        public void TestE2Accurate()
        {
            TestEx2(1, 0.000003, 1.41421356237, 1709, 0.000003);
        }
        public void TestEx2(double x, double k, double expectedResult, double expectedIterations, double delta = Delta)
        {
            var a = Ex1.F2(x, k);
            if (delta == -1)
                Assert.AreEqual(expectedResult, a[0]);
            else
                Assert.AreEqual(expectedResult, a[0], delta);
            Assert.AreEqual(expectedIterations, a[1]);
        }

        // Тест третьего метода
        [TestMethod]
        public void TestE3Default()
        {
            TestEx3(1, 0.5, 2);
        }
        [TestMethod]
        public void TestE3Accurate()
        {
            TestEx3(0.00000001, 0.54831135561, 13);
        }
        public void TestEx3(double k, double expectedResult, double expectedIterations)
        {
            var a = Ex1.F3(k);
            Assert.AreEqual(expectedResult, a[0], Delta);
            Assert.AreEqual(expectedIterations, a[1]);
        }
    }
}