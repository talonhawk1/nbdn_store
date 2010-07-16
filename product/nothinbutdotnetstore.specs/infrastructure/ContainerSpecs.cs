using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(IOC))]
        public class when_providing_access_to_the_underlying_container : concern
        {
            Establish c = () =>
            {
                container = an<IOC>();
                container_factory = an<ContainerFactory>();

                resolver = () => container_factory;

                container_factory.Stub(x => x.get_container_for(typeof(when_providing_access_to_the_underlying_container))).Return(container);

                change(() => IOC.factory_resolver).to(resolver);

            };

            Because b = () =>
                result = IOC.an;

            It should_return_a_container = () =>
                result.ShouldEqual(container);

            static IOC result;
            static IOC container;
            static ContainerFactory container_factory;
            static Func<ContainerFactory> resolver;
        }
    }
}
