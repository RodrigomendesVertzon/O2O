using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class ConfigurationMap : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valores).IsRequired();
            builder.HasOne(x => x.ConfigLabel).WithMany(x => x.Configurations).HasForeignKey(x => x.IdCL);

        }
    }
}
