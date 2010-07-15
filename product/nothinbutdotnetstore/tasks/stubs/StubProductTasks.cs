using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubProductTasks : ProductTasks
    {
        public IEnumerable<Product> get_all_products_for_department(int id)
        {
            return Enumerable.Range(1, 1000).Select(x => new Product { name = x.ToString("Product 0") });
        }
    }
}