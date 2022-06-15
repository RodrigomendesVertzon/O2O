using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class SdmConectorMap : IEntityTypeConfiguration<SdmConector>
    {
        public void Configure(EntityTypeBuilder<SdmConector> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Usuario).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Identificador).IsRequired();
            builder.HasIndex(x => x.Identificador).IsUnique();

        }
    }
}
