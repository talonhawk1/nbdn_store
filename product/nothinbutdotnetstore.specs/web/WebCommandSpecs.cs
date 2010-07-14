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
        
             It first_observation = () =>        
                 
         }
     }
 }
