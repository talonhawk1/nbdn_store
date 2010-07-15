using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewProductSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProducts>
        {
        }

        [Subject(typeof(ViewProducts))]
        public class when_vieing_the_list_of_products_in_the_store : concern
        {
            Establish c = () =>
            {
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                request = an<Request>();
                
                products_in_the_department = new List<Product>();
                department_id = 23;


                request.Stub(x => x.get_value_for(InputElements.department.id)).Return(department_id.ToString());

                catalog_tasks.Stub(x => x.get_all_products_for_department(department_id)).Return(products_in_the_department);

            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_products = () =>
                response_engine.received(x => x.display(products_in_the_department));

            static ResponseEngine response_engine;
            static IEnumerable<Product> products_in_the_department;
            static CatalogTasks catalog_tasks;
            static Request request;
            static int department_id;
        }
    }
}