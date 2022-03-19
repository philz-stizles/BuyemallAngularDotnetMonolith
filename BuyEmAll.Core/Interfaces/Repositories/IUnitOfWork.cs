using BuyEmAll.Core.Entities;
using System;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
