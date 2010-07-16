using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewRegistry : ViewRegistry 
    {
        readonly IEnumerable<Type> view_types;

        public DefaultViewRegistry(IEnumerable<Type> view_types)
        {
            this.view_types = view_types;
        }

        public string get_path_to_view_for<ViewModel>()
        {
            var view_model_type = typeof (ViewModel);
            var file_name = view_types
                .Where(x => x.GetInterface("ViewFor`1").GetGenericArguments()[0] == view_model_type)
                .Select(x => x.Name).FirstOrDefault();
            return string.Format("~/views/{0}.aspx", file_name);
        }
    }
}