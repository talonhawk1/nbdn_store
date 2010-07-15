using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class DefaultTextWriterLoggerFactory : TextWriterLoggerFactory
    {
        public TextWriterLogger get_textWriterLogger()
        {
            return new TextWriterLogger(new StringWriter());
        }
    }
}