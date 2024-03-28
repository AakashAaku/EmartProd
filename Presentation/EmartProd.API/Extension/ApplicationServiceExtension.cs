using EmartProd.API.Responses;
using EmartProd.Application.Interfaces;
using EmartProd.Infrastructure.EmartContext;
using EmartProd.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.API.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationExtension(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<EmartProdContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("EmartProdConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //ApplicationConfiguration.RegisterApplicationConfig(builder.Services);
           // services.RegisterApplicationConfig();
            //Implementing custom validation error handling using build in services by dotnet
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                 .Where(e => e.Value.Errors.Count > 0)
                                 .SelectMany(x => x.Value.Errors)
                                 .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new APIValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}