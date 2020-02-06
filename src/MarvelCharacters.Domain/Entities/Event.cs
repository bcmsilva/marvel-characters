using MarvelCharacters.Domain.Entities.Links;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public IList<ComicEventLink> Comics { get; set; }

        public IList<EventSerieLink> Series { get; set; }

        public IList<EventStoryLink> Stories { get; set; }

        public IList<CharacterEventLink> Characters { get; set; }

        //public Event Next { get; set; }

        //public Event Previous { get; set; }
    }
}