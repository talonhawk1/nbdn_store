 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class WebCommandSpecs
     {
         public abstract class concern : Observes<WebCommand,
                                             DefaultWebCommand>
         {
        
         }

         [Subject(typeof(DefaultWebCommand))]
         public class when_determining_whether_it_can_handle_a_request : concern
         {
             Establish c = () =>
             {

             };

             Because b = () => result = sut.can_handle(request);

             It should_return_success_or_failure = () =>
                 web_command.received(x => x.can_handle(request));

             static WebCommand result;
         }
     }
 }
