using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProducts : ApplicationCommand
    {
        ResponseEngine response_engine;
        CatalogTasks catalog;

        public ViewProducts() : this(new DefaultResponseEngine(),
                                     new StubCatalogTasks())
        {
        }

        public ViewProducts(ResponseEngine response_engine, CatalogTasks catalog)
        {
            this.response_engine = response_engine;
            this.catalog = catalog;
        }

        public void process(Request request)
        {
            response_engine.display(catalog.get_all_products_in(request.map<Department>()));
        }
    }
}