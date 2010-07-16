 using System;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class DependencyCreationExceptionSpecs
     {
         public abstract class concern : Observes<Exception,
                                             DependencyCreationException>
         {
        
         }

         [Subject(typeof(DependencyCreationException))]
         public class when_its_message_property_is_displayed : concern
         {
             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument(typeof(IDbCommand));
             };

             Because b = () =>
                 result = sut.Message;


             It should_include_the_name_of_the_type_that_could_not_be_created_correctly = () =>
                 result.ShouldContain(typeof(IDbCommand).Name);


             static string result;
         }
     }
 }
