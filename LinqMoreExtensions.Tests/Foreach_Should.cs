using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace NUnitTestProject.Tests
{
    public class Foreach_Should
    {
        [Test]
        public void ApplyAction()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var count = 0;

            arr.Foreach(x => count++);

            Assert.AreEqual(4, count);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Foreach(x => x++);
            });
        }
    }
}
