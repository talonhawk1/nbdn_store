using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LoggerFactory
    {
        Logger get_logger_for(Type type_that_requires_logging_services);
    }
}