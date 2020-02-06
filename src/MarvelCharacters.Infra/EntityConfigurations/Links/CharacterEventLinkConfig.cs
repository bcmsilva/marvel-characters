using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class CharacterEventLinkConfig : IEntityTypeConfiguration<CharacterEventLink>
    {
        public void Configure(EntityTypeBuilder<CharacterEventLink> builder)
        {
            builder.HasKey(k => new { k.IdCharacter, k.IdEvent });

            builder
                .HasOne(bc => bc.Event)
                .WithMany(b => b.Characters)
                .HasForeignKey(bc => bc.IdEvent);

            builder
                .HasOne(bc => bc.Character)
                .WithMany(c => c.Events)
                .HasForeignKey(bc => bc.IdCharacter);
        }
    }
}
