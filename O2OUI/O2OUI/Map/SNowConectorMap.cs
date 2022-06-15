using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class SNowConectorMap : IEntityTypeConfiguration<SNowConector>
    {
        public void Configure(EntityTypeBuilder<SNowConector> builder)
        {
            builder.HasKey(sn => sn.Id);
            builder.Property(sn => sn.Nome).IsRequired();
            builder.Property(sn => sn.Url).IsRequired();
            builder.Property(sn => sn.Usuario).IsRequired();
            builder.Property(sn => sn.Senha).IsRequired();
            builder.Property(sn => sn.Identificador).IsRequired();
            builder.HasIndex(sn => sn.Identificador).IsUnique();
        }
    }
}
