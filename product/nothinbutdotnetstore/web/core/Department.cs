using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface Department
    {
        IEnumerable GetDepartments(); 
    }

    public class StoreDepartment : Department
    {
        public IEnumerable GetDepartments()
        {
            return new List<string> {"Department 1", "Department 2"};
        }
    }
}