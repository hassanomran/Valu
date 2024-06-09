using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string phone { get; set; }
        public string mobileNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }


    }
}
