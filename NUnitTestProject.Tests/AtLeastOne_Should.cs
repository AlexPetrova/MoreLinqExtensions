using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace NUnitTestProject.Tests
{
    public class AtLeastOne_Should
    {
        [Test]
        public void ReturnOnFirstOccurrence()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };
            var index = -1;

            var result = arr.AtLeastOne(x =>
            {
                index++;
                return x == 2;
            });

            Assert.IsTrue(result);
            Assert.AreEqual(1, index);
        }

        [Test]
        public void ReturnFalse_NoOccurrence()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };

            var result = arr.AtLeastOne(x => x == 10);

            Assert.IsFalse(result);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.AtLeastOne(x => true);
            });
        }
    }
}
