using nothinbutdotnetstore.infrastructure.logging.simple;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface Logger
    {
        void informational(string message);
    }
}