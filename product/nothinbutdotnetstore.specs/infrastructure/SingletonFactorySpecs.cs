using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class SingletonFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            SingletonFactory>
        {
        }

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
        }

        [Subject(typeof(Func<object>))]
        public class when_creating_an_instance_multiple_times : Observes<Func<object>>
        {
            Establish c = () =>
            {
                create_sut_using(() => () => new OurClass());
            };

            Because b = () =>
            {
                sut = sut.cache_result();
                result = sut();
                result2 = sut();
            };

            It should_return_the_same_instance_each_time = () =>
                result.ShouldEqual(result2);

            static object result;
            static object result2;
        }

        public class OurFactory : DependencyFactory
        {
            public object create()
            {
                return new OurClass();
            }
        }

        public class OurClass
        {
        }
    }
}