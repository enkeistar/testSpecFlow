using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Par.Data
{
    public class Store
    {
        private String name;
        private List<String> employeeNames;
        private List<String> shifts;

        public Store(String name, List<String> employeeNames, List<String> shifts)
        {
            this.name = name;
            this.employeeNames = employeeNames;
            this.shifts = shifts;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }

        public List<string> EmployeeNames
        {
            get
            {
                return employeeNames;
            }
        }

        public List<string> Shifts
        {
            get
            {
                return shifts;
            }
        }

    }
}
