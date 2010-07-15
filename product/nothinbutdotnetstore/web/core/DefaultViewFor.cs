using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFor<ViewModel> : Page,ViewFor<ViewModel>
    {
        public ViewModel model { get; set; }
    }
}