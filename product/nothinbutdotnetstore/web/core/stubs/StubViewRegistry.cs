using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public string get_path_to_view_for<ViewModel>()
        {
            if (typeof(ViewModel) == typeof(IEnumerable<Department>))
            {
                return "~/views/DepartmentBrowser.aspx";
            }
            return "~/views/ProductBrowser.aspx";
        }
    }
}