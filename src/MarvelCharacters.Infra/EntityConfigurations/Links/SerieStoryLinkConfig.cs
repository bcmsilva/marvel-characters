using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class SerieStoryLinkConfig : IEntityTypeConfiguration<SerieStoryLink>
    {
        public void Configure(EntityTypeBuilder<SerieStoryLink> builder)
        {
            builder.HasKey(k => new { k.IdSerie, k.IdStory });

            builder
                .HasOne(bc => bc.Story)
                .WithMany(b => b.Series)
                .HasForeignKey(bc => bc.IdStory);

            builder
                .HasOne(bc => bc.Serie)
                .WithMany(c => c.Stories)
                .HasForeignKey(bc => bc.IdSerie);
        }
    }
}
