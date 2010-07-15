namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public string get_path_to_view_for<ViewModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}