namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        WebCommand get_command_that_can_handle(Request request);
    }
}