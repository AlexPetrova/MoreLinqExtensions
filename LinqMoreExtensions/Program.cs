using System;

namespace LinqMoreExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            int product = numbers.Reduce(
                (next, currentProduct) => next * currentProduct, 1);
            int sum = numbers.Reduce((next, currentSum) => next + currentSum, 0);
        }
    }
}
