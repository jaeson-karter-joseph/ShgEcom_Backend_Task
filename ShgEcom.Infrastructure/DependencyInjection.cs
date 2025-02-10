using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShgEcom.Application.Common.Interfaces.Authentication;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Application.Common.Interfaces.Services;
using ShgEcom.Infrastructure.Authentication;
using ShgEcom.Infrastructure.Persistence;
using ShgEcom.Infrastructure.Persistence.DbContext;
using ShgEcom.Infrastructure.Services;
using System.Text;

namespace ShgEcom.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddAuth(configuration);
            services.AddDbContext(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRespository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(jwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGeneratore>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SectionName));
            services.AddSingleton<MongoDbContext>();
            return services;
        }
    }
}
