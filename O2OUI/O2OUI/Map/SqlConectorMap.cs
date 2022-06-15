using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class SqlConectorMap : IEntityTypeConfiguration<SqlConector>
    {   
        public void Configure(EntityTypeBuilder<SqlConector> builder)
        {
            builder.HasKey(sql => sql.Id);
            builder.Property(sql => sql.Nome).IsRequired();
            builder.Property(sql => sql.Ip).IsRequired();
            builder.Property(sql => sql.Porta).IsRequired();
            builder.Property(sql => sql.NomeDoBanco).IsRequired();
            builder.Property(sql => sql.Usuario).IsRequired();
            builder.Property(sql => sql.Senha).IsRequired();
            builder.Property(sql => sql.Identificador).IsRequired();
            builder.HasIndex(sql => sql.Identificador).IsUnique();
        }
    }
}
