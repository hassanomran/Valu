using valu.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.InterFaces.Services
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployee(EmployeeDTO taskDTO);
        Task<bool> UpdateEmployee(EmployeeDTO taskDTO);
        Task<bool> DeleteEmployee(int id);
        Task<EmployeeDTO> GetEmployeeByID(int id);
        Task<List<EmployeeDTO>> GetAllEmployee();
    }
}
