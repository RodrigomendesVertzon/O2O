using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class LicenciamentoMap : IEntityTypeConfiguration<Licenciamento>
    {
        public void Configure(EntityTypeBuilder<Licenciamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LicenciamentoDado).IsRequired();
            builder.HasIndex(x => x.LicenciamentoDado).IsUnique();
            builder.Property(x => x.ChaveLicença).IsRequired();
            builder.HasIndex(x => x.ChaveLicença).IsUnique();

        }
    }
}
