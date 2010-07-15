using Machine.Specifications;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.helpers;

namespace nothinbutdotnetstore.specs.web
{
    public class UrlHelperSpecs
    {
        public abstract class concern
        {
        }

        [Subject(typeof(Url))]
        public class when_creating_a_url_for_a_command : concern
        {
            Establish e = () =>
                department = new Department{id=42,name="Bob"};

            Because b = () =>
                result = Url.for_command<ViewSubDepartments>().with_input_model(department)
                    .with_parameter(x => x.id).with_parameter(x => x.name).get_url();

            It should_return_url_with_command_name_with_store_extension_with_params_in_query_string = () =>
                result.ShouldEqual(string.Format("ViewSubDepartments.store?id={0}&name={1}", 
                    department.id, department.name));

            static Department department;
            static string result;
        }
    }
}