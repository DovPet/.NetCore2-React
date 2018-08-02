using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using amidus.Core;
using amidus.Core.Models;

namespace amidus.Persistence
{
    public class ActorRepository : IActorRepository
    {
    private readonly AmidusDbContext context;

    public ActorRepository(AmidusDbContext context)
    {
        this.context = context;
    }

        public void Add(Actor actor)
        {
            context.Actors.Add(actor);
        }

        public async Task<Actor> GetActor(int id)
        {
          return await context.Actors.FindAsync(id);
        }

        public void Remove(Actor actor)
        {          
            context.Remove(actor);
        }
        public async Task<IEnumerable<Actor>> GetActors()
        {
            return await context.Actors.ToListAsync();
        }
    }
}