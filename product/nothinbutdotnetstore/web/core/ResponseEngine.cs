namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void display<ViewModel>(ViewModel view_model);
    }
}