using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Text;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    /// <summary>
    /// About security (cors,  jwt)
    /// </summary>
    public static class SecurityMethods
    {

        #region constants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2";
        public const string DEFAULT_POLICY_3 = "DEFAULT_POLICY_3";

        #endregion

        #region public methods

        public static void AddCustomSecurity( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomCors(configuration);
            services.AddCustomAuthentication(configuration);
        }


        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => {

                string maclef = configuration["Jwt:key"];
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(maclef)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,
                };
            });
        }

        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(configuration["Cors:Origin"])
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                });

                options.AddPolicy(DEFAULT_POLICY_2, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5501")
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                });

                options.AddPolicy(DEFAULT_POLICY_3, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5502")
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                });
            });

        }

        #endregion

    }
}
