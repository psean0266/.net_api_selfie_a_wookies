namespace SelfieAWookie.API.UI.ExtensionMethods
{
    /// <summary>
    /// About security (cors,  jwt)
    /// </summary>
    public static class SecurityMethods
    {

        #region constants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";

        #endregion

        #region public methods

        public static void AddCustomSecurity( this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                });
            });
        }



        #endregion

    }
}
