using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparableEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> items;
        ComparerBuilder<T> comparer_builder;

        public ComparableEnumerable(IEnumerable<T> items, ComparerBuilder<T> comparer_builder)
        {
            this.items = items;
            this.comparer_builder = comparer_builder;
        }

        public ComparableEnumerable<T> then_by<PropertyType>(Func<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableEnumerable<T>(items, comparer_builder.then_by(accessor));
        }

        public ComparableEnumerable<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableEnumerable<T>(items, comparer_builder.then_by(accessor,SortDirections.descending));
        }

        public IEnumerator<T> GetEnumerator()
        {
            var sorted = new List<T>(items);
            sorted.Sort(comparer_builder);
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}