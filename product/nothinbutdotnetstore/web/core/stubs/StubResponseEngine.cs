using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<ViewModel>(ViewModel item)
        {
            HttpContext.Current.Items.Add("blah",item);
            HttpContext.Current.Server.Transfer("DepartmentBrowser.aspx",true);
        }
    }
}