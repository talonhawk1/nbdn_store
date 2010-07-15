using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility.filtering;
using nothinbutdotnetprep.utility.sorting;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Predicate<T> criteria)
        {
            foreach (var item in items) if (criteria(item)) yield return item;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return all_items_matching(items, criteria.is_satisfied_by);
        }


        public static ComparableEnumerable<T> sort_by<T, PropertyType>(this IEnumerable<T> items, Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_by(accessor, SortDirections.normal);
        }

        public static ComparableEnumerable<T> sort_by<T, PropertyType>(this IEnumerable<T> items, Func<T, PropertyType> accessor, SortDirection direction)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_by(
                new PropertyComparer<T, PropertyType>(accessor,
                                                      direction.apply_against(new ComparableComparer<PropertyType>()))
                );
        }

        public static ComparableEnumerable<T> sort_by<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            return new ComparableEnumerable<T>(items, new ComparerBuilder<T>(comparer));
        }
    }
}