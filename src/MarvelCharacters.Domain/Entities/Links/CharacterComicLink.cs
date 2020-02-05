namespace MarvelCharacters.Domain.Entities.Links
{
    public class CharacterComicLink
    {
        public int IdCharacter { get; set; }
        public Character Character { get; set; }

        public int IdComic { get; set; }
        public Comic Comic { get; set; }
    }
}
