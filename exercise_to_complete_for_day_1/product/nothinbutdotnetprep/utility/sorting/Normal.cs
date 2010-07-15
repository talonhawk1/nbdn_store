using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Normal : SortDirection
    {
        public IComparer<T> apply_against<T>(IComparer<T> comparer)
        {
            return comparer;
        }
    }
}