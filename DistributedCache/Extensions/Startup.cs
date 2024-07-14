using DistributedCache.Data;
using DistributedCache.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DistributedCache.Extensions
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceDependencies();
            services.AddDatabase(configuration);
            services.AddCaching(configuration);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services,
                                                IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            return services;
        }

        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "master";
            });
            return services;
        }

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
               

        public static IApplicationBuilder AddApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // Configure the HTTP request pipeline.
          
            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            return app;
        }
    }
}
