using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.DTOS
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details is required.")]
        public string Details { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public int Order { get; set; }
        public bool IsActive { get; set; }

    }
}
