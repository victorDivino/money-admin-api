using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.Infra.Data;
using MoneyAdmin.Infra.Data.Repositories;

namespace MoneyAdmin.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CreateAccountCommand));
            services.AddMediatR(typeof(CreateAccountCommand));
            services.AddControllers();
            services.AddDbContext<MoneyAdminContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountRepositoryReadOnly, AccountRepositoryReadOnly>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Money Admin",
                        Version = "v3.0",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.1 para controle de despesas",
                        Contact = new OpenApiContact
                        {
                            Name = "Victor do Amor Divino",
                            Url = new Uri("https://github.com/victordivino")
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Money Admin");
            });

        }
    }
}
