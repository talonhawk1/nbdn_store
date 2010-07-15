using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.criteria;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class StringContainsCommandNameSpecs
    {
        public abstract class concern : Observes<RequestCriteria>
        {
        }

        [Subject(typeof(RequestCriteria))]
        public class when_the_name_of_the_request_matches_an_application_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                request.Stub(x => x.raw_command).Return("sfdsafsfasdfsaf{0}.store".format_using(typeof(MyCommand).Name));
                create_sut_using(() => new StringContainsNameOfCommand(typeof(MyCommand).Name).matches);
            };

            Because b = () =>
                result = sut(request);

            It should_be_satisfied = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
        }

        class MyCommand : ApplicationCommand
        {
            public void process(Request request)
            {
            }
        }
    }
}