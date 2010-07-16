using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicContainer : Container
    {
        readonly IDictionary<Type, DependencyFactory> factories;

        public BasicContainer(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public Dependency an_instance_of<Dependency>()
        {
            var type = typeof (Dependency);
            if (factories.ContainsKey(type))
            {
                return (Dependency) factories[type]();
            }

            throw new DependencyFactoryNotRegisteredException(type);
        }

        public void register_instance<Dependency>(Dependency instance)
        {
            throw new NotImplementedException();
        }
    }
}