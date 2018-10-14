using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace CRM.DataStore
{
    public static class DBMigrationExtension
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HandleMigration>();
        }
           
    }


    public class HandleMigration
    {
         private readonly RequestDelegate _next;
         private  CRMDBContext _dbcontext;

         private readonly IServiceProvider _serviceProvider;
        public HandleMigration(RequestDelegate next,IServiceProvider serviceProvider)
        {
         _next = next;   
         //_dbcontext = dbcontext;
         _serviceProvider = serviceProvider;
        }

         public async Task InvokeAsync(HttpContext context)
        {
            _dbcontext =    _serviceProvider.GetRequiredService<CRMDBContext>();
            if(!_dbcontext.AllMigrationsApplied())
            {
                   await _dbcontext.Database.MigrateAsync();
            }
            await _next(context);
        }
    }
}