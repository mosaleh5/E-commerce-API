
using Microsoft.OpenApi.Models;

namespace Store.Web.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerdocumentation (this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Store Api",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed",
                        Email = "Mohamed@gmail.com",
                        
                    }
                });

                var sercurityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization:Bearer{token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme,

                    }

                };
                options.AddSecurityDefinition("bearer", sercurityScheme);
                var securityRequirments = new OpenApiSecurityRequirement
                {
                    {sercurityScheme , new[] {"bearer"} }
                };
                options.AddSecurityRequirement(securityRequirments);
            });
            return services;
        }
    }
}
