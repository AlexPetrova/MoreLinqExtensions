using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace NUnitTestProject.Tests
{
    public class Join_Should
    {
        [Test]
        public void ReturnJoinedElements()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var expected = "1, 2, 3, 4";

            var result = arr.Join(", ");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnEmptyString_EmptyCollection()
        {
            var arr = new int[0];
            var expected = "";

            var result = arr.Join(", ");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NoSeparatorAtEnd_OneElement()
        {
            var arr = new[] { 1 };
            var expected = "1";

            var result = arr.Join(", ");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.Join("");
            });
        }
    }
}
