using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class BancoDeDadosMap : IEntityTypeConfiguration<BancoDeDados>
    {
        public void Configure(EntityTypeBuilder<BancoDeDados> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Conexao).IsRequired();

        }
    }
}
