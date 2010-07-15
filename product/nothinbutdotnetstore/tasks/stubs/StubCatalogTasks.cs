using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return Enumerable.Range(1, 1000).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Product> get_all_products_in(Department department)
        {
            return Enumerable.Range(1, 1000).Select(x => new Product {name = x.ToString("Product 0")});
        }

        public IEnumerable<Department> get_all_sub_departments_from(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> get_all_sub_departments_in(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Department { name = x.ToString("Sub Department 0") });
        }
    }
}