using System;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationCommand
    {
        private Department _department;

        public ViewMainDepartments(Department department)
        {
            _department = department;
        }
        public void process(Request request)
        {
            _department.GetDepartments();
        }
    }
}