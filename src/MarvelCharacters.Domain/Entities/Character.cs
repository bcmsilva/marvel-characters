using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public IList<Comic> Comics { get; set; }

        public IList<Serie> Series { get; set; }

        public IList<Story> Stories { get; set; }

        public IList<Event> Events { get; set; }
    }
}
