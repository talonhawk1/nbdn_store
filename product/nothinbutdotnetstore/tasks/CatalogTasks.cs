using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<Department> get_all_main_departments();
        IEnumerable<Product> get_all_products_for_department(int id);
        IEnumerable<Department> get_all_sub_departments_from(string department_name);
    }
}