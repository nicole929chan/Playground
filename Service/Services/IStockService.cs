using Repository.Entities;

namespace Service.Services;
public interface IStockService
{
    Task<Stock> GetStockAsync(int productId);
}
