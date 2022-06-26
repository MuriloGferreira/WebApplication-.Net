using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {   //Mapeia os campos da tabela com o modelo
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Idade).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Profissao).IsRequired();
            builder.Property(x => x.EstadoCivil).IsRequired();
        }
    }
}
