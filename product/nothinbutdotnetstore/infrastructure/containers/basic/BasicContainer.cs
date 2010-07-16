using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicContainer : Container
    {
        IDictionary<Type, DependencyFactory> factories;

        public BasicContainer(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public Dependency an_instance_of<Dependency>()
        {
            ensure_factory_exists_for<Dependency>();
            return (Dependency) factories[typeof(Dependency)].create();
        }

        public object an_instance_of(Type dependency_type)
        {
            throw new NotImplementedException();
        }

        void ensure_factory_exists_for<Dependency>()
        {
            if (factories.ContainsKey(typeof(Dependency))) return;
            throw new DependencyFactoryNotRegisteredException(typeof(Dependency));
        }
    }
}