using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class SingletonFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            SingletonFactory>
        {
        }

        [Subject(typeof(SingletonFactory))]
        public class when_creating_multiple_instances_of_the_dependency : concern
        {
            Establish c = () =>
            {
                original_factory = the_dependency<DependencyFactory>();
                original_factory.Stub(factory => factory.create()).Return(new SqlConnection());
            };

            Because b = () =>
            {
                result = sut.create();
                result2 = sut.create();
            };

            It should_return_the_same_instance_each_time = () =>
                result.ShouldEqual(result2);

            static object result;
            static object result2;
            static DependencyFactory original_factory;
        }
    }
}