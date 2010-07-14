using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class WebCommandSpecs
    {
        public abstract class concern : Observes<WebCommand,
                                            DefaultWebCommand>
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument<RequestCriteria>(x => true);
            };
        }

        [Subject(typeof(DefaultWebCommand))]
        public class when_determining_whether_it_can_handle_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_criteria = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
        }

        [Subject(typeof(DefaultWebCommand))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_command = the_dependency<ApplicationCommand>();
                request = an<Request>();
            };

            Because b = () =>
                sut.process(request);


            It should_delegate_the_processing_to_an_application_specific_command = () =>
                application_command.received(x => x.process(request));
  

            static Request request;
            static ApplicationCommand application_command;
        }

    }
}