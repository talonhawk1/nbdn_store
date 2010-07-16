using System;
using System.Diagnostics;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static Logger an
        {
            get { return IOC.get.an_instance_of<LoggerFactory>().get_logger_for(calling_type()); }
        }

        static Type calling_type()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }
    }
}