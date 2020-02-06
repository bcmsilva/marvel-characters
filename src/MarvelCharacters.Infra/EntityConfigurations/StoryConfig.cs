using MarvelCharacters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations
{
    public class StoryConfig : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}
