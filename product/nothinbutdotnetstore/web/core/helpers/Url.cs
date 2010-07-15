using System;
using System.Text;

namespace nothinbutdotnetstore.web.core.helpers
{
    public class Url
    {
        public static string for_command<T, T1>(params Func<T1, object>[] property_setters)
        {
            var url = new StringBuilder(string.Format("{0}.store", typeof (T).Name));
            foreach (var property_setter in property_setters)
            {
                if (url.ToString().EndsWith(".store"))
                {
                    url.Append("?");
                }
            }
            return url.ToString();
        }
    }
}