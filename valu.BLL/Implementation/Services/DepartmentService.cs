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
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _genericRepository;
        private readonly IMapper _mapper;

        public DepartmentService(
            IGenericRepository<Department> genericRepository,
              IMapper mapper
            )
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddDepartment(DepartmentDTO DepartmentDTO)
        {
            try
            {
                bool result = false;
                if (DepartmentDTO != null)
                {
                    Department DepartmentObject = new Department
                    {
                        Name = DepartmentDTO.Name,
                        Details = DepartmentDTO.Details,
                        Order = DepartmentDTO.Order,
                        IsActive = true
                    };
                    
                    await _genericRepository.AddAsync(DepartmentObject);
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

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                bool result = false;
                if (id > 0)
                {
                    var GetDepartmentObject = await _genericRepository.GetSingleAsync(x => x.Id == id);

                    if (GetDepartmentObject != null)
                    {
                        GetDepartmentObject.IsActive = false;
                    }
                    await _genericRepository.UpdateAsync(GetDepartmentObject);
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
        public async Task<List<DepartmentDTO>> GetAllDepartment()
        {
            try
            {
                var AllDepartments = _genericRepository.GetListAsync(x => x.IsActive == true).Result;
                var MapAllDepartments = _mapper.Map<List<DepartmentDTO>>(AllDepartments);
                return MapAllDepartments;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async Task<DepartmentDTO> GetDepartmentByID(int id)
        {
            try
            {
                var Department = _genericRepository.GetSingleAsync(x => x.Id == id && x.IsActive == true);
                var mapDepartment = _mapper.Map<DepartmentDTO>(Department);
                return mapDepartment;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateDepartment(DepartmentDTO DepartmentDTO)
        {
            try
            {
                bool result = false;
                if (DepartmentDTO != null)
                {
                    var Department = _genericRepository.GetByIdAsync(DepartmentDTO.Id).Result;
                    Department.Name = DepartmentDTO.Name;
                    Department.Details = DepartmentDTO.Details;
                    Department.Order = DepartmentDTO.Order;
                    await _genericRepository.UpdateAsync(Department);
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
