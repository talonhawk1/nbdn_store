 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class ContainerSpecs
     {
         public abstract class concern : Observes<Container,
             DefaultContainer>
         {
        
         }

         [Subject(typeof(DefaultContainer))]
         public class when_getting_an_instance_of_a_dependency : concern
         {
             Establish c = () =>
             {
                 instance = new TestClass2();
                 sut.register_instance<TestInterface>(instance);
             };
             Because b = () =>
                 result = sut.an_instance_of<TestInterface>();

             It should_return_instance_of_dependency_that_is_registered_for_the_contract = () =>
                 result.ShouldEqual(instance);

             static TestInterface result;
             static TestClass2 instance;
         }

         interface TestInterface{}
         class TestClass1:TestInterface{}
         class TestClass2:TestInterface{}
         class TestClass3:TestInterface{}
     }
 }
