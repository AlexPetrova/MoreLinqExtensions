using LinqMoreExtensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace LinqMoreExtensions.Tests
{
    public class Filter_Should
    {
        [Test]
        public void ApplyFilter()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var expected = new[] { 2, 4 };

            var result = arr.Filter(x => x % 2 == 0);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test]
        public void BeLazy()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var count = 0;

            var result = arr.Filter(x => {
                count++;
                return x % 2 == 0;
            });

            Assert.AreEqual(0, count);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Filter(x => x == 1);
            });
        }
    }
}
