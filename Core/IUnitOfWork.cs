using System;
using System.Threading.Tasks;

namespace amidus.Core
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}