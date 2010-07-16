namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface Container
    {
        Dependency an_instance_of<Dependency>();
    }
}