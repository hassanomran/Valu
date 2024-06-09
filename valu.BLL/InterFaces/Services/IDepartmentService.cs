using valu.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.InterFaces.Services
{
    public interface IDepartmentService
    {
        Task<bool> AddDepartment(DepartmentDTO DepartmentDTO);
        Task<bool> UpdateDepartment(DepartmentDTO DepartmentDTO);
        Task<bool> DeleteDepartment(int id);
        Task<DepartmentDTO> GetDepartmentByID(int id);
        Task<List<DepartmentDTO>> GetAllDepartment();
    }
}
