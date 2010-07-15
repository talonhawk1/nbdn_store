using System.IO;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.simple;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class TextWriterLogSpecs
    {
        public abstract class concern : Observes<Logger,
                                            TextWriterLogger>
        {
        }

        [Subject(typeof(TextWriterLogger))]
        public class when_writing_an_information_message : concern
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                provide_a_basic_sut_constructor_argument<TextWriter>(new StringWriter(builder));
            };

            Because b = () =>
                sut.informational("This is a state based test");

            It should_write_the_message_to_its_text_writer = () =>
                builder.ToString().ShouldEqual("This is a state based test\r\n");

            static StringBuilder builder;
        }
    }
}