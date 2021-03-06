using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O2OUI.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Map
{
    public class PermissaoDeAcessoMap : IEntityTypeConfiguration<PermissaoDeAcesso>
    {
        public void Configure(EntityTypeBuilder<PermissaoDeAcesso> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
