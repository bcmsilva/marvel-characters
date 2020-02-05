namespace MarvelCharacters.Domain.Entities.Links
{
    public class EventStoryLink
    {
        public int IdEvent { get; set; }
        public Event Event { get; set; }

        public int IdStory { get; set; }
        public Story Story { get; set; }
    }
}
