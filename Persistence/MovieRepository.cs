using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using amidus.Core;
using amidus.Core.Models;

namespace amidus.Persistence
{
    public class MovieRepository : IMovieRepository
    {
    private readonly AmidusDbContext context;

    public MovieRepository(AmidusDbContext context)
    {
        this.context = context;
    }

        public void Add(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public async Task<Movie> GetMovie(int id)
        {
          return await context.Movies.Include(a => a.Actors)
            .ThenInclude(ma => ma.Actor)
            .Include(g => g.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Movie movie)
        {          
            context.Remove(movie);
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await context.Movies.Include(a => a.Actors)
            .ThenInclude(ma => ma.Actor)
            .Include(g => g.Genre).ToListAsync();
        }
    }
}