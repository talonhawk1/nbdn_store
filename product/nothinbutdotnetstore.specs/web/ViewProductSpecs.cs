using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
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
                catalog_tasks = the_dependency<ProductTasks>();
                response_engine = the_dependency<ResponseEngine>();
                request = an<Request>();

                main_products = new List<Product>();

                catalog_tasks.Stub(x => x.get_all_products_for_department(Arg<int>.Is.Anything)).Return(main_products);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_products = () =>
                response_engine.received(x => x.display(main_products));

            static ResponseEngine response_engine;
            static IEnumerable<Product> main_products;
            static Request request;
            static ProductTasks catalog_tasks;
        }
    }
}