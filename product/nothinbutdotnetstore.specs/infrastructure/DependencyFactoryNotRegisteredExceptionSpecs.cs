 using System;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class DependencyFactoryNotRegisteredExceptionSpecs
     {
         public abstract class concern : Observes<Exception,
                                             DependencyFactoryNotRegisteredException>
         {
        
         }

         [Subject(typeof(DependencyFactoryNotRegisteredException))]
         public class when_displaying_its_message : concern
         {
             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument(typeof(IDbConnection));
             };

             Because b = () =>
                 result = sut.Message;

             It should_include_the_name_of_the_type_that_does_not_have_a_factory_registered = () =>
                 result.ShouldContain(typeof(IDbConnection).Name);


             static string result;
                 
         }
     }
 }
