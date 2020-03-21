using LinqMoreExtensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnitTestProject.Tests
{
    public class Map_Should
    {
        [Test]
        public void ApplyMapper()
        {
            var arr = new[] { 1, 2, 3 };
            var expected = new[] { 2, 3, 4 };

            var result = arr.Map(x => x + 1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void BeLazy()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var count = 0;

            var result = arr.Map(x => {
                count++;
                return x;
            });

            Assert.AreEqual(0, count);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Map(x => x);
            });
        }
    }
}