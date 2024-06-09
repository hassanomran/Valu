using AutoMapper;
using valu.BLL.DTOS;
using valu.BLL.InterFaces.Repositories;
using valu.BLL.InterFaces.Services;
using valu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.Implementation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _genericRepository;
        private readonly IGenericRepository<Department> _DepartmentSergenericRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
             IGenericRepository<Employee> genericRepository,
              IGenericRepository<Department> USergenericRepository,
              IMapper mapper
            )
        {
            _genericRepository = genericRepository;
            _DepartmentSergenericRepository = USergenericRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                bool result = false;
                if (employeeDTO != null)
                {

                    Employee EmployeeObject = new Employee
                    {
                        Name = employeeDTO.Name,
                        DepartmentID = employeeDTO.DepartmentID,
                        Identification = employeeDTO.Identification,
                        phone = employeeDTO.phone,
                        mobileNumber = employeeDTO.mobileNumber,
                        HireDate = employeeDTO.HireDate,
                        Position = employeeDTO.Position,
                        IsActive = true
                    };
                    await _genericRepository.AddAsync(EmployeeObject);
                    await _genericRepository.SaveChangesAsync();
                    if (_genericRepository.SaveChangesAsync() != null)
                    {
                        result = true;
                    }
                    else { result = false; }
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                bool result = false;
                if (id > 0)
                {
                    var GetEmployeeObject = await _genericRepository.GetSingleAsync(x => x.Id == id);

                    if (GetEmployeeObject != null)
                    {
                        GetEmployeeObject.IsActive = false;
                    }
                    await _genericRepository.UpdateAsync(GetEmployeeObject);
                    await _genericRepository.SaveChangesAsync();
                    if (_genericRepository.SaveChangesAsync != null)
                    {
                        result = true;
                    }
                    else { result = false; }


                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            try
            {
              
                var AllEmployee = _genericRepository.
                    GetWithIncludeAsync(x =>x.IsActive == true, e => e.Department).Result;
                var MapAllEmployee = _mapper.Map<List<EmployeeDTO>>(AllEmployee);
                return MapAllEmployee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeDTO> GetEmployeeByID(int id)
        {
            try
            {
                var AllEmployee = _genericRepository.GetSingleAsync(x => x.IsActive == true
            ).Result;
                var MapAllEmployee = _mapper.Map<EmployeeDTO>(AllEmployee);
                return MapAllEmployee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                bool result = false;
                if (employeeDTO != null)
                {
                    var Employee = _genericRepository.GetByIdAsync(employeeDTO.Id).Result;
                    Employee.Name = employeeDTO.Name;
                    Employee.DepartmentID = employeeDTO.DepartmentID;
                    Employee.Identification = employeeDTO.Identification;
                    Employee.phone = employeeDTO.phone;
                    Employee.mobileNumber = employeeDTO.mobileNumber;
                    Employee.HireDate = employeeDTO.HireDate;
                    Employee.Position = employeeDTO.Position;
                    await _genericRepository.UpdateAsync(Employee);
                    await _genericRepository.SaveChangesAsync();
                    if (_genericRepository.SaveChangesAsync() != null)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
