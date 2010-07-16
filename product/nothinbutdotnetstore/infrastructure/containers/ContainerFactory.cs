using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface ContainerFactory
    {
        IOC get_container_for(Type type_that_requires_container_services);
    }
}
