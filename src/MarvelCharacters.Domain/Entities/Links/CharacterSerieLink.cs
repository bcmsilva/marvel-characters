namespace MarvelCharacters.Domain.Entities.Links
{
    public class CharacterSerieLink
    {
        public int IdCharacter { get; set; }
        public Character Character { get; set; }

        public int IdSerie { get; set; }
        public Serie Serie { get; set; }
    }
}
