namespace MarvelCharacters.Domain.Entities.Links
{
    public class ComicStoryLink
    {
        public int IdComic { get; set; }
        public Comic Comic { get; set; }

        public int IdStory { get; set; }
        public Story Story { get; set; }
    }
}
