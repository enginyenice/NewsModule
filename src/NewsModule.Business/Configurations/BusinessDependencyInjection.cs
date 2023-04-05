using Microsoft.Extensions.DependencyInjection;
using NewsModule.Business.AutoMapper;
using NewsModule.Business.Concreates;
using NewsModule.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Configurations
{
    public static class BusinessDependencyInjection
    {
        public static IServiceCollection AddBusinessDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<INewsService, NewsManager>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
