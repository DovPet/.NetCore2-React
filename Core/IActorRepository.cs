using System.Collections.Generic;
using System.Threading.Tasks;
using amidus.Core.Models;

namespace amidus.Core
{
    public interface IActorRepository
    {
        Task<Actor> GetActor(int id); 
        Task<IEnumerable<Actor>> GetActors();
        void Add(Actor actor);
        void Remove(Actor actor);

    }
}