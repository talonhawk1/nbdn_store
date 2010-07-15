using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public interface SortDirection
    {
        IComparer<T> apply_against<T>(IComparer<T> comparer);
    }
}