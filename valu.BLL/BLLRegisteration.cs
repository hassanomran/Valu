using valu.BLL.Implementation.Services;
using valu.BLL.InterFaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL
{
    public static class BLLRegisteration
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
