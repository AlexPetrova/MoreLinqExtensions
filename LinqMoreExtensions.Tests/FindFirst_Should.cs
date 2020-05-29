using LinqMoreExtensions;
using NUnit.Framework;
using System;

namespace LinqMoreExtensions.Tests
{
    public class FindFirst_Should
    {
        [Test]
        public void ReturnFirstOccurrence()
        {
            var arr = new[] { 1, 2, 6, 3, 2 };
            var index = -1;
            var expected = 2;

            var result = arr.FindFirst(x =>
            {
                index++;
                return x == 2;
            });

            Assert.AreEqual(expected, 2);
            Assert.AreEqual(index, 1);
        }

        [Test]
        public void ReturnsDefault_WhenNoOccurrence()
        {
            var primitiveType = new[] { 1, 2, 6, 3, 2 };
            var referenceType = new[] { new { Name = "test" } };

            var resultPrimitive = primitiveType.FindFirst(x => x == 9);
            var resultReference = referenceType.FindFirst(x => x.Name == "test2");

            Assert.AreEqual(0, resultPrimitive);
            Assert.IsNull(resultReference);
        }

        [Test]
        public void Throw_WhenSourceIsNull()
        {
            int[] arr = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                arr.FindFirst(x => true);
            });
        }
    }
}
