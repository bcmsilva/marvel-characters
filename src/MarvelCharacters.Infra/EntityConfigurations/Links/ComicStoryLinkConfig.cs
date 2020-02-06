using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class ComicStoryLinkConfig : IEntityTypeConfiguration<ComicStoryLink>
    {
        public void Configure(EntityTypeBuilder<ComicStoryLink> builder)
        {
            builder.HasKey(k => new { k.IdComic, k.IdStory });

            builder
                .HasOne(bc => bc.Story)
                .WithMany(b => b.Comics)
                .HasForeignKey(bc => bc.IdStory);

            builder
                .HasOne(bc => bc.Comic)
                .WithMany(c => c.Stories)
                .HasForeignKey(bc => bc.IdComic);
        }
    }
}
