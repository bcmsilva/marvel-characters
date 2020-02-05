using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations
{
    public class CharacterComicLinkConfig : IEntityTypeConfiguration<CharacterComicLink>
    {
        public void Configure(EntityTypeBuilder<CharacterComicLink> builder)
        {
            builder.HasKey(k => new { k.IdCharacter, k.IdComic });

            builder
                .HasOne(bc => bc.Comic)
                .WithMany(b => b.Characters)
                .HasForeignKey(bc => bc.IdComic);

            builder
                .HasOne(bc => bc.Character)
                .WithMany(c => c.Comics)
                .HasForeignKey(bc => bc.IdCharacter);
        }
    }
}
