using System;
using System.Linq.Expressions;
using System.Text;

namespace nothinbutdotnetstore.web.core.helpers
{
    public class Url
    {
        public static string for_command<T, T1>(params Expression<Func<T1,object>>[] property_setters)
        {
            var url = new StringBuilder(string.Format("{0}.store", typeof (T).Name));


            foreach (var property_setter in property_setters)
            {
                var name = ((MemberExpression) property_setter.Body).Member.Name;
                if (url.ToString().EndsWith(".store"))
                {
                    url.AppendFormat("?{0}", name);

                }
            }
            return url.ToString();
        }
    }
}