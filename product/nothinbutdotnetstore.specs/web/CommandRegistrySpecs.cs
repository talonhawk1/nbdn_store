 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class CommandRegistrySpecs
     {
         public abstract class concern : Observes<CommandRegistry,
                                             DefaultCommandRegistry>
         {
             Establish c = () =>
             {
                 all_web_commands = new List<WebCommand>();
                 provide_a_basic_sut_constructor_argument<IEnumerable<WebCommand>>(all_web_commands);
                 request = an<Request>();
             };

             protected static List<WebCommand> all_web_commands;
             protected static Request request;
         }

         [Subject(typeof(DefaultCommandRegistry))]
         public class when_getting_a_command_that_can_handle_a_request_and_it_has_the_command : concern
         {

             Establish c = () =>
             {
                 command_that_can_process_request = an<WebCommand>();
                 all_web_commands.Add(command_that_can_process_request);
                 Enumerable.Range(1,100).each(x => all_web_commands.Add(an<WebCommand>()));

                 command_that_can_process_request.Stub(x => x.can_handle(request)).Return(true);
             };

             Because b = () =>
                 result = sut.get_command_that_can_handle(request);


             It should_return_the_command_that_can_handle_the_request = () =>
                 result.ShouldEqual(command_that_can_process_request);

             static WebCommand result;
             static WebCommand command_that_can_process_request;
         }

         [Subject(typeof(DefaultCommandRegistry))]
         public class when_attempting_to_get_a_command_for_a_request_and_it_does_not_have_the_command : concern
         {
             Because b = () =>
                 result = sut.get_command_that_can_handle(request);


             It should_return_a_missing_web_web_command = () =>
                 result.ShouldBeAn<MissingWebCommand>();

             static WebCommand result;
         }
     }
 }
