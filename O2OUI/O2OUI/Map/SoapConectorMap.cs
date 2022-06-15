using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class SoapConectorMap : IEntityTypeConfiguration<SoapConector>
    {   
        public void Configure(EntityTypeBuilder<SoapConector> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Identificador).IsRequired();
            builder.HasIndex(x => x.Identificador).IsUnique();
            builder.Property(x => x.TipoDeAutenticacao).HasConversion<string>();
        }
    }
}
