namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        ViewFor<ViewModel> create_view<ViewModel>(ViewModel view_model);
    }
}