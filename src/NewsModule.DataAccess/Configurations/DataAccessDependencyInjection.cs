using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsModule.DataAccess.DataContexts;
using NewsModule.DataAccess.Repositories.Concrete;
using NewsModule.DataAccess.Repositories.Interfaces;
using NewsModule.DataAccess.UnitOfWorks;
using System.Diagnostics;

namespace NewsModule.DataAccess.Configurations
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccessDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlConnection = configuration.GetConnectionString("MsSQL") ?? "";

            services.AddDbContext<NewsDataContext>(options =>
            {
                options.UseSqlServer(connectionString: sqlConnection);
            });
            Debug.WriteLine(sqlConnection);
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
