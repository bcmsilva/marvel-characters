namespace MarvelCharacters.Domain.Entities.Links
{
    public class SerieStoryLink
    {
        public int IdSerie { get; set; }
        public Serie Serie { get; set; }

        public int IdStory { get; set; }
        public Story Story { get; set; }
    }
}
