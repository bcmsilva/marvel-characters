using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class EventSerieLinkConfig : IEntityTypeConfiguration<EventSerieLink>
    {
        public void Configure(EntityTypeBuilder<EventSerieLink> builder)
        {
            builder.HasKey(k => new { k.IdEvent, k.IdSerie });

            builder
                .HasOne(bc => bc.Serie)
                .WithMany(b => b.Events)
                .HasForeignKey(bc => bc.IdSerie);

            builder
                .HasOne(bc => bc.Event)
                .WithMany(c => c.Series)
                .HasForeignKey(bc => bc.IdEvent);
        }
    }
}
