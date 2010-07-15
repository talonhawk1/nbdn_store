using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class ComparerExtensions
    {
        public static IComparer<T> then_using<T>(this IComparer<T> first, IComparer<T> second)
        {
            return new ChainedComparer<T>(first, second);
        }

        public static IComparer<T> reverse<T>(this IComparer<T> to_reverse)
        {
            return new ReverseComparer<T>(to_reverse);
        }
    }
}