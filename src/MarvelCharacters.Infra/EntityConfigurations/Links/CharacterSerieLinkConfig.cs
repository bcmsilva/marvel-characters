using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class CharacterSerieLinkConfig : IEntityTypeConfiguration<CharacterSerieLink>
    {
        public void Configure(EntityTypeBuilder<CharacterSerieLink> builder)
        {
            builder.HasKey(k => new { k.IdCharacter, k.IdSerie });

            builder
                .HasOne(bc => bc.Serie)
                .WithMany(b => b.Characters)
                .HasForeignKey(bc => bc.IdSerie);

            builder
                .HasOne(bc => bc.Character)
                .WithMany(c => c.Series)
                .HasForeignKey(bc => bc.IdCharacter);
        }
    }
}
