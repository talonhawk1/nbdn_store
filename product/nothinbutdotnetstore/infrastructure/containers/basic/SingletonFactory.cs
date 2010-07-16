namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class SingletonFactory : DependencyFactory
    {
        DependencyFactory dependency_factory;
        object instance;

        public SingletonFactory(DependencyFactory dependency_factory)
        {
            this.dependency_factory = dependency_factory;
        }

        public object create()
        {
            return instance ?? (instance = dependency_factory.create());
        }
    }
}