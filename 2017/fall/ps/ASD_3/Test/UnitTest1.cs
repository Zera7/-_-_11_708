using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        public static SkipList<int> SkipList;

        public static int[] GetValues(SkipList<int> list)
        {
            var a = new int[list.Count];
            int i = 0;
            foreach (var item in list)
                a[i++] = item;
            return a;
        }

        [TestMethod]
        public void TestSimpleAdd()
        {
            SkipList = new SkipList<int>
            {
                0
            };
            var a = GetValues(SkipList);
            Assert.AreEqual(0, a[0]);
            Assert.AreEqual(1, SkipList.Count);
        }

        [TestMethod]
        public void TestEasyMultiplyAdd()
        {
            SkipList = new SkipList<int>
            {
                0,
                1,
                2,
                3
            };
            var a = GetValues(SkipList);
            Assert.AreEqual(4, SkipList.Count);
            for (int i = 0; i < a.Length; i++)
                Assert.AreEqual(i, a[i]);
        }

        [TestMethod]
        public void TestReverseMultiplyAdd()
        {
            SkipList = new SkipList<int>
            {
               3,
               2,
               1,
               0
            };
            var a = GetValues(SkipList);
            Assert.AreEqual(4, SkipList.Count);
            for (int i = a.Length - 1; i >= 0; i--)
                Assert.AreEqual(i, a[i]);
        }

        [TestMethod]
        public void TestRandomMultiplyAdd()
        {
            SkipList = new SkipList<int>
            {
                0,
                5,
                2,
                1,
                3,
                4,
                0
            };
            var a = GetValues(SkipList);
            var b = new[] { 0, 0, 1, 2, 3, 4, 5 };
            Assert.AreEqual(7, SkipList.Count);
            for (int i = a.Length - 1; i >= 0; i--)
                Assert.AreEqual(b[i], a[i]);
        }

        [TestMethod]
        public void TestSimpleRemove()
        {
            SkipList = new SkipList<int>
            {
                0
            };
            SkipList.Remove(0);
            Assert.AreEqual(0, SkipList.Count);
        }

        [TestMethod]
        public void TestEasyMultiplyRemove()
        {
            SkipList = new SkipList<int>
            {
                0,
                5,
                2,
                1,
                3,
                4,
                0
            };
            for (int i = 0; i < 3; i++)
                SkipList.Remove(i);
            var a = GetValues(SkipList);
            var b = new[] { 0, 3, 4, 5 };
            Assert.AreEqual(4, SkipList.Count);
            for (int i = a.Length - 1; i >= 0; i--)
                Assert.AreEqual(b[i], a[i]);
        }

        [TestMethod]
        public void TestFullMultiplyRemove()
        {
            SkipList = new SkipList<int>
            {
                0,
                5,
                2,
                1,
                3,
                4,
                0
            };
            SkipList.Remove(0);
            for (int i = 0; i < 10; i++)
                SkipList.Remove(i);
            Assert.AreEqual(0, SkipList.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            SkipList = new SkipList<int>
            {
                0,
                5,
                2,
                1,
                3,
                4,
                0
            };
            Assert.AreEqual(true, SkipList.Contains(0));
            Assert.AreEqual(true, SkipList.Contains(2));
            Assert.AreEqual(true, SkipList.Contains(4));
            Assert.AreEqual(true, SkipList.Contains(5));
            Assert.AreEqual(false, SkipList.Contains(6));
        }
    }
}
