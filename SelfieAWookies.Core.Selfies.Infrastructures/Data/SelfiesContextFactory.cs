using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
    {
        #region Public methods
        public SelfiesContext CreateDbContext(string[] args)
        {
            //DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            //SelfiesContext context = new SelfiesContext(builder.Op);

            //return context;

            // on prends la configuration builder
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            // On lui ajoute le lien de fichier setting
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            DbContextOptionsBuilder<SelfiesContext> builder = new DbContextOptionsBuilder<SelfiesContext>();

            builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDataBase"), b => b.MigrationsAssembly("SelfieAWookies.Core.Selfies.Migrations"));

            SelfiesContext context = new SelfiesContext(builder.Options);

            return context;
        }

        #endregion
    }
}
