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

        public static void AddCustomSecurity( this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5500")
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
