using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewFor<ViewModel> : IHttpHandler
    {
        ViewModel model { get; set; }
    }
}