using System;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.simple;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class TextWriterLoggerFactorySpecs
    {
        public abstract class concern : Observes<TextWriterLoggerFactory,
                                            TextWriterLoggerFactory>
        {
        }

        [Subject(typeof(TextWriterLoggerFactory))]
        public class when_creating_textwriterlogger : concern
        {
            Establish c = () =>
            {
            };

            Because b = () =>
                result = sut.get_logger_for(typeof(int));

            It should_return_a_textwriterlogger = () =>
                result.ShouldBeAn<TextWriterLogger>();

            static Logger result;
        }
    }
}