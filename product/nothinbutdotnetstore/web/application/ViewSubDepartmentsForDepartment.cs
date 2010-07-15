using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartmentsForDepartment : ApplicationCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewSubDepartmentsForDepartment(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_all_sub_departments_from(request.get_query_string()));
        }
    }
}