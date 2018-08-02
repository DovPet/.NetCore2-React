using System.Collections.Generic;
using System.Threading.Tasks;
using amidus.Core.Models;

namespace amidus.Core
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovie(int id); 
        Task<IEnumerable<Movie>> GetMovies();
        void Add(Movie movie);
        void Remove(Movie movie);

    }
}