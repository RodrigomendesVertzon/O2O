using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class MySqlConectorMap : IEntityTypeConfiguration<MySqlConector>
    {   
        public void Configure(EntityTypeBuilder<MySqlConector> builder)
        {
            builder.HasKey(msql => msql.Id);
            builder.Property(msql => msql.Nome).IsRequired();
            builder.Property(msql => msql.Ip).IsRequired();
            builder.Property(msql => msql.Porta).IsRequired();
            builder.Property(msql => msql.NomeDoBanco).IsRequired();
            builder.Property(msql => msql.Usuario).IsRequired();
            builder.Property(msql => msql.Senha).IsRequired();
            builder.Property(msql => msql.Identificador).IsRequired();
            builder.HasIndex(msql => msql.Identificador).IsUnique();
        }
    }
}
