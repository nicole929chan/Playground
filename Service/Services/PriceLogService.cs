using Repository.Entities;
using Repository.Repositories;
using Service.Dtos;

namespace Service.Services;
public class PriceLogService : IPriceLogService
{
    private readonly IPriceLogRepository _priceLogRepository;

    public PriceLogService(IPriceLogRepository priceLogRepository)
    {
        _priceLogRepository = priceLogRepository;
    }

    public async Task<int> AddAsync(PriceLog priceLog)
    {
        try
        {
            return await _priceLogRepository.AddAsync(priceLog);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in PriceLogService.AddAsync", ex);
        }
    }

    protected PriceLogCreate MakePriceLog(int productId, int userId, decimal oldPrice, decimal newPrice, string? reason)
    {
        return new PriceLogCreate
        {
            ProductId = productId,
            UserId = userId,
            OldPrice = oldPrice,
            NewPrice = newPrice,
            Reason = reason,
            CreatedAt = DateTime.UtcNow
        };
    }
}
