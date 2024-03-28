using Service.Dtos;

namespace Service.Services;
public interface IPriceLogService
{
    Task<int> AddAsync(PriceLogCreate priceLogCreate);
    public PriceLogCreate MakePriceLog(int productId, int userId, decimal oldPrice, decimal newPrice, string? reason);
}
