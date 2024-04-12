namespace Service.Services.Cart.Availibility;
public class AvailabilityService : IAvailabilityService
{
    /// <summary>
    /// 庫存是否足夠
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    async Task<bool> IAvailabilityService.IsAvailableAsync(int productId, int quantity)
    {
        try
        {
            var stock = new Dictionary<int, int>
            {
                { 1, 100 },
                { 2, 200 },
                { 3, 300 }
            };

            int available = stock.ContainsKey(productId) ? stock[productId] : 0;

            if (quantity <= available)
            {
                return await Task.FromResult(true);
            }
            else
            {
                throw new Exception("庫存不足");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
