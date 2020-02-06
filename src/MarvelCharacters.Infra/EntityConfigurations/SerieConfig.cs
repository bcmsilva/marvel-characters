using MarvelCharacters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations
{
    public class SerieConfig : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}
