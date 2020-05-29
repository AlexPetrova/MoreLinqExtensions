using LinqMoreExtensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace LinqMoreExtensions.Tests
{
    public class Unique_Should
    {
        [Test]
        public void ReturnsAllUniqueItems()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };
            var expected = new[] { 1, 2, 6, 3 };

            var result = arr.Unique();

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Unique();
            });
        }
    }
}
