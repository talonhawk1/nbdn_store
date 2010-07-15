using Machine.Specifications;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.helpers;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.web
{
    public class UrlHelperSpecs
    {
        public abstract class concern {}

        [Subject(typeof (Url))]
        public class when_creating_a_url_for_a_command : concern
        {
            Establish e = () =>
                id = 42;

            Because b = () =>
                result = Url.for_command<ViewSubDepartments,Department>(x => x.id = id);

            It should_return_url_with_command_name_with_store_extension_with_params_in_query_string = () =>
                result.ShouldEqual(string.Format("ViewSubDepartments.store?id={0}",id));

            static int id;
            static string result;
        }
    }
}