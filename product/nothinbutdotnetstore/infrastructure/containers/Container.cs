namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface Container
    {
        Dependency an_instance_of<Dependency>();
        void register_instance<Dependency>(Dependency instance);
    }
}