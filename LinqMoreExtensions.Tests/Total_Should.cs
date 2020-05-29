using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace LinqMoreExtensions.Tests
{
    public class Total_Should
    {
        [Test]
        public void ReturnsTotalCountOfMatch()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };

            var result = arr.Total(x => x % 2 == 0);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void ReturnsZero_WhenNoMatch()
        {
            var arr = new[] { 1, 2, 3 };

            var result = arr.Total(x => x == 4);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Total(x => true);
            });
        }
    }
}
