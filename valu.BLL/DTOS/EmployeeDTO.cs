using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.DTOS
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Name is required.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Identification is required.")]

        public string Identification { get; set; }
        [RegularExpression(@"^\(?\d{3}\)?-?\s*-?\d{3}-?\s*-?\d{4}$",
        ErrorMessage = "Invalid phone number format. Expected format: (123) 456-7890 or 123-456-7890 or 1234567890")]
        public string phone { get; set; }
        [Required(ErrorMessage = "mobile number is required.")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Invalid mobile number format.")]
        public string mobileNumber { get; set; }
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Position is required.")]

        public string Position { get; set; }
        public bool IsActive { get; set; }
    }
}
