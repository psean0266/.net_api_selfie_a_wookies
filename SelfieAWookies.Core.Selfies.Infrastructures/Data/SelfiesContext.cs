﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data.TypeConfigurations;
using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Data
{
    public class SelfiesContext: DbContext, IUnitOfWork
    {
        #region constructors

        //public SelfiesContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        //public SelfiesContext() : base() {}

       
       public SelfiesContext(DbContextOptions<SelfiesContext> options)
         : base(options)
        {

        }

        #endregion

        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());

        }
        #endregion

        #region properties
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        #endregion

    }
}
