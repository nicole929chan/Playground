using Repository.Entities;

namespace Repository.Repositories;
public interface IPriceLogRepository
{
    Task<int> AddAsync(PriceLog priceLog);
}
