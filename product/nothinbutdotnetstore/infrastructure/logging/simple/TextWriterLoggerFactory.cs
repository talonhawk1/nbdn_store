using System;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLoggerFactory : LoggerFactory
    {
        public Logger get_logger_for(Type type_that_requires_logging_services)
        {
            return new TextWriterLogger(Console.Out);
        }
    }
}