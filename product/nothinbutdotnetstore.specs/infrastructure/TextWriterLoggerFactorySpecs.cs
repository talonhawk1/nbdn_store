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
                                            DefaultTextWriterLoggerFactory>
        {
        }

        [Subject(typeof(TextWriterLoggerFactory))]
        public class when_creating_textwriterlogger : concern
        {
            Establish c = () =>
            {
            };

            Because b = () =>
                result = sut.get_textWriterLogger();

            It should_return_a_textwriterlogger = () =>
                result.ShouldBeAn<TextWriterLogger>();

            static TextWriterLogger result;
        }
    }
}