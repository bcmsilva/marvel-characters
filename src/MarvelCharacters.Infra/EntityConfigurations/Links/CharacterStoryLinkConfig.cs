using MarvelCharacters.Domain.Entities.Links;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvelCharacters.Infra.EntityConfigurations.Links
{
    public class CharacterStoryLinkConfig : IEntityTypeConfiguration<CharacterStoryLink>
    {
        public void Configure(EntityTypeBuilder<CharacterStoryLink> builder)
        {
            builder.HasKey(k => new { k.IdCharacter, k.IdStory });

            builder
                .HasOne(bc => bc.Story)
                .WithMany(b => b.Characters)
                .HasForeignKey(bc => bc.IdStory);

            builder
                .HasOne(bc => bc.Character)
                .WithMany(c => c.Stories)
                .HasForeignKey(bc => bc.IdCharacter);
        }
    }
}
