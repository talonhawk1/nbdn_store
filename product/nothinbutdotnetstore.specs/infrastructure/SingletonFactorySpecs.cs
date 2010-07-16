using System;
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
                provide_a_basic_sut_constructor_argument<DependencyFactory>(new OurFactory());
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

        public class OurFactory : DependencyFactory
        {
            public object create()
            {
                return new OurClass();
            }
        }
    }

    class OurClass
    {
    }
}