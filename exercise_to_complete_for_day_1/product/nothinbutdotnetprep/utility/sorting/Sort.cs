using System;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
               new PropertyComparer<ItemToSort, PropertyType>(accessor, 
                   new ComparableComparer<PropertyType>()) 
                );
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor, params PropertyType[] sort_list)
        {
            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(accessor, 
                    new ListComparer<PropertyType>(sort_list)));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(by(accessor)));
        }
    }
}