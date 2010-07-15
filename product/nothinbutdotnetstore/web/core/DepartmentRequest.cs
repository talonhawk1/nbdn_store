using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DepartmentRequest : Request
    {
        private IEnumerable<WebCommand> webCommands;
        private delegate RequestCriteria requestCriteria;

        public DepartmentRequest()
        {
            var applicationCommand = new ViewMainDepartments(new StoreDepartment());
            webCommands = new List<WebCommand>()
                              {
                                  new DefaultWebCommand(requestCriteria, applicationCommand)
                              }
        }



        public IEnumerable<WebCommand> getCommands()
        {
            return webCommands;
        }
    }
}