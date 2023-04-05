using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsModule.Business.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business
{
    public static class BusinessConfiguration
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessDependencyInjection();
            services.AddSecurityInjection(configuration);
            return services;
        }
    }
}
