using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class ComicSerieLinkConfig : IEntityTypeConfiguration<ComicSerieLink>
    {
        public void Configure(EntityTypeBuilder<ComicSerieLink> builder)
        {
            builder.HasKey(k => new { k.IdComic, k.IdSerie });

            builder
                .HasOne(bc => bc.Serie)
                .WithMany(b => b.Comics)
                .HasForeignKey(bc => bc.IdSerie);

            builder
                .HasOne(bc => bc.Comic)
                .WithMany(c => c.Series)
                .HasForeignKey(bc => bc.IdComic);
        }
    }
}
