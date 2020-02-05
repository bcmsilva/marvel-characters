namespace MarvelCharacters.Domain.Entities.Links
{
    public class CharacterStoryLink
    {
        public int IdCharacter { get; set; }
        public Character Character { get; set; }

        public int IdStory { get; set; }
        public Story Story { get; set; }
    }
}
