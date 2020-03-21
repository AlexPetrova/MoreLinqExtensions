using System;
using System.Collections.Generic;
using System.Text;

namespace LinqMoreExtensions
{
    public static class LinqMoreExtensions
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> src, Func<T, R> mapper)
        {
            if (src == null)
                throw new ArgumentNullException();

            return ApplyMap(src, mapper);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> src, Predicate<T> filter)
        {
            if (src == null)
                throw new ArgumentNullException();

            return ApplyFilter(src, filter);
        }

        public static R Reduce<T, R>(this IEnumerable<T> src, Func<T, R, R> reducer, R initialValue)
        {
            if (src == null)
                throw new ArgumentNullException();

            foreach (var item in src)
            {
                initialValue = reducer(item, initialValue);
            }

            return initialValue;
        }

        public static void Foreach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src == null)
                throw new ArgumentNullException();

            foreach (var item in src)
            {
                action(item);
            }
        }

        public static string Join<T>(this IEnumerable<T> src, string separator)
        {
            if (src == null)
                throw new ArgumentNullException();

            var builder = new StringBuilder();

            foreach (var item in src)
            {
                builder.Append(item);
                builder.Append(separator);
            }

            if (builder.Length > 0)
            {
                builder.Length -= separator.Length;
            }

            return builder.ToString();
        }

        public static T FindFirst<T>(this IEnumerable<T> src, Predicate<T> predicate)
        {
            if (src == null)
                throw new ArgumentNullException();

            foreach (var item in src)
            {
                if (predicate(item))
                    return item;
            }

            return default;
        }

        public static IEnumerable<T> Unique<T>(this IEnumerable<T> src)
        {
            if (src == null)
                throw new ArgumentNullException();

            return FindUnique(src);
        }

        public static IEnumerable<T> Limit<T>(this IEnumerable<T> src, int limit)
        {
            if (src == null)
                throw new ArgumentNullException();

            return ApplyLimit(src, limit);
        }
        
        public static bool AtLeastOne<T>(this IEnumerable<T> src, Predicate<T> predicate)
        {
            if (src == null)
                throw new ArgumentNullException();

            foreach (var item in src)
            {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        public static int Total<T>(this IEnumerable<T> src, Predicate<T> predicate)
        {
            if (src == null)
                throw new ArgumentNullException();

            var matches = 0;
            foreach (var item in src)
            {
                if (predicate(item))
                    matches++;
            }

            return matches;
        }

        private static IEnumerable<R> ApplyMap<T, R>(IEnumerable<T> src, Func<T, R> mapper)
        {
            foreach (var item in src)
            {
                yield return mapper(item);
            }
        }

        private static IEnumerable<T> ApplyFilter<T>(IEnumerable<T> src, Predicate<T> filter)
        {
            foreach (var item in src)
            {
                if (filter(item))
                    yield return item;
            }
        }

        private static IEnumerable<T> ApplyLimit<T>(IEnumerable<T> src, int limit)
        {
            using (var enumerator = src.GetEnumerator())
            {
                while (limit != 0 && enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                    limit--;
                }
            }
        }

        private static IEnumerable<T> FindUnique<T>(IEnumerable<T> src)
        {
            var uniqueItems = new HashSet<T>();

            foreach (var item in src)
            {
                if (!uniqueItems.Contains(item))
                {
                    uniqueItems.Add(item);
                    yield return item;
                }
            }
        }
    }
}
