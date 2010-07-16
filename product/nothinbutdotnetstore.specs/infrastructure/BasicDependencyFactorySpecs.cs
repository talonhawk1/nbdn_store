 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;

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
                 container = the_dependency<Container>();
                 provide_a_basic_sut_constructor_argument(typeof(ClassWithDependencies));
             };

             Because b = () =>
                 sut.create();

             It should_resolve_the_objects_dependencies = () =>
                 container.received(x => x.an_instance_of<TestInterface1>());

             static Container container;
         }

         public interface TestInterface1{}
         public class ClassWithDependencies
         {
             public ClassWithDependencies(TestInterface1 test_interface1){}
         }
     }
 }
