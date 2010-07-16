namespace nothinbutdotnetstore.web.core.helpers
{
    public class Url
    {
        public static UrlBuilder<Command> for_command<Command>() where Command : ApplicationCommand
        {
            return new UrlBuilder<Command>();
        }
    }
}