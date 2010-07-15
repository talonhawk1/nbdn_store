using System;
using System.Diagnostics;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static Func<LoggerFactory> factory_resolver =
            delegate { throw new NotImplementedException("This needs to be configured by the application startup pipeline"); };

        public static Logger an
        {
            get { return factory_resolver().get_logger_for(calling_type()); }
        }

        static Type calling_type()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }
    }
}