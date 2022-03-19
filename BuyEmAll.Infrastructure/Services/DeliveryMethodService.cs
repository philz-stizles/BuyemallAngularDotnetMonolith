using BuyEmAll.Core.Entities.OrderAggregate;
using BuyEmAll.Core.Interfaces.Repositories;
using BuyEmAll.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Services
{
    public class DeliveryMethodService : IDeliveryMethodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryMethodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
        }
    }
}
