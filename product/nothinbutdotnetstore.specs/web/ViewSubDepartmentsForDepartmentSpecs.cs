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
    public class ViewSubDepartmentsForDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartmentsForDepartment>
        {
        }

        [Subject(typeof(ViewSubDepartmentsForDepartment))]
        public class when_viewing_the_list_of_sub_departments_in_the_store : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                catalog_tasks = the_dependency<CatalogTasks>();
                request = an<Request>();
                department_name = "Produce";
                sub_departments = new Department[0];
                request.Stub(x => x.get_query_string()).Return(department_name);
                catalog_tasks.Stub(x => x.get_all_sub_departments_from(department_name)).Return(sub_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_sub_departments = () =>
               response_engine.received(x => x.display(sub_departments));

            static ResponseEngine response_engine;
            static Request request;
            static CatalogTasks catalog_tasks;
            static string department_name;
            static IEnumerable<Department> sub_departments;
        }
    }
    }
