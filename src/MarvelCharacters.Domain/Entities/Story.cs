using MarvelCharacters.Domain.Entities.Links;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Story
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public string Type { get; set; }

        public IList<SerieStoryLink> Series { get; set; }

        public IList<CharacterStoryLink> Characters { get; set; }

        public IList<ComicStoryLink> Comics { get; set; }

        public IList<EventStoryLink> Events { get; set; }

        //public Comic Originalissue { get; set; }
    }
}