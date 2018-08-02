using System.Threading.Tasks;
using amidus.Core; 

namespace amidus.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly AmidusDbContext context;

    public UnitOfWork(AmidusDbContext context)
    {
      this.context = context;
    }

    public async Task CompleteAsync()
    {
      await context.SaveChangesAsync();
    }
  }
}