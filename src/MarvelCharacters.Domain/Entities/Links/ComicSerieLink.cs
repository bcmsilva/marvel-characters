namespace MarvelCharacters.Domain.Entities.Links
{
    public class ComicSerieLink
    {
        public int IdComic { get; set; }
        public Comic Comic { get; set; }

        public int IdSerie { get; set; }
        public Serie Serie { get; set; }
    }
}
