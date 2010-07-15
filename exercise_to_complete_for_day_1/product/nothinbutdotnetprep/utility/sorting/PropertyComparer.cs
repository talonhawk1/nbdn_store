using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<T,PropertyType> : IComparer<T>
    {
        IComparer<PropertyType> real_comparer;
        Func<T, PropertyType> accessor;

        public PropertyComparer(Func<T, PropertyType> accessor, IComparer<PropertyType> real_comparer)
        {
            this.accessor = accessor;
            this.real_comparer = real_comparer;
        }

        public int Compare(T x, T y)
        {
            return real_comparer.Compare(accessor(x), accessor(y));
        }
    }
}