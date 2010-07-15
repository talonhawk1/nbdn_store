using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        ResponseEngine response_engine;
        CatalogTasks catalog;

        public ViewMainDepartments():this(new DefaultResponseEngine(),
            new StubCatalogTasks())
        {
        }

        public ViewMainDepartments(ResponseEngine response_engine, CatalogTasks catalog)
        {
            this.response_engine = response_engine;
            this.catalog = catalog;
        }

        public void process(Request request)
        {
            response_engine.display(catalog.get_all_main_departments());
        }

    }
}