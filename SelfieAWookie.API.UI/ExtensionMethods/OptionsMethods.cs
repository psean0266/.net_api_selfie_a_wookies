using SelfieAWookies.Core.Selfies.Infrastructures.Configurations;

namespace SelfieAWookie.API.UI.ExtensionMethods
{

     /// <summary>
     /// Custom options from config (json)
     /// </summary>
    public static class OptionsMethods
    {
        #region Public methods
        /// <summary>
        /// Custom options form config (json)
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomOption( this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
        }

        #endregion
    }
}
