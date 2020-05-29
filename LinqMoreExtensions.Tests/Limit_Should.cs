using LinqMoreExtensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnitTestProject.Tests
{
    public class Limit_Should
    {
        [Test]
        public void ReturnsLimitCountOfElements()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };
            var expected = new[] { 1, 2 };

            var result = arr.Limit(2);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void ReturnAll_LimitBiggerThanLenght()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };

            var result = arr.Limit(10);

            Assert.IsTrue(arr.SequenceEqual(result));
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Limit(1);
            });
        }
    }
}
