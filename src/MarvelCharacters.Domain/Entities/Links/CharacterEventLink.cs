namespace MarvelCharacters.Domain.Entities.Links
{
    public class CharacterEventLink
    {
        public int IdCharacter { get; set; }
        public Character Character { get; set; }

        public int IdEvent { get; set; }
        public Event Event { get; set; }
    }
}
