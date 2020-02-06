using MarvelCharacters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations
{
    public class ComicConfig : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}
