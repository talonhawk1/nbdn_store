using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.specs
{
    public class TitleComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }
    }
}