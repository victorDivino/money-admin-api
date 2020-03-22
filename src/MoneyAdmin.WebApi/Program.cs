using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyAdmin.Infra.Data;

namespace MoneyAdmin.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<MoneyAdminContext>()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        public static IHost MigrateDatabase<T>(this IHost webHost) where T : DbContext
        {
            try
            {
#if DEBUG
                if (!Directory.Exists(MoneyAdminContext.AttachDbPath))
                    Directory.CreateDirectory(MoneyAdminContext.AttachDbPath);
#endif
                using var scope = webHost.Services.CreateScope();
                scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return webHost;
        }
    }
}
