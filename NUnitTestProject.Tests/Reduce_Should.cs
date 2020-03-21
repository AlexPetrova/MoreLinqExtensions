using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace NUnitTestProject.Tests
{
    public class Reduce_Should
    {
        [Test]
        public void ApplyReducer()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var expected = 10;

            var result = arr.Reduce((current, initialValue) => current + initialValue, 0);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Reduce((x, y) => x, 0);
            });
        }
    }
}
