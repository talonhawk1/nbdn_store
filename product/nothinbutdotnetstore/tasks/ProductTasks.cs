using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductTasks
    {
        IEnumerable<Product> get_all_products_for_department(int id);
    }
}