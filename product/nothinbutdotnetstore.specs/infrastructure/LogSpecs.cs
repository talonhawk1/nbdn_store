 
using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Log))]
        public class when_providing_access_to_the_underlying_logging_api : concern
        {
            Establish c = () =>
            {
                logger = an<Logger>();
                logger_factory = an<LoggerFactory>();
                container = an<Container>();
                container.Stub(x => x.an_instance_of<LoggerFactory>()).Return(logger_factory);

                Func<Container> resolver = () => container;
                change(() => IOC.factory_resolver).to(resolver);

                logger_factory.Stub(x => x.get_logger_for(typeof(when_providing_access_to_the_underlying_logging_api))).Return(logger);

            };

            Because b = () =>
                result = Log.an;

            It should_return_a_logger_bound_to_the_type_of_the_calling_type = () =>
                result.ShouldEqual(logger);

            static Logger result;
            static Logger logger;
            static LoggerFactory logger_factory;
            static Container container;
        }
    }
}
