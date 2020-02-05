using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Serie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public int? StartYear { get; set; }

        public int? EndYear { get; set; }

        public IList<Comic> Comics { get; set; }

        public IList<Character> Characters { get; set; }

        public IList<Story> Stories { get; set; }

        public IList<Event> Events { get; set; }

        public Serie Next { get; set; }

        public Serie Previous { get; set; }
    }
}