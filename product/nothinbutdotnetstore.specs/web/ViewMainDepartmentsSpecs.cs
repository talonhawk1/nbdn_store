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
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        [Subject(typeof(ViewMainDepartments))]
        public class when_vieing_the_list_of_main_departments_in_the_store : concern
        {
            Establish c = () =>
            {
                catalog_tasks = the_dependency<CatalogTasks>();
                response_engine = the_dependency<ResponseEngine>();
                request = an<Request>();

                main_departments = new List<Department>();

                catalog_tasks.Stub(x => x.get_all_main_departments()).Return(main_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_main_departments = () =>
                response_engine.received(x => x.display(main_departments));

            static ResponseEngine response_engine;
            static IEnumerable<Department> main_departments;
            static Request request;
            static CatalogTasks catalog_tasks;
        }
    }
}