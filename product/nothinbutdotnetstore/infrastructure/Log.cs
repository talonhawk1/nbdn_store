using System;
using System.Diagnostics;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure
{
    public class Log
    {
        public static Func<LoggerFactory> factory_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured by the application startup pipeline");
        };

        public static Logger an
        {
            get
            {
                var frame = new StackFrame(1);
                MethodBase method = frame.GetMethod();
                return factory_resolver().get_logger_for(method.ReflectedType);
            }
        }
    }
}