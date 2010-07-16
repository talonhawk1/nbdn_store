using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class IOC
    {
        public static Func<ContainerFactory> factory_resolver =
            delegate { throw new NotImplementedException("This needs to be configured by the application startup pipeline"); };

        public static IOC an;
    }
}
