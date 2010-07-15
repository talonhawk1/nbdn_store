using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ReverseComparer<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> inner;

        public ReverseComparer(IComparer<ItemToSort> inner)
        {
            this.inner = inner;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return - inner.Compare(x, y);
        }
    }
}