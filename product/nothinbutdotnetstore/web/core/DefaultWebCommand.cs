namespace nothinbutdotnetstore.web.core
{
    public class DefaultWebCommand : WebCommand
    {
        RequestCriteria request_criteria;
        ApplicationCommand application_command;

        public DefaultWebCommand(RequestCriteria request_criteria, ApplicationCommand application_command)
        {
            this.request_criteria = request_criteria;
            this.application_command = application_command;
        }

        public void process(Request request)
        {
            application_command.process(request);
        }

        public bool can_handle(Request request)
        {
            return request_criteria(request);
        }
    }
}