using AutoMapper;
using valu.BLL.DTOS;
using valu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<Employee, EmployeeDTO>()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));


        }
    }
}
