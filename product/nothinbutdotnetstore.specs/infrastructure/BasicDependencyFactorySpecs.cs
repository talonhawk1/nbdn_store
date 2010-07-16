 using System;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class BasicDependencyFactorySpecs
     {
         public abstract class concern : Observes<DependencyFactory,
             BasicDependencyFactory>
         {
        
         }

         [Subject(typeof(BasicDependencyFactory))]
         public class when_creating_an_object : concern
         {
             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument<Func<object>>(() => new ClassWithDependencies(null));
             };

             Because b = () =>
                 result=sut.create();

             It should_create_the_item_using_the_factory_delegate = () =>
                 result.ShouldBeAn<ClassWithDependencies>();

             static object result;
         }

         public interface TestInterface1{}
         public class ClassWithDependencies
         {
             public ClassWithDependencies(TestInterface1 test_interface1){}
         }
     }
 }
