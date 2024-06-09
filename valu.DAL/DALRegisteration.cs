using valu.BLL.InterFaces.Repositories;
using valu.DAL.Database;
using valu.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.DAL
{
    public static class DALRegisteration
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDB>(op => op.UseSqlServer(configuration.GetConnectionString("valu")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
