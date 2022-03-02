using Catalog.API.Infrastructure.Data;
using Catalog.API.Infrastructure.Data.Repositories;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.API.Application.ServiceExtension
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services
                    .AddEndpointsApiExplorer()
                    .AddSwaggerGen()
                    .AddAppCors()
                    .AddAutoMapper(Assembly.GetExecutingAssembly())
                    .AddPersistance(configuration)
                    .AddRepository();

            return services;
        }

        private static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddDbContext<CatalogContext>(builder =>
            {
                //dotnet user-secrets init
                //dotnet user-secrets set "Name" "Value"
                //dotnet user-secrets remove "Name"
                //dotnet user-secrets clear
                builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
                //  SqlConnectionStringBuilder sqlCnnStrBuilder =
                //    new SqlConnectionStringBuilder(configuration.GetConnectionString("Catalog"));
                //sqlCnnStrBuilder.Password = configuration["Password"];

                //! SQL Server(IP, User, Password, Database Name, ...)

                //builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
                //   builder.UseSqlServer(sqlCnnStrBuilder.ConnectionString);
            });
        }
        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //return services.AddSingleton<IProductRepository, FakeProductRepository>();
            services.AddTransient<IProductRepository, SqlProductRepository>();
             services.AddTransient<ImageRepository, SqlImageRepository>();
            return services;

        }

        private static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    //builder.WithOrigins("d1").WithHeaders().WithMethods("Get", "POST");
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-TotalCount");
                });
                    
            });
            return services;

        }


    }
}
