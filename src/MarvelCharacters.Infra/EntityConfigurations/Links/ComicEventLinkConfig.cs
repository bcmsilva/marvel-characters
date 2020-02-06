using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class ComicEventLinkConfig : IEntityTypeConfiguration<ComicEventLink>
    {
        public void Configure(EntityTypeBuilder<ComicEventLink> builder)
        {
            builder.HasKey(k => new { k.IdComic, k.IdEvent });

            builder
                .HasOne(bc => bc.Event)
                .WithMany(b => b.Comics)
                .HasForeignKey(bc => bc.IdEvent);

            builder
                .HasOne(bc => bc.Comic)
                .WithMany(c => c.Events)
                .HasForeignKey(bc => bc.IdComic);
        }
    }
}
