using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class DIMethods
    {
     
        #region methods
        /// <summary>
        ///  Prepare customs depend injections 
        /// </summary>
        /// <param name="services"></param>
        public static void AddInjections(this IServiceCollection services)
        {
            //   builder.Services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
        }
        #endregion
    }
}
