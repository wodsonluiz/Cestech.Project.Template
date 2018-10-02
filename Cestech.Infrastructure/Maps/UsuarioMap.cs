using Cestech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cestech.Infrastructure.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //primaty key
            builder.HasKey(x => x.IdUsuario);

            //columns
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Dt_Nascimento).HasColumnName("Dt_Nascimento");
            builder.Property(x => x.Cep).HasColumnName("Cep").HasMaxLength(9).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();

            // Relatioships

            //table name
            builder.ToTable("Usuario");
        } 
    }
}
