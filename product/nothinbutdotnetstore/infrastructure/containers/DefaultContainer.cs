using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DefaultContainer : Container
    {
        public Dependency an_instance_of<Dependency>()
        {
            throw new NotImplementedException();
        }

        public void register_instance<Dependency>(Dependency instance)
        {
            throw new NotImplementedException();
        }
    }
}