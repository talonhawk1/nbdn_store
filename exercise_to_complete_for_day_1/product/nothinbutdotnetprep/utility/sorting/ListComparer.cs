using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ListComparer<PropertyType> : IComparer<PropertyType>
    {
        IList<PropertyType> rankings;

        public ListComparer(IList<PropertyType> rankings)
        {
            this.rankings = rankings;
        }

        public int Compare(PropertyType x, PropertyType y)
        {
            return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
        }
    }
}