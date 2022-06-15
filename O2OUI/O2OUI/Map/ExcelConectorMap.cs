using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class ExcelConectorMap : IEntityTypeConfiguration<ExcelConector>
    {   
        public void Configure(EntityTypeBuilder<ExcelConector> builder)
        {
            builder.HasKey(exc => exc.Id);
            builder.Property(exc => exc.Nome).IsRequired();
            builder.Property(exc => exc.Ip).IsRequired();
            builder.Property(exc => exc.DiretorioCompartilhado).IsRequired();
            builder.Property(exc => exc.NomeArquivo).IsRequired();
            builder.Property(exc => exc.Sheet).IsRequired();
            builder.Property(exc => exc.Identificador).IsRequired();
            builder.HasIndex(exc => exc.Identificador).IsUnique();
        }
    }
}
