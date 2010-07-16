using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class SingletonFactory : DependencyFactory
    {
        private readonly DependencyFactory _factory;

        public SingletonFactory(DependencyFactory factory)
        {
            _factory = factory;
        }

        public object create()
        {
            return _factory.create();
        }
    }
}