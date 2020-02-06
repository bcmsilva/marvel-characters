using MarvelCharacters.Domain.Entities.Links;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Comic
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public IList<ComicSerieLink> Series { get; set; }

        public IList<CharacterComicLink> Characters { get; set; }

        public IList<ComicStoryLink> Stories { get; set; }

        public IList<ComicEventLink> Events { get; set; }
    }
}