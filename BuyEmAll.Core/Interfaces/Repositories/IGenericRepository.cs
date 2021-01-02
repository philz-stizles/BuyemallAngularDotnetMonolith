using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity // This Constrains this interface to only classes that derive from BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetListWithSpecAsync(ISpecification<T> spec);
    }
}
