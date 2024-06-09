using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
