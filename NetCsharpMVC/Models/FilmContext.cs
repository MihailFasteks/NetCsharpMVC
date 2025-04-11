using Microsoft.EntityFrameworkCore;
namespace NetCsharpMVC.Models
{
    public class FilmContext:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options) {
            if (Database.EnsureCreated())
            {
                Films?.Add(new Film
                {
                    Name = "City Lights",
                    Director = "Charlie Chaplin",
                    Genr = "Romantic Comedy",
                    Year = 1931,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/6/69/City_Lights_poster.jpg",
                    Description = "A tramp falls in love with a blind flower girl and tries to help her regain her sight."
                });

                Films?.Add(new Film
                {
                    Name = "Modern Times",
                    Director = "Charlie Chaplin",
                    Genr = "Comedy, Drama",
                    Year = 1936,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/5/5f/Modern_Times_poster.jpg",
                    Description = "A factory worker struggles to survive in a modern, industrialized world."
                });

                Films?.Add(new Film
                {
                    Name = "The Great Dictator",
                    Director = "Charlie Chaplin",
                    Genr = "Satire, Drama",
                    Year = 1940,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/6/6e/Great_dictator_poster.jpg",
                    Description = "A Jewish barber is mistaken for a ruthless dictator in this anti-fascist satire."
                });

                Films?.Add(new Film
                {
                    Name = "The Kid",
                    Director = "Charlie Chaplin",
                    Genr = "Drama, Comedy",
                    Year = 1921,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/b/bb/The-kid-1921.jpg",
                    Description = "A tramp cares for an abandoned child and forms an unbreakable bond with him."
                });

                Films?.Add(new Film
                {
                    Name = "The Gold Rush",
                    Director = "Charlie Chaplin",
                    Genr = "Adventure, Comedy",
                    Year = 1925,
                    Poster = "https://upload.wikimedia.org/wikipedia/commons/d/d5/The_Gold_Rush_1925_poster.jpg",
                    Description = "A prospector ventures to Alaska during the gold rush, facing hardship and romance."
                });

                Films?.Add(new Film
                {
                    Name = "Limelight",
                    Director = "Charlie Chaplin",
                    Genr = "Drama, Romance",
                    Year = 1952,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/b/b7/Limelight.jpg",
                    Description = "An aging clown helps a suicidal ballerina rediscover her love for life."
                });

                Films?.Add(new Film
                {
                    Name = "A King in New York",
                    Director = "Charlie Chaplin",
                    Genr = "Comedy, Satire",
                    Year = 1957,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/8/86/A_King_in_New_York_poster.jpg",
                    Description = "A European monarch exiled in America gets caught in the madness of McCarthyism."
                });

                Films?.Add(new Film
                {
                    Name = "The Circus",
                    Director = "Charlie Chaplin",
                    Genr = "Comedy, Drama",
                    Year = 1928,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/1/1e/The_Circus_%281928_film%29.jpg",
                    Description = "A tramp accidentally becomes a star performer in a struggling circus."
                });

                Films?.Add(new Film
                {
                    Name = "Monsieur Verdoux",
                    Director = "Charlie Chaplin",
                    Genr = "Dark Comedy, Crime",
                    Year = 1947,
                    Poster = "https://upload.wikimedia.org/wikipedia/en/a/a5/Monsieur_Verdoux.jpg",
                    Description = "A man marries and murders wealthy women to support his family."
                });

                Films?.Add(new Film
                {
                    Name = "Shoulder Arms",
                    Director = "Charlie Chaplin",
                    Genr = "War Comedy",
                    Year = 1918,
                    Poster = "https://upload.wikimedia.org/wikipedia/commons/1/18/Shoulder_arms.jpg",
                    Description = "A hapless soldier dreams of being a hero during World War I."
                });
                SaveChanges();
            }
        }
    }
}
