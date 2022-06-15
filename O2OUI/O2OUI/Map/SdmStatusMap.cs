using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class SdmStatusMap : IEntityTypeConfiguration<SdmStatus>
    {
        public void Configure(EntityTypeBuilder<SdmStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.StatusType).HasConversion<string>();
            builder.HasOne(x => x.SdmConector).WithMany(x => x.SdmStatus).HasForeignKey(x => x.IdSdm);

        }
    }
}
