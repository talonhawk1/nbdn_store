using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class IOCSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(IOC))]
        public class when_providing_access_to_the_underlying_container : concern
        {
            Establish c = () =>
            {
                container = an<Container>();

                resolver = () => container;

                change(() => IOC.factory_resolver).to(resolver);
            };

            Because b = () =>
                result = IOC.get;

            It should_return_a_container = () =>
                result.ShouldEqual(container);

            static Container result;
            static Container container;
            static Func<Container> resolver;
        }
    }
}