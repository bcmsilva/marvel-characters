using MarvelCharacters.Domain.Entities;
using MarvelCharacters.Domain.Entities.Links;
using MarvelCharacters.Infra.EntityConfigurations;
using MarvelCharacters.Infra.EntityConfigurations.Links;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarvelCharacters.Domain
{
    public class MarvelCatalogContext : DbContext, IMarvelCatalogContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Story> Stories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase(databaseName: "marvel-catalog");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterComicLinkConfig());
            modelBuilder.ApplyConfiguration(new CharacterEventLinkConfig());
            modelBuilder.ApplyConfiguration(new CharacterSerieLinkConfig());
            modelBuilder.ApplyConfiguration(new CharacterStoryLinkConfig());
            modelBuilder.ApplyConfiguration(new CharacterConfig());

            modelBuilder.ApplyConfiguration(new ComicEventLinkConfig());
            modelBuilder.ApplyConfiguration(new ComicSerieLinkConfig());
            modelBuilder.ApplyConfiguration(new ComicStoryLinkConfig());
            modelBuilder.ApplyConfiguration(new ComicConfig());

            modelBuilder.ApplyConfiguration(new EventSerieLinkConfig());
            modelBuilder.ApplyConfiguration(new EventStoryLinkConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());

            modelBuilder.ApplyConfiguration(new SerieStoryLinkConfig());
            modelBuilder.ApplyConfiguration(new SerieConfig());

            modelBuilder.ApplyConfiguration(new StoryConfig());

            SetInitialData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetInitialData(ModelBuilder modelBuilder)
        {
            #region Character
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1009351,
                    Name = "Hulk",
                    Description = "Caught in a gamma bomb explosion while trying to save the life of a teenager, Dr. Bruce Banner was transformed into the incredibly powerful creature called the Hulk. An all too often misunderstood hero, the angrier the Hulk gets, the stronger the Hulk gets.",
                    Modified = new DateTime(2016, 6, 2, 12, 38, 33),
                    ResourceURI = "http://gateway.marvel.com/v1/public/characters/1009351"
                }, new Character
                {
                    Id = 1009610,
                    Name = "Spider-Man",
                    Description = "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.",
                    Modified = new DateTime(2019, 2, 6, 18, 06, 19),
                    ResourceURI = "http://gateway.marvel.com/v1/public/characters/1009610"
                }
            );
            #endregion

            #region Comic
            modelBuilder.Entity<Comic>().HasData(
                new Comic
                {
                    Id = 22253,
                    Title = "Hulk Custom Comic (2008) #1",
                    Modified = new DateTime(2008, 11, 30),
                    ResourceURI = "http://gateway.marvel.com/v1/public/comics/22253"
                }, new Comic
                {
                    Id = 1308,
                    Title = "Marvel Age Spider-Man Vol. 2: Everyday Hero (Digest)",
                    Modified = new DateTime(2018, 1, 22, 15, 42, 11),
                    ResourceURI = "http://gateway.marvel.com/v1/public/comics/1308",
                    Description = "The Marvel Age of Comics continues! This time around, Spidey meets his match against such classic villains as Electro and the Lizard, and faces the return of one of his first foes: the Vulture! Plus: Spider-Man vs. the Living Brain, Peter Parker's fight with Flash Thompson, and the wall-crawler tackles the high-flying Human Torch!"
                }
            );
            #endregion

            #region Event
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 116,
                    Title = "Acts of Vengeance!",
                    Description = "Loki sets about convincing the super-villains of Earth to attack heroes other than those they normally fight in an attempt to destroy the Avengers to absolve his guilt over inadvertently creating the team in the first place.",
                    ResourceURI = "http://gateway.marvel.com/v1/public/events/116",
                    Modified = new DateTime(2013, 06, 28, 16, 31, 24),
                    Start = new DateTime(1989, 12, 10),
                    End = new DateTime(2008, 01, 04)
                }
            );
            #endregion

            #region Serie
            modelBuilder.Entity<Serie>().HasData(
                new Serie
                {
                    Id = 2021,
                    Title = "Incredible Hulk (1962 - 1999)",
                    Description = "Trapped in a the radioactive blast of a Gamma Bomb, withdrawn Doctor Bruce Banner becomes the rampaging Incredible Hulk! Witness the evolution of Marvel's most unstoppable force, from sinister brute to uncontrollable beast and every stage in between.",
                    ResourceURI = "http://gateway.marvel.com/v1/public/series/2021",
                    StartYear = 1962,
                    EndYear = 1999,
                    Modified = new DateTime(2016, 9, 22, 16, 36, 43)
                }, new Serie
                {
                    Id = 2271,
                    Title = "Peter Parker, the Spectacular Spider-Man (1976 - 1998)",
                    Description = null,
                    ResourceURI = "http://gateway.marvel.com/v1/public/series/2271",
                    StartYear = 1976,
                    EndYear = 1998,
                    Modified = new DateTime(2019, 9, 5, 14, 31, 53)
                }
            );
            #endregion

            #region Story
            modelBuilder.Entity<Story>().HasData(
                new Story
                {
                    Id = 702,
                    Title = "INCREDIBLE HULK (1999) #62",
                    Description = "",
                    ResourceURI = "http://gateway.marvel.com/v1/public/stories/702",
                    Type = "cover",
                    Modified = new DateTime(2018, 8, 7, 9, 36, 56)
                }, new Story
                {
                    Id = 486,
                    Title = "Cover #486",
                    Description = "",
                    ResourceURI = "http://gateway.marvel.com/v1/public/stories/486",
                    Type = "cover",
                    Modified = new DateTime(2012, 11, 26, 12, 18, 57)
                }
            );
            #endregion

            #region CharacterComicLink
            modelBuilder.Entity<CharacterComicLink>().HasData(
                new CharacterComicLink
                {
                    IdCharacter = 1009351,
                    IdComic = 22253
                }, new CharacterComicLink
                {
                    IdCharacter = 1009610,
                    IdComic = 1308
                }
            );
            #endregion

            #region CharacterEventLink
            modelBuilder.Entity<CharacterEventLink>().HasData(
                new CharacterEventLink
                {
                    IdCharacter = 1009351,
                    IdEvent = 116
                }, new CharacterEventLink
                {
                    IdCharacter = 1009610,
                    IdEvent = 116
                }
            );
            #endregion

            #region CharacterSerieLink
            modelBuilder.Entity<CharacterSerieLink>().HasData(
                new CharacterSerieLink
                {
                    IdCharacter = 1009351,
                    IdSerie = 2021
                }, new CharacterSerieLink
                {
                    IdCharacter = 1009610,
                    IdSerie = 2271
                }
            );
            #endregion

            #region CharacterStoryLink
            modelBuilder.Entity<CharacterStoryLink>().HasData(
                new CharacterStoryLink
                {
                    IdCharacter = 1009351,
                    IdStory = 702
                }, new CharacterStoryLink
                {
                    IdCharacter = 1009610,
                    IdStory = 486
                }
            );
            #endregion

            #region ComicEventLink
            modelBuilder.Entity<ComicEventLink>().HasData(
                new ComicEventLink
                {
                    IdComic = 22253,
                    IdEvent = 116
                }, new ComicEventLink
                {
                    IdComic = 1308,
                    IdEvent = 116
                }
            );
            #endregion

            #region ComicSerieLink
            modelBuilder.Entity<ComicSerieLink>().HasData(
                new ComicSerieLink
                {
                    IdComic = 22253,
                    IdSerie = 2021
                }, new ComicSerieLink
                {
                    IdComic = 1308,
                    IdSerie = 2271
                }
            );
            #endregion

            #region ComicStoryLink
            modelBuilder.Entity<ComicStoryLink>().HasData(
                new ComicStoryLink
                {
                    IdComic = 22253,
                    IdStory = 702
                }, new ComicStoryLink
                {
                    IdComic = 1308,
                    IdStory = 486
                }
            );
            #endregion

            #region EventSerieLink
            modelBuilder.Entity<EventSerieLink>().HasData(
                new EventSerieLink
                {
                    IdEvent = 116,
                    IdSerie = 2021
                }, new EventSerieLink
                {
                    IdEvent = 116,
                    IdSerie = 2271
                }
            );
            #endregion

            #region EventStoryLink
            modelBuilder.Entity<EventStoryLink>().HasData(
                new EventStoryLink
                {
                    IdEvent = 116,
                    IdStory = 702
                }, new EventStoryLink
                {
                    IdEvent = 116,
                    IdStory = 486
                }
            );
            #endregion

            #region SerieStoryLink
            modelBuilder.Entity<SerieStoryLink>().HasData(
                new SerieStoryLink
                {
                    IdSerie = 2021,
                    IdStory = 702
                }, new SerieStoryLink
                {
                    IdSerie = 2271,
                    IdStory = 486
                }
            );
            #endregion
        }
    }
}
