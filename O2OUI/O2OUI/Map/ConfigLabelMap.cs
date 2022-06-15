using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class ConfigLabelMap : IEntityTypeConfiguration<ConfigLabel>
    {
        public void Configure(EntityTypeBuilder<ConfigLabel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Label).IsUnique();

        }
    }
}
