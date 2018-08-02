using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using amidus.Core;
using amidus.Core.Models;

namespace amidus.Persistence
{
    public class GenreRepository : IGenreRepository
    {
    private readonly AmidusDbContext context;

    public GenreRepository(AmidusDbContext context)
    {
        this.context = context;
    }

        public void Add(Genre genre)
        {
            context.Genres.Add(genre);
        }

        public async Task<Genre> GetGenre(int id)
        {
          return await context.Genres.FindAsync(id);
        }

        public void Remove(Genre genre)
        {          
            context.Remove(genre);
        }
        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await context.Genres.ToListAsync();
        }
    }
}