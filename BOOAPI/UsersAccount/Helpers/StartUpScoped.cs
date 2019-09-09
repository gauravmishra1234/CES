using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Repository;
using UsersAccount.Services;

namespace UsersAccount.Helpers
{
    public static class StartUpScoped
    {
        public static void StartUpAddScoped(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersServices, UsersServices>();

            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IRolesServices, RolesServices>();
        }
    }
}
