using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    [TestFixture]
    public class BinaryTreeInTask3_should
    {
        //Эта черная магия нужна, чтобы код тестов, которые используют индексацию, компилировался 
        //при отсутствии индексатора в вашем классе.
        //Совсем скоро вы и сами научитесь писать что-то подобное.

        public static PropertyInfo GetIndexer<T>(BinaryTree<T> t)
            where T : IComparable
        {
            return t.GetType()
                .GetProperties()
                .Select(z => new { prop = z, ind = z.GetIndexParameters() })
                .SingleOrDefault(z => z.ind.Length == 1 && z.ind[0].ParameterType == typeof(int))
                ?.prop;
        }

        public static Func<int, T> MakeAccessor<T>(BinaryTree<T> tree)
            where T : IComparable
        {
            var prop = GetIndexer(tree);
            var param = Expression.Parameter(typeof(int));
            return Expression.Lambda<Func<int, T>>(
                    Expression.MakeIndex(Expression.Constant(tree), prop, new[] { param }),
                    param)
                .Compile();
        }

        public void Test<T>(IEnumerable<T> values)
            where T : IComparable
        {
            var shuffledValues = values.Shuffle();
            var tree = new BinaryTree<T>();
            if (GetIndexer(tree) == null)
                Assert.Fail("Your BinaryTree does not implement indexing");
            foreach (var e in shuffledValues)
                tree.Add(e);
            var orderedValues = shuffledValues.OrderBy(z => z).ToList();
            var indexer = MakeAccessor(tree);
            for (int i = 0; i < orderedValues.Count; i++)
                Assert.AreEqual(orderedValues[i], indexer(i));
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 30)]
        [TestCase(20, 100)]
        public void SupportIndexersForIntValues(int start, int count)
        {
            Test(Enumerable.Range(start, count));
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 30)]
        [TestCase(20, 100)]
        public void SupportIndexersForStringValues(int start, int count)
        {
            Test(Enumerable.Range(start, count).Select(n => n.ToString()));
        }

    }
}