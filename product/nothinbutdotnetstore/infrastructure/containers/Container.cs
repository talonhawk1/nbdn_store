using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface Container
    {
        Dependency an_instance_of<Dependency>();
        object an_instance_of(Type dependency_type);
    }
}