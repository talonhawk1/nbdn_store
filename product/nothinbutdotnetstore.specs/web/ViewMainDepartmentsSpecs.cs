 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

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
             It first_observation = () =>        
                 
         }
     }
 }
