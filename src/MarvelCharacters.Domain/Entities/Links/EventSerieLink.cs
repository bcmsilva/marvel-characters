namespace MarvelCharacters.Domain.Entities.Links
{
    public class EventSerieLink
    {
        public int IdEvent { get; set; }
        public Event Event { get; set; }

        public int IdSerie { get; set; }
        public Serie Serie { get; set; }
    }
}
