using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicContainer : Container
    {
        public Dependency an_instance_of<Dependency>()
        {
            throw new NotImplementedException();
        }
    }
}