using System;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        static Random rnd = new Random();
        static int m = rnd.Next(0, 10), n = rnd.Next(0, 10);
        static int a = rnd.Next(0, 40000), b = rnd.Next(0, 40000);

        BigInteger expectedResult1 = BigInteger.Pow(m, a);
        BigInteger expectedResult2 = BigInteger.Pow(n, b);

        List<int> actualResult1 = LongArithmetic.Pow(m, a);
        List<int> actualResult2 = LongArithmetic.Pow(n, b);

        [TestMethod]
        public void TestGetBigInteger()
        {
            Random rnd = new Random();
            StringBuilder actualResultString = new StringBuilder();
            foreach (var item in actualResult1)
            {
                actualResultString.Append(item);
            }
            Assert.AreEqual(expectedResult1.ToString(), actualResultString.ToString());
        }
        [TestMethod]
        public void TestCompare()
        {
            int expectedCompare = BigInteger.Compare(expectedResult1, expectedResult2);
            int actualCompare = LongArithmetic.Compare(actualResult1, actualResult2)[2][0];
            Assert.AreEqual(expectedCompare, actualCompare);
        }
    }
}