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
            return (Dependency) an_instance_of(typeof(Dependency));
        }

        void ensure_factory_exists_for(Type dependency)
        {
            if (factories.ContainsKey(dependency)) return;
            throw new DependencyFactoryNotRegisteredException(dependency);
        }

        public object an_instance_of(Type dependency_type)
        {
            ensure_factory_exists_for(dependency_type);
            try
            {
                return factories[dependency_type].create();
            }
            catch (Exception e)
            {
                throw new DependencyCreationException(e,dependency_type);
            }
        }
    }
}