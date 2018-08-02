using System.Collections.Generic;
using System.Threading.Tasks;
using amidus.Core.Models;

namespace amidus.Core
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenre(int id); 
        Task<IEnumerable<Genre>> GetGenres();
        void Add(Genre genre);
        void Remove(Genre genre);
        
    }
}