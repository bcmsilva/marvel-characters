namespace MarvelCharacters.Domain.Entities.Links
{
    public class ComicEventLink
    {
        public int IdComic { get; set; }
        public Comic Comic { get; set; }

        public int IdEvent { get; set; }
        public Event Event { get; set; }
    }
}
