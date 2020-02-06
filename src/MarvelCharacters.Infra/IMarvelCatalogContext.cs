using MarvelCharacters.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelCharacters.Domain
{
    public interface IMarvelCatalogContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<Comic> Comics { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Serie> Series { get; set; }
        DbSet<Story> Stories { get; set; }
    }
}
