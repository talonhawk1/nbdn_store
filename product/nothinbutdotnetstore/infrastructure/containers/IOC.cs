using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class IOC
    {
        public static Func<Container> factory_resolver =
            delegate { throw new NotImplementedException("This needs to be configured by the application startup pipeline"); };

        public static Container get
        {
            get { return factory_resolver(); }
        }

    }
}