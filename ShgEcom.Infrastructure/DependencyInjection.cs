using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
using System.Threading.RateLimiting;

namespace ShgEcom.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddRateLimit();
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

        public static IServiceCollection AddRateLimit(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context => RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromSeconds(10),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        }
                 ));

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.HttpContext.Response.ContentType = "application/json";

                    var problemDetails = new
                    {
                        Status = StatusCodes.Status429TooManyRequests,
                        Type = "https://httpstatuses.com/429",
                        Title = "Rate Limit Exceeded",
                        Detail = "You have sent too many requests in a short period. Please try again later.",
                        Instance = context.HttpContext.Request.Path
                    };

                    await context.HttpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: token);
                };
            });
            return services;
        }
    }
}
