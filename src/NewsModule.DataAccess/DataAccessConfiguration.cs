using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsModule.DataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.DataAccess
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessDependencyInjection(configuration);
            return services;
        }
    }
}
