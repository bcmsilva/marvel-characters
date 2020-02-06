using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class EventStoryLinkConfig : IEntityTypeConfiguration<EventStoryLink>
    {
        public void Configure(EntityTypeBuilder<EventStoryLink> builder)
        {
            builder.HasKey(k => new { k.IdEvent, k.IdStory });

            builder
                .HasOne(bc => bc.Story)
                .WithMany(b => b.Events)
                .HasForeignKey(bc => bc.IdStory);

            builder
                .HasOne(bc => bc.Event)
                .WithMany(c => c.Stories)
                .HasForeignKey(bc => bc.IdEvent);
        }
    }
}
