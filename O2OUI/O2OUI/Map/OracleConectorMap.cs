using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class OracleConectorMap : IEntityTypeConfiguration<OracleConector>
    {   
        public void Configure(EntityTypeBuilder<OracleConector> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome).IsRequired();
            builder.Property(o => o.Ip).IsRequired();
            builder.Property(o => o.Porta).IsRequired();
            builder.Property(o => o.NomeDoBanco).IsRequired();
            builder.Property(o => o.Usuario).IsRequired();
            builder.Property(o => o.Senha).IsRequired();
            builder.Property(o => o.Identificador).IsRequired();
            builder.HasIndex(o => o.Identificador).IsUnique();
        }
    }
}
