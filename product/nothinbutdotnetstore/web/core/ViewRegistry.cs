namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        string get_path_to_view_for<ViewModel>();
    }
}