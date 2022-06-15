using Microsoft.EntityFrameworkCore;
using O2OUI.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using O2OUI.Models;
using O2OUI.Models.Seguranca;

namespace O2OUI.Models
{
    public class O2OContext : DbContext
    {
        public DbSet<SqlConector> SqlConectors { get; set; }
        public DbSet<SdmConector> SdmConectors { get; set; }
        public DbSet<OracleConector> OracleConectors { get; set; }
        public DbSet<MySqlConector> MySqlConectors { get; set; }
        public DbSet<ExcelConector> ExcelConectors { get; set; }
        public DbSet<SoapConector> SoapConectors { get; set; }
        public DbSet<SNowConector> SNowConectors { get; set; }
        public DbSet<SdmStatus> SdmStatus { get; set; }

        public DbSet<ConfigLabel> ConfigLabels { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Licenciamento> Licenciamento { get; set; }
        public DbSet<BancoDeDados> BancoDeDados { get; set; }

        public DbSet<PermissaoDeAcesso> PermissaoDeAcessos { get; set; }
        public DbSet<CheckLicense> CheckLicenses { get; set; }

        public O2OContext(DbContextOptions<O2OContext> opcoes) : base(opcoes) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SqlConectorMap());
            modelBuilder.ApplyConfiguration(new OracleConectorMap());
            modelBuilder.ApplyConfiguration(new MySqlConectorMap());
            modelBuilder.ApplyConfiguration(new SdmConectorMap());
            modelBuilder.ApplyConfiguration(new ExcelConectorMap());
            modelBuilder.ApplyConfiguration(new SoapConectorMap());
            modelBuilder.ApplyConfiguration(new SNowConectorMap());
            modelBuilder.ApplyConfiguration(new SdmStatusMap());
            modelBuilder.ApplyConfiguration(new ConfigLabelMap());
            modelBuilder.ApplyConfiguration(new ConfigurationMap());
            modelBuilder.ApplyConfiguration(new LicenciamentoMap());
            modelBuilder.ApplyConfiguration(new BancoDeDadosMap());
            modelBuilder.ApplyConfiguration(new PermissaoDeAcessoMap());
            modelBuilder.ApplyConfiguration(new CheckLicenseMap());
        }

        public DbSet<O2OUI.Models.OracleConector> OracleConector { get; set; }

        public DbSet<O2OUI.Models.MySqlConector> MySqlConector { get; set; }

        public DbSet<O2OUI.Models.ExcelConector> ExcelConector { get; set; }

        public DbSet<O2OUI.Models.SNowConector> SNowConector { get; set; }


    }
}
